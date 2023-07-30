namespace educational_platform_api.ErrorMessages
{
    public static class ProfileErrorMessages
    {
        // TODO: DO WE NEED ERROR MESSAGES? FORMAT? AUTO FIELD FORMATING?

        // Id

        // KeycloakId
        public const string KeycloakIdIsNull = "Keycloak id is null!";
        public const string KeycloakIdIsEmpty = "Keycloak id is empty!";
        public const string KeycloakIdIncorrectLength = "Keycloak id size is incorrect!";

        // FirstName
        public const string FirstNameIsNull = "First name is null!";
        public const string FirstNameIsEmpty = "First name is empty!";
        public const string FirstNameIncorrectLength = "First name length is incorrect! " +
            "It should be from 3 to 32 characters!";

        // LastName
        public const string LastNameIsNull = "Last name is null!";
        public const string LastNameIsEmpty = "Last name is empty!";
        public const string LastNameIncorrectLength = "Last name length is incorrect! " +
            "It should be from 3 to 32 characters!";

        // Surname
        public const string SurnameIsNull = "Surname is null!";
        public const string SurnameIsEmpty = "Surname is empty!";
        public const string SurnameIncorrectLength = "Surname length is incorrect! " +
            "It should be from 3 to 32 characters!";

        // Birthday
        public const string BirthdayIsNull = "Birthday is null!";
        public const string BirthdayIncorrectDateFormat = "Birthday date format is incorrect";

        // ContactEmail
        public const string ContactEmailIsNull = "Profile email is null!";

        // ContactPhone
        public const string ContactPhoneIsNull = "Profile contact phone is null!";

        // Type
        public const string TypeIsNull = "Profile type is null!";

        // IsActive
    }
}
