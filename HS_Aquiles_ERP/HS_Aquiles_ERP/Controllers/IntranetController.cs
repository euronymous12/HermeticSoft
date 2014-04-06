using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Data;
using DevExpress.Web.ASPxTreeView;

namespace HS_Aquiles_ERP.Controllers
{
    public class IntranetController : Controller
    {
        public ActionResult IntranetMenu()
        {
            Web_Services.WS_Intranet ws = new Web_Services.WS_Intranet();
            DataTable sis = new DataTable();
            sis = ws.GetSystemOptionsByUser(1, 1);
            return View(sis);
        }
        public static void CreateTreeViewNodesRecursive(DataTable model, MVCxTreeViewNodeCollection nodesCollection, Int32 parentID)
        {
            try
            {
                var rows = model.Select("[ParentId] = " + parentID);

                foreach (DataRow row in rows)
                {
                    MVCxTreeViewNode node = nodesCollection.Add(row["Name"].ToString(), row["Id"].ToString(), row["ImageUrl"].ToString(), row["Url"].ToString());
                    CreateTreeViewNodesRecursive(model, node.Nodes, Convert.ToInt32(row["Id"]));
                }
            }
            catch (Exception)
            {
                
            }            
        }

    }
}
