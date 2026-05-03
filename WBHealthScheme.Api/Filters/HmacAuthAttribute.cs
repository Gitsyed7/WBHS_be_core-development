using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Cryptography;
using System.Text;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Application.Services;
using WBHealthScheme.Domain.Entities;

public class HmacAuthAttribute : Attribute, IAsyncActionFilter
{
    private const string API_KEY_HEADER = "x-api-key";
    private const string SIGNATURE_HEADER = "x-signature";
    private const string TIMESTAMP_HEADER = "x-timestamp";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var request = context.HttpContext.Request;

        var apiKey = request.Headers[API_KEY_HEADER].ToString();
        var signature = request.Headers[SIGNATURE_HEADER].ToString();
        var timestamp = request.Headers[TIMESTAMP_HEADER].ToString();

        if (string.IsNullOrEmpty(apiKey) ||
            string.IsNullOrEmpty(signature) ||
            string.IsNullOrEmpty(timestamp))
        {
            context.Result = new UnauthorizedObjectResult("Missing headers");
            return;
        }

        var service = context.HttpContext.RequestServices.GetRequiredService<IApiKeyService>();

       var apiKeyData = await service.GetValidKeyAsync(apiKey, context.HttpContext.Request.Path);

        if (apiKeyData == null)
        {
            context.Result = new UnauthorizedObjectResult("Invalid API Key");
            return;
        }

        var secret = apiKeyData.ApiSecretEncrypted; 

        var data = $"{request.Method}{request.Path}{timestamp}";
        var serverSignature = GenerateHmac(secret, data);

        if (!CryptographicOperations.FixedTimeEquals(
        Encoding.UTF8.GetBytes(serverSignature),
        Encoding.UTF8.GetBytes(signature)))
        {
            context.Result = new UnauthorizedObjectResult("Invalid signature");
            return;
        }

        // Timestamp validation
        var requestTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(timestamp));
        var now = DateTimeOffset.UtcNow;

        if (Math.Abs((now - requestTime).TotalMinutes) > 5)
        {
            context.Result = new UnauthorizedObjectResult("Request expired");
            return;
        }

        await next(); // continue to controller
    }

    private string GenerateHmac(string secret, string data)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        return Convert.ToBase64String(hash);
    }
}