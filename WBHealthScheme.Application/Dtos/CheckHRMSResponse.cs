public class CheckHRMSResponse
{
    public string? ApplicationId { get; set; }
    public string? SlrNo { get; set; }
    public DateOnly? Dob { get; set; }
    public string? Status { get; set; }

    public string? Message { get; set; }

    public bool IsSuccess { get; set; }
}

