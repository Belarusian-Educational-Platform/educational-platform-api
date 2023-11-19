namespace ProfileAuthorization
{
    public class PolicyBuilder
    {
        List<Permission> Requirements = new();

        List<AssertionPredicate> Assertions = new();

        HashSet<PermissionLevel> VerificationLevels = new();

        private bool SaveRequiredInformation(Permission requirement)
        {
            VerificationLevels.Add(requirement.Level);
            return true;
        }

        public void AddRequirements(params Permission[] requirements)
        {
            foreach (var requirement in requirements)
            {
                SaveRequiredInformation(requirement);
                Requirements.Add(requirement);
            }
        }

        public void RequireAssertion(AssertionPredicate assertion)
        {
            assertion(SaveRequiredInformation);
            Assertions.Add(assertion);
        }

        public Policy Build()
        {
            var policy = new Policy
            {
                Requierements = Requirements,
                Assertions = Assertions,
                VerificationLevels = VerificationLevels
            };
            
            return policy;
        }
    }
}
