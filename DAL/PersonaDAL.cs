using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;

namespace DAL
{
    public class PersonaDAL
    {

        static int mId;
        private static int ProximoId()
        {
            if (mId == 0)
                mId = (new DAO()).ObtenerUltimoId("Persona");
            mId += 1;
            return mId;
        }

        public static int Guardar(Persona pPersona)
        {
            if (pPersona.Id == 0)
            {
                pPersona.Id = ProximoId();
                string mCommandText = "INSERT INTO Persona (Persona_Id, Persona_Nombre, Persona_Apellido, Persona_Documento) VALUES (" + pPersona.Id + ", '" + pPersona.Nombre + "', '" + pPersona.Apellido + "', '" + pPersona.Documento + "')";
                DAO mDao = new DAO();
                return mDao.ExecuteNonQuery(mCommandText);
            }
            else
            {
                string mCommandText = "UPDATE Persona SET Persona_Nombre = '" + pPersona.Nombre + "', Persona_Apellido = '" + pPersona.Apellido + "', Persona_Documento = '" + pPersona.Documento + "' WHERE Persona_Id = " + pPersona.Id;
                DAO mDao = new DAO();
                return mDao.ExecuteNonQuery(mCommandText);
            }

        }

        public static int Eliminar(Persona pPersona)
        {
            string mCommandText = "DELETE Persona WHERE Persona_Id = " + pPersona.Id;
            DAO mDao = new DAO();
            return mDao.ExecuteNonQuery(mCommandText);
        }

        public static Persona Obtener(int pId)
        {
            string mCommandText = "SELECT Persona_Id, Persona_Nombre, Persona_Apellido, Persona_Documento FROM Persona WHERE Persona_Id = " + pId;

            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                Persona mPersona = new Persona(pId);
                ValorizarEntidad(mPersona, mDs.Tables[0].Rows[0]);
                return mPersona;
            }
            else
            {
                return null;
            }

        }

        public static List<Persona> Listar()
        {
            string mCommandText = "SELECT Persona_Id, Persona_Nombre, Persona_Apellido, Persona_Documento FROM Persona";

            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);
            List<Persona> mPersonas = new List<Persona>();

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Persona mPersona = new Persona();
                    ValorizarEntidad(mPersona, mDr);
                    mPersonas.Add(mPersona);
                }

            }
            return mPersonas;
        }

        internal static void ValorizarEntidad(Persona pPersona, DataRow pDataRow)
        {
            pPersona.Nombre = pDataRow["Persona_Nombre"].ToString();
            pPersona.Apellido = pDataRow["Persona_Apellido"].ToString();
            pPersona.Documento = pDataRow["Persona_Documento"].ToString();
            pPersona.Id = int.Parse(pDataRow["Persona_Id"].ToString());
        }

    }
}
