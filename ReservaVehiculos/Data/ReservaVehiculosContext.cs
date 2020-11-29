using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservaVehiculos.Models;

namespace ReservaVehiculos.Data
{
    public class ReservaVehiculosContext : DbContext
    {
        public ReservaVehiculosContext (DbContextOptions<ReservaVehiculosContext> options)
            : base(options)
        {
        }

        public DbSet<ReservaVehiculos.Models.Reserva> Reserva { get; set; }
    }
}
