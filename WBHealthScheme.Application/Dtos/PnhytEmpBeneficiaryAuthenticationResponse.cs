namespace WBHealthScheme.Application.Dtos
{
    public class PnhytEmpBeneficiaryAuthenticationResponse
    {
       public string ApplicationId { get; set; }
        public string IosmsId { get; set; }
        public string BenId { get; set; }
        public string BenName { get; set; }
        public string Age { get; set; }
        public string? IdNo { get; set; }
        public string Relation { get; set; }
        public string RegistrationStatus { get; set; }
        public string WardName { get; set; }
        public string WardTmc { get; set; }
        public string WardGpb { get; set; }
        public string EffectDate { get; set; }      
    }

}