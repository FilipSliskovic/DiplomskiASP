using KaficiProjekat.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.DataAccess.Configurations
{
    internal class ReservationConfiguration : EntityConfiguration<Reservation>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Reservation> builder)
        {

        }
    }
}
