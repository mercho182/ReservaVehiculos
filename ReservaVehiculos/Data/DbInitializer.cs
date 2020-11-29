using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservaVehiculos.Models;

namespace ReservaVehiculos.Data
{
    public class DbInitializer
    {
        public static void Initialize (ReservaVehiculosContext context)
        {
            context.Database.EnsureCreated();

            //Buscar si existen registros en la tabla
            if(context.Reserva.Any())
            {
                return;
            }
            var reservas = new Reserva[]
            {
                new Reserva{NombreCliente="Hernan",Correo="mercho182@gmail.com",FechaPickup=Convert.ToDateTime("20/11/2020"),LugarPickup="Manizales",FechaDropoff=Convert.ToDateTime("25/11/2020"),LugarDropoff="Manizales",Marca="Mazda",Modelo=2010,Precio=250000 },
                new Reserva{NombreCliente="Diana",Correo="diana_3491@gmail.com",FechaPickup=Convert.ToDateTime("15/11/2020"),LugarPickup="Pereira",FechaDropoff=Convert.ToDateTime("23/11/2020"),LugarDropoff="Armenia",Marca="Subaru",Modelo=2005,Precio=660000 }
            };

            foreach (Reserva r in reservas)
            {
                context.Reserva.Add(r);
            }
            context.SaveChanges();
        }
    }
}
