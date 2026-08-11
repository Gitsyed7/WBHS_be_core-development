public class SavePersonalInformationRequest
{
    // Registration identifiers
    public string? SlrNo { get; set; }
    public string? AppId { get; set; }
    public string? HrmsId { get; set; }

    // Personal Information
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Dob { get; set; }
    public string? MaritalStatus { get; set; }
    public string? Gender { get; set; }
    public string? DistrictCode { get; set; }
    public string? Address { get; set; }

    // Identity / Contact
    public string? IdentityProofNo { get; set; }
    public string? AadhaarNo { get; set; }
    public string? MobileNo { get; set; }
    public string? EmailId { get; set; }
    public string? ResidencePhoneNo { get; set; }

    // Retirement
    public string? RetirementAge { get; set; }

    // Bank Information
    public string? BankIfsc { get; set; }
    public string? BankName { get; set; }
    public string? BankBranchName { get; set; }
    public string? BankMicr { get; set; }
    public string? BankAccountNo { get; set; }

    // Identity Proof Type
    public string? IdentityProofType { get; set; }
}