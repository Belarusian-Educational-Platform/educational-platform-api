namespace api.Extensions.EntityFramework
{
    public static class ORMExtention
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
        }
    }
}
