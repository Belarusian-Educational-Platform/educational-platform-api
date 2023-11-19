namespace api.ErrorMessages
{
    public static class CustomErrorMessages
    {
        public const string PropertyIsNull = "{PropertyName} is null!";
        public const string PropertyIsEmpty = "{PropertyName} is empty!";
        public const string PropertyIsIncorrectLength = "{PropertyName} size is incorrect! " +
            "It should be from {MinLength} to {MaxLength} characters!";
        public const string PropertyIncorrectFormat = "{PropertyName} format is incorrect!";
        public const string IncorrectCoordinatesValue = "{PropertyName} should be greater or equal -180" +
            " and less or equal 180";
    }
}
