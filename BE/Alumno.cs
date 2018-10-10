using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Alumno : Persona
    {

        public Alumno()
        { }

        public Alumno(int pId)
        {
            Id = pId;
        }

        public new int Id { get; set;}
        public string Legajo { get; set; }
        public int AnioIngreso { get; set; }
        public int PersonaId { get; set; }
    }
}
