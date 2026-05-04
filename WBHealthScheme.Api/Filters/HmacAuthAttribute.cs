using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Cryptography;
using System.Text;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Application.Services;

public class HmacAuthAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var request = context.HttpContext.Request;

        // 🔹 Step 1: Read headers
        var apiKey = request.Headers["x-api-key"].ToString();
        var signature = request.Headers["x-signature"].ToString();
        var timestamp = request.Headers["x-timestamp"].ToString();

        if (string.IsNullOrEmpty(apiKey) ||
            string.IsNullOrEmpty(signature) ||
            string.IsNullOrEmpty(timestamp))
        {
            context.Result = new UnauthorizedObjectResult("Missing headers");
            return;
        }

        // 🔹 Step 2: Get services
        var apiKeyService = context.HttpContext.RequestServices
            .GetRequiredService<IApiKeyService>();

        var encryptionService = context.HttpContext.RequestServices
            .GetRequiredService<EncryptionService>();

        // 🔹 Step 3: Validate API key
        var apiKeyData = await apiKeyService.GetValidKeyAsync(apiKey);

        if (apiKeyData == null)
        {
            context.Result = new UnauthorizedObjectResult("Invalid API Key");
            return;
        }

        // 🔹 Step 4: Decrypt secret
        var secret = encryptionService.Decrypt(apiKeyData.ApiSecretEncrypted);

        // 🔹 Step 5: Recreate signature
        var data = $"{request.Method}{request.Path}{timestamp}";
        var serverSignature = GenerateHmac(secret, data);

        // 🔹 Step 6: Compare signature (secure way)
        if (!CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(serverSignature),
            Encoding.UTF8.GetBytes(signature)))
        {
            context.Result = new UnauthorizedObjectResult("Invalid signature");
            return;
        }

        // 🔹 Step 7: Validate timestamp (anti-replay)
        var requestTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(timestamp));
        var now = DateTimeOffset.UtcNow;

        if (Math.Abs((now - requestTime).TotalMinutes) > 5)
        {
            context.Result = new UnauthorizedObjectResult("Request expired");
            return;
        }

        // 🔹 Step 8: Continue to controller
        await next();
    }

    private string GenerateHmac(string secret, string data)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        return Convert.ToBase64String(hash);
    }
}