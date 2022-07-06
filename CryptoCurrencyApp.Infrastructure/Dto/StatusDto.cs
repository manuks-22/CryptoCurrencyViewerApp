namespace CryptoCurrencyApp.Infrastructure.Dto
{
    public class StatusDto
    {
        private readonly bool _hasError;

        private readonly string _errorMessage;

        public StatusDto(bool hasError, string errorMessage)
        {
            _hasError = hasError;
            _errorMessage = errorMessage;
        }

        /// <summary>
        /// Gets whether the dto has error.
        /// </summary>
        public bool HasError => _hasError;

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage => _errorMessage;
    }
}
