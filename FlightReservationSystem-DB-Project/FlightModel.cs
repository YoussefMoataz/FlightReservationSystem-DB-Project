using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FlightReservationSystem_DB_Project
{
    public partial class FlightModel : DbContext
    {
        public FlightModel()
            : base("name=FlightEntity")
        {
        }

        public virtual DbSet<FLIGHT> FLIGHTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FLIGHT>()
                .Property(e => e.SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<FLIGHT>()
                .Property(e => e.DESTINATION)
                .IsUnicode(false);

            modelBuilder.Entity<FLIGHT>()
                .Property(e => e.DEPARTUREDATE)
                .IsUnicode(false);

            modelBuilder.Entity<FLIGHT>()
                .Property(e => e.ARRIVALDATE)
                .IsUnicode(false);
        }
    }
}
