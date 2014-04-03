using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Data;

namespace HS_Aquiles_ERP.Web_Services
{
    /// <summary>
    /// Summary description for WS_Intranet
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Intranet : System.Web.Services.WebService
    {
        #region Globales
        readonly string conexionSI = HS_Aquiles_ERP.Properties.Settings.Default.ConexionERP;
        HSCRUD crud = new HSCRUD();

        #endregion
        

        #region Systems

        const string Systems = "Intranet.Systems";

        [WebMethod]
        public void CreateSystems(string nombre, string descripcion)
        {
            try
            {
                string[] fields = { "nombre", "descripcion", "eliminado" };
                object[] values = { nombre, descripcion, false };
                crud.Insert(Systems, fields, values, conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void UpdateSystems(string nombre, string descripcion, int id)
        {
            try
            {
                string[] fields = { "nombre", "descripcion" };
                object[] values = { nombre, descripcion };
                crud.Update(Systems, fields, values, "id = " + id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void DeleteSystems(string condition)
        {
            try
            {
                string[] fields = { "eliminado" };
                object[] values = { true };
                crud.Update(Systems, fields, values, condition, conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetAllSistemas()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT s.id,  \n"
                    + "	s.nombre,  \n"
                    + "	s.descripcion,  \n"
                    + "	s.eliminado \n"
                    + "FROM configuracion.Sistemas s";
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetSistemasByVal(int Id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT s.id,  \n"
                    + "	s.nombre,  \n"
                    + "	s.descripcion,  \n"
                    + "	s.eliminado \n"
                    + "FROM configuracion.Sistemas s \n"
                    + "WHERE s.id = " + Id.ToString();
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
        


    }
}
