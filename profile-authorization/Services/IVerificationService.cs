namespace ProfileAuthorization {
    public interface IVerificationService {
        public bool Assert(params Permission[] requirements);
        public bool RequireOrganizationCorrespondence<CorrespondsWith>(int id);
        public bool RequireEntityCorrespondence<T>(int id);
        public void UseOptions(VerificationOptions options);
    }
}
