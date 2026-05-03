using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBHealthScheme.Domain.Entities;
public class ApiKey
{
    public int Id { get; set; }
    public string EndpointUrl { get; set; }
    public string AuthHeaderName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string ApiKeyValue { get; set; }
    public string ApiSecretEncrypted { get; set; }
}