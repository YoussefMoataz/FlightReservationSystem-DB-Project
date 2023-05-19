namespace FlightReservationSystem_DB_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FLIGHT")]
    public partial class FLIGHT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FLIGHTID { get; set; }

        [StringLength(3)]
        public string SOURCE { get; set; }

        [StringLength(3)]
        public string DESTINATION { get; set; }

        public string DEPARTUREDATE { get; set; }

        public string ARRIVALDATE { get; set; }

        public int? AVAILABLESEATS { get; set; }

        public int? AIRCRAFTID { get; set; }

        public int? AIRLINEID { get; set; }
    }
}
