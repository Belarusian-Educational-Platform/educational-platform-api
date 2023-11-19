namespace ProfileAuthorization
{
    public interface IPolicyVerifier
    {
        public bool Verify(Policy policy, VerificationOptions verificationOptions);
    }
}
