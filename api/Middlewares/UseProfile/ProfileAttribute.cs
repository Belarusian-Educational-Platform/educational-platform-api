namespace api.Middlewares.UseProfile
{
    public class ProfileAttribute : GlobalStateAttribute
    {
        public ProfileAttribute() : base(ProfileMiddleware.PROFILE_CONTEXT_DATA_KEY) { }
    }
}
