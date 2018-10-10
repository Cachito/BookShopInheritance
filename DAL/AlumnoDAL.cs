using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;

namespace DAL
{
    public class AlumnoDAL
    {
        static int mId;
        private static int ProximoId()
        {
            if (mId == 0)
                mId = (new DAO()).ObtenerUltimoId("Alumno");
            mId += 1;
            return mId;
        }

        public static int Guardar(Alumno pAlumno)
        {
            if (pAlumno.Id == 0)
            {
                pAlumno.Id = ProximoId();
                string mCommandText = "INSERT INTO Alumno (Alumno_Id, Alumno_Legajo, Alumno_AnioIngreso, Alumno_PersonaId) VALUES (" + pAlumno.Id + ", '" + pAlumno.Legajo + "', " + pAlumno.AnioIngreso + "," + pAlumno.PersonaId + ")";
                DAO mDao = new DAO();
                return mDao.ExecuteNonQuery(mCommandText);
            }
            else
            {
                string mCommandText = "UPDATE Alumno SET Alumno_Legajo = '" + pAlumno.Legajo + "',Alumno_AnioIngreso = " + pAlumno.AnioIngreso + ", Alumno_PersonaId = " + pAlumno.PersonaId + " WHERE Alumno_Id = " + pAlumno.Id;
                DAO mDao = new DAO();
                return mDao.ExecuteNonQuery(mCommandText);
            }

        }

        public static int Eliminar(Alumno pAlumno)
        {
            string mCommandText = "DELETE Alumno WHERE Alumno_Id = " + pAlumno.Id;
            DAO mDao = new DAO();
            return mDao.ExecuteNonQuery(mCommandText);
        }

        public static Alumno Obtener(int pId)
        {
            string mCommandText = "SELECT Persona_Id, Persona_Nombre, Persona_Apellido, Persona_Documento, Alumno_Legajo, Alumno_AnioIngreso, Alumno_PersonaId, Alumno_Id FROM Persona INNER JOIN Alumno ON Persona_Id = Alumno_PersonaId WHERE Alumno_Id = " + pId;

            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                Alumno mAlumno = new Alumno(pId);
                ValorizarEntidad(mAlumno, mDs.Tables[0].Rows[0]);
                return mAlumno;
            }
            else
            {
                return null;
            }

        }

        public static List<Alumno> Listar()
        {
            string mCommandText = "SELECT Persona_Id, Persona_Nombre, Persona_Apellido, Persona_Documento, Alumno_Legajo, Alumno_AnioIngreso, Alumno_PersonaId, Alumno_Id FROM Persona INNER JOIN Alumno ON Persona_Id = Alumno_PersonaId";

            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);
            List<Alumno> mAlumnos = new List<Alumno>();

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Alumno mPersona = new Alumno();
                    ValorizarEntidad(mPersona, mDr);
                    mAlumnos.Add(mPersona);
                }

            }
            return mAlumnos;
        }

        internal static void ValorizarEntidad(Alumno pAlumno, DataRow pDataRow)
        {
            pAlumno.Id  =  int.Parse ( pDataRow["Alumno_Id"].ToString());
            pAlumno.Legajo = pDataRow["Alumno_Legajo"].ToString();
            pAlumno.AnioIngreso = int.Parse(pDataRow["Alumno_AnioIngreso"].ToString());
            pAlumno.PersonaId = int.Parse(pDataRow["Alumno_PersonaId"].ToString());
            PersonaDAL.ValorizarEntidad(pAlumno, pDataRow);
        }

    }
}
