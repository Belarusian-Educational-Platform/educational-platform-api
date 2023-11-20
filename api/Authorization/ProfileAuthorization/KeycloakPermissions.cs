namespace ProfileAuthorization.Data {
    public static class KeycloakPermissions {
        public static readonly Permission ADMIN = new(PermissionLevel.KEYCLOAK_ROLE, "Admin");
    }
}
