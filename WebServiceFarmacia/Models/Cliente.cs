using System;
using System.Collections.Generic;

namespace WebServiceFarmacia.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNac { get; set; }
    }
}
