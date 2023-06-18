using educational_platform_api.Models;

namespace educational_platform_api.Queries
{
    public class Query
    {
        public Group GetGroup()
        {
            return new Group { 
                Id = 0,
                Name = "Hello"
            };
        }
    }
}
