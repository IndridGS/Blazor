using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Data
{
    public class Persona
    {
        public int Id { get; set; }
        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Lugar { get; set; }

        public Vehiculo Vehiculo { get; set; }
    }
}
