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
        public void CreateSystems(string Name, string Description, string Controller, string Action, string Url, string ImageUrl)
        {
            try
            {
                string[] fields = { "Name", "Description", "Controller", "Action", "Url", "ImageUrl", "Dropped" };
                object[] values = { Name, Description, Controller, Action, Url, ImageUrl, false };
                crud.Insert(Systems, fields, values, conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void UpdateSystems(string Name, string Description, string Controller, string Action, string Url, string ImageUrl, int Id)
        {
            try
            {
                string[] fields = { "Name", "Description", "Controller", "Action", "Url", "ImageUrl" };
                object[] values = { Name, Description, Controller, Action, Url, ImageUrl };
                crud.Update(Systems, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void DeleteSystems(int Id)
        {
            try
            {
                string[] fields = { "Dropped" };
                object[] values = { true };
                crud.Update(Systems, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetAllSystems()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.Systems";
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetSystemsByVal(int Id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.Systems \n"
                    + "WHERE Id = " + Id.ToString();
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region SystemOptions

        const string SystemOptions = "Intranet.SystemOptions";

        [WebMethod]
        public void CreateSystemOptions(int SystemId, int ParentId, string Name, string Description, string Controller, string Action, string Url, string ImageUrl, string Area)
        {
            try
            {
                string[] fields = { "SystemId", "ParentId", "Name", "Description", "Controller", "Action", "Url", "ImageUrl", "Area", "Dropped" };
                object[] values = { SystemId, ParentId, Name, Description, Controller, Action, Url, ImageUrl, Area, false };
                crud.Insert(SystemOptions, fields, values, conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void UpdateSystemOptions(int SystemId, int ParentId, string Name, string Description, string Controller, string Action, string Url, string ImageUrl, string Area, int Id)
        {
            try
            {
                string[] fields = { "SystemId", "ParentId", "Name", "Description", "Controller", "Action", "Url", "ImageUrl", "Area" };
                object[] values = { SystemId, ParentId, Name, Description, Controller, Action, Url, ImageUrl, Area };
                crud.Update(SystemOptions, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void DeleteSystemOptions(int Id)
        {
            try
            {
                string[] fields = { "Dropped" };
                object[] values = { true };
                crud.Update(SystemOptions, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetAllSystemOptions()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.SystemOptions";
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetSystemOptionsByVal(int Id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.SystemOptions \n"
                    + "WHERE Id = " + Id.ToString();
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region Profiles

        const string Profiles = "Intranet.Profiles";

        [WebMethod]
        public void CreateProfiles(string Name, string Description)
        {
            try
            {
                string[] fields = { "Name", "Description", "Dropped" };
                object[] values = { Name, Description, false };
                crud.Insert(Profiles, fields, values, conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void UpdateProfiles(string Name, string Description, int Id)
        {
            try
            {
                string[] fields = { "Name", "Description" };
                object[] values = { Name, Description };
                crud.Update(Profiles, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void DeleteProfiles(int Id)
        {
            try
            {
                string[] fields = { "Dropped" };
                object[] values = { true };
                crud.Update(Profiles, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetAllProfiles()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.Profiles";
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetProfilesByVal(int Id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.Profiles \n"
                    + "WHERE Id = " + Id.ToString();
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region ProfileOptions

        const string ProfileOptions = "Intranet.ProfileOptions";

        [WebMethod]
        public void CreateProfileOptions(int ProfileId, int SystemOptionId)
        {
            try
            {
                string[] fields = { "ProfileId", "SystemOptionId", "Dropped" };
                object[] values = { ProfileId, SystemOptionId, false };
                crud.Insert(ProfileOptions, fields, values, conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void UpdateProfileOptions(int ProfileId, int SystemOptionId, int Id)
        {
            try
            {
                string[] fields = { "ProfileId", "SystemOptionId" };
                object[] values = { ProfileId, SystemOptionId };
                crud.Update(ProfileOptions, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void DeleteProfileOptions(int Id)
        {
            try
            {
                string[] fields = { "Dropped" };
                object[] values = { true };
                crud.Update(ProfileOptions, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetAllProfileOptions()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.ProfileOptions";
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetProfileOptionsByVal(int Id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.ProfileOptions \n"
                    + "WHERE Id = " + Id.ToString();
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region Areas

        const string Areas = "Intranet.Areas";

        [WebMethod]
        public void CreateAreas(string Name, string Description)
        {
            try
            {
                string[] fields = { "Name", "Description", "Dropped" };
                object[] values = { Name, Description, false };
                crud.Insert(Areas, fields, values, conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void UpdateAreas(string Name, string Description, int Id)
        {
            try
            {
                string[] fields = { "Name", "Description" };
                object[] values = { Name, Description };
                crud.Update(Areas, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void DeleteAreas(int Id)
        {
            try
            {
                string[] fields = { "Dropped" };
                object[] values = { true };
                crud.Update(Areas, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetAllAreas()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.Areas";
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetAreasByVal(int Id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.Areas \n"
                    + "WHERE Id = " + Id.ToString();
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region Users

        const string Users = "Intranet.Users";

        [WebMethod]
        public void CreateUsers(int ProfileId, int AreaId, string UserName, string Names, string LastNames, string Password, string Email, bool IsActiveDirectory)
        {
            try
            {
                string[] fields = { "ProfileId", "AreaId", "UserName", "Names", "LastNames", "Password", "Email", "IsActiveDirectory", "Dropped" };
                object[] values = { ProfileId, AreaId, UserName, Names, LastNames, Password, Email, IsActiveDirectory, false };
                crud.Insert(Users, fields, values, conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void UpdateUsers(int ProfileId, int AreaId, string UserName, string Names, string LastNames, string Password, string Email, bool IsActiveDirectory, int Id)
        {
            try
            {
                string[] fields = { "ProfileId", "AreaId", "UserName", "Names", "LastNames", "Password", "Email", "IsActiveDirectory" };
                object[] values = { ProfileId, AreaId, UserName, Names, LastNames, Password, Email, IsActiveDirectory };
                crud.Update(Users, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public void DeleteUsers(int Id)
        {
            try
            {
                string[] fields = { "Dropped" };
                object[] values = { true };
                crud.Update(Users, fields, values, "Id = " + Id.ToString(), conexionSI);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetAllUsers()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.Users";
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetUsersByVal(int Id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Intranet.Users \n"
                    + "WHERE Id = " + Id.ToString();
                dt = crud.ExecDT(query, conexionSI);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetSystemOptionsByUser(int UserId, int SystemId)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT o.Id,  \n"
                   + "	o.ParentId,  \n"
                   + "	o.Name,  \n"
                   + "	o.[Url],  \n"
                   + "	o.ImageUrl \n"
                   + "FROM Intranet.GetSystemOptionsByUser(" + UserId.ToString() + ", " + SystemId.ToString() + ") o";
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
