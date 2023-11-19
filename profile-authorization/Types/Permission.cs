namespace ProfileAuthorization
{
    public class Permission
    {
        public PermissionLevel Level { get; set; }
        public string ShortName { get; set; }

        public Permission(PermissionLevel level, string shortName)
        {
            Level = level;
            ShortName = shortName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Permission other)
                return false;

            if (ReferenceEquals(obj, this))
                return true;

            return Level == other.Level && ShortName == other.ShortName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Level, ShortName);
        }
    }
}
