using Microsoft.EntityFrameworkCore;
using PrimerParcial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json;
using System.Threading.Tasks;


namespace PrimerParcial.Service
{

    public class PersonaService
    {
        private readonly ToqueDeQuedaContext _toqueDeQuedaContext;
        public PersonaService(ToqueDeQuedaContext toqueDeQuedaContext)
        {
            _toqueDeQuedaContext = toqueDeQuedaContext;
        }

        public void AgregarPersona(ToqueDeQuedaModel toqueDeQuedaModel)
        {
            Persona persona = toqueDeQuedaModel.Persona;
            persona.Vehiculo = toqueDeQuedaModel.TieneVehiculo ? toqueDeQuedaModel.Vehiculo : null;

            _toqueDeQuedaContext.Add(persona);
            _toqueDeQuedaContext.SaveChanges();
        }

        public List<Persona> GetPersona()
        {
            var Personas = _toqueDeQuedaContext.Personas.Include(p => p.Vehiculo).AsNoTracking().ToList();
            return Personas;
        }

        public async Task<PersonaApiViewModel> GetPersonaFromApi(string url)
        {
            HttpClient client = new HttpClient();

            PersonaApiViewModel persona = null;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                persona = JsonSerializer.Deserialize<PersonaApiViewModel>(data);
            }
            return persona;
        }
        public void EliminarPersonas(int id) 
        {
            Persona persona = _toqueDeQuedaContext.Personas.Include(p => p.Vehiculo).FirstOrDefault(p => p.Id == id);
            if (persona != null)
            {
                _toqueDeQuedaContext.Remove(persona);
                _toqueDeQuedaContext.SaveChanges();
            }
        }
    }


}
