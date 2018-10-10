using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class PersonaBL
    {

        public Persona Obtener(int pId)
        {
            return PersonaDAL.Obtener(pId);
        }

        public List<Persona> Listar()
        {
            return PersonaDAL.Listar();
        }

        public int Guardar(Persona pPersona)
        {
            return PersonaDAL.Guardar(pPersona);
        }

        public int Eliminar(Persona pPersona)
        {
            return PersonaDAL.Eliminar(pPersona);
        }
    }
}
