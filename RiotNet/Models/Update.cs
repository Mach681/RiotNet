using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents updates
    /// </summary>
    public class Update
    {
        /// <summary>
        /// Gets or sets the Update ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the update Author ID
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets whether this update is to be published.
        /// </summary>
        public bool Publish { get; set; }

        /// <summary>
        /// Gets or sets the publish locations. This should equal one of the <see cref="PublishLocation"/> values.
        /// </summary>
        [JsonProperty("publish_locations")]
        public List<string> PublishLocations { get; set; }

        /// <summary>
        /// Translated version of the update message
        /// </summary>
        public List<ContentDTO> Translations { get; set; }

        /// <summary>
        /// Gets or sets the time the update was created in UTC
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the time of the last update in UTC
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
    }
}
