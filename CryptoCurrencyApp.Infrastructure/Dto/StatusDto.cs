namespace CryptoCurrencyApp.Infrastructure.Dto
{
    public record StatusDto
    {
        /// <summary>
        /// Gets whether the dto has error.
        /// </summary>
        public bool HasError { get; init; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage { get; init; }

        public StatusDto(bool hasError, string errorMessage)
        {
            HasError = hasError;
            ErrorMessage = errorMessage;
        }

    }
}
