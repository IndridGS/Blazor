using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Data
{
    public class ToqueDeQuedaModel
    {
        public Persona Persona { get; set; } = new Persona();

        public Vehiculo Vehiculo { get; set; } = new Vehiculo();

        public bool TieneVehiculo { get; set; }
    }
}
