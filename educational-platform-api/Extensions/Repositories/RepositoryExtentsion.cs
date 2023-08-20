namespace educational_platform_api.Extensions.Repositories
{
    public static class RepositoryExtentsion
    {
        public static void CopyNotNullProperties<T>(T from, T to)
        {
            Type type = typeof(T);
            var properties = type.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);
            foreach (var property in properties)
            {
                var value = property.GetValue(from, null);
                if (value != null)
                {
                    property.SetValue(to, value, null);
                }
            }
        }//TODO: move or rename extension class and folder
    }
}
