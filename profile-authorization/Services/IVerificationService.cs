namespace ProfileAuthorization {
    public interface IVerificationService {
        public bool Assert(params Permission[] requirements);
        public bool Assert(AssertionPredicate assertion);
        public bool RequireOrganizationCorrespondence(CorrespondsWith corresponsWith, int id);
        public void UseOptions(VerificationOptions options);
    }
}
