namespace ProfileAuthorization
{
    public class Policy
    {
        public List<Permission> Requierements = new();
        public List<AssertionPredicate> Assertions = new();
        public HashSet<PermissionLevel> VerificationLevels = new();
    }
}
