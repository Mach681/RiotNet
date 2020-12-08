using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Status of incidents, maintenances and other things related to the overall status of Riot's services
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Gets or sets the Status ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Current maintenance status.  This should equal one of the <see cref="MaintenanceStatusItem"/> values.
        /// </summary>
        [JsonProperty("maintenance_status")]
        public string MaintenanceStatus { get; set; }

        /// <summary>
        /// Severity of the incident.  This should equal one of the <see cref="IncidentSeverityItem"/> values.
        /// </summary>
        [JsonProperty("incident_severity")]
        public string IncidentSeverity { get; set; }

        /// <summary>
        /// List of content DTOs holding the title of the incident, update, maintenance, etc.
        /// </summary>
        public List<ContentDTO> Titles { get; set; }

        /// <summary>
        /// List of content DTOs holding the updates of the incident, update, maintenance, etc.
        /// </summary>
        public List<ContentDTO> Updates { get; set; }

        /// <summary>
        /// Gets or sets the time the status update was created in UTC
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
        
        /// <summary>
        /// Platforms that are relevant to the status.  These should equal one or more of the <see cref="Platform"/> values.
        /// </summary>
        public List<string> Platforms { get; set; }
    }
}
