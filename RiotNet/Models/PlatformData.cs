using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Platform status data.
    /// </summary>
    public class PlatformData
    {
        /// <summary>
        /// Gets or sets the PlatformData ID.  This should equal one of the <see cref="PlatformId"/> values.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the platform.  ie: North America
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of detailed information by locale.  The items in this list should match the <see cref="Locale"/> list.
        /// </summary>
        public List<string> Locales { get; set; }

        /// <summary>
        /// List of maintenances being performed
        /// </summary>
        public List<Status> Maintenances { get; set; }

        /// <summary>
        /// List of active incidents
        /// </summary>
        public List<Status> Incidents { get; set; }
    }
}
