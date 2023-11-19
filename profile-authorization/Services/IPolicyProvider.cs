namespace ProfileAuthorization
{
    public interface IPolicyProvider
    {
        public Policy GetPolicy(string policyName);
    }
}
