using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaVehiculos.Models
{
    public class Reserva
    {
        public int Reservaid { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(50)]
        [Display(Name = "Nombre", Prompt ="Su Nombre Completo")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "El formato de email es incorrecto")]
        [Display(Name = "Correo electrónico" , Prompt ="ejemplo@ejemplo.org")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "La fecha pickup es obligatoria")]
        [DataType(DataType.DateTime,ErrorMessage = "El formato de fecha es incorecto")]
        [Display(Name = "Fecha Pickup", Prompt = "29/11/2020 10:00:am")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}}", ApplyFormatInEditMode = true)]
        public DateTime FechaPickup { get; set; }
        [Required(ErrorMessage = "El lugar de pickup es obligatorio")]
        [Display(Name = "Lugar Pickup", Prompt = "Ciudad de recogida")]
        public string LugarPickup { get; set; }
        [Required(ErrorMessage = "La fecha dropoff es obligatoria")]
        [DataType(DataType.DateTime,ErrorMessage = "El formato de fecha es incorecto")]
        [Display(Name = "Fecha Dropoff", Prompt = "29/11/2020 10:00:am")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public DateTime FechaDropoff { get; set; }
        [Required(ErrorMessage = "El lugar de dropoff es obligatorio")]
        [Display(Name = "Lugar Dropoff", Prompt = "Ciudad de entrega")]
        public string LugarDropoff { get; set; }
        [Required(ErrorMessage = "La marca es obligatoria")]
        [Display(Name = "Marca", Prompt = "Renault, Mazda, Subaru, Mercedez Benz...")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El modelo es obligatorio")]
        [Range(1900,2020, ErrorMessage ="El rango esperado es 1900 y 2020")]
        [Display(Name = "Modelo", Prompt = "2010")]
        public int Modelo { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]        
        [Display(Name = "Precio", Prompt = "250000")]
        [DataType(DataType.Currency)]
        public double Precio { get; set; }

    }
}
