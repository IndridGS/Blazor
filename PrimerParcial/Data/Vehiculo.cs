using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Data
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public String Placa { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Color { get; set; }
        public String Descripcion { get; set; }


        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

    }
}
