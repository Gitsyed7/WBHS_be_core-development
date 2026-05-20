namespace WBHealthScheme.Application.Dtos
{
    public class ClgBeneficiaryAuthenticationResponse
    {
        public string ApplicationId { get; set; }
        public string HrmsId { get; set; }
        public string SlrNo { get; set; }
        public string BenId { get; set; }
        public string BenName { get; set; }
        public string Age { get; set; }
        public string? IdNo { get; set; }
        public string Relation { get; set; }
        public string RegistrationStatus { get; set; }
        public string WordName { get; set; }
        public string WordTmc { get; set; }
        public string WordGpb { get; set; }
        public string EffectDate { get; set; }        
    }

}