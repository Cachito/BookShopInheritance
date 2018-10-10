using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class AlumnoBL : PersonaBL
    {

        public new Alumno Obtener(int pId)
        {
            return AlumnoDAL.Obtener(pId);
        }

        public new List<Alumno> Listar()
        {
            return AlumnoDAL.Listar();
        }

        public int Guardar(Alumno pAlumno)
        {
            base.Guardar(pAlumno);
            pAlumno.PersonaId = ((Persona)pAlumno).Id;
            return AlumnoDAL.Guardar(pAlumno);
        }

        public int Eliminar(Alumno pAlumno)
        {
            AlumnoDAL.Eliminar(pAlumno);
            return base.Eliminar(pAlumno);
        }
    }
}
