namespace UtmBuilder.Core.ValueObjects.Exceptions
{
    public partial class InvalidCampaignException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid parameters";

        public InvalidCampaignException(string message = DEFAULT_MESSAGE) : base(message) { }

        public static void ThrowIfNull(string? item, string message = DEFAULT_MESSAGE)
        {
            if (string.IsNullOrEmpty(item))
                throw new InvalidCampaignException(message);
        }
    }
}