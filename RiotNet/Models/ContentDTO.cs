namespace RiotNet.Models
{
    /// <summary>
    /// Content of messages (updates, incidents, etc.) from Riot
    /// </summary>
    public class ContentDTO
    {
        /// <summary>
        /// Gets or sets the locale of the message content
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the detailed content of the message
        /// </summary>
        public string Content { get; set; }
    }
}
