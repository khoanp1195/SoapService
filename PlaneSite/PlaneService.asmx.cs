using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PlaneSite
{
    /// <summary>
    /// Summary description for PlaneService
    /// </summary>
    [WebService(Namespace = "http://phuongkhoaaa.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PlaneService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Plane> GetAll()
        {
            List<Plane> planes = new PlaneDAO().SelectAll();
            return planes;
        }
        [WebMethod]
        public List<Plane> Search(String keyword)
        {
            List<Plane> planes = new PlaneDAO().SelectByKeyword(keyword);
            return planes;
        }
        [WebMethod]
        public Plane GetDetails(int Id)
        {
            Plane plane = new PlaneDAO().SelectById(Id);
            return plane;
        }

        [WebMethod]
        public bool Delete(int Id)
        {
            bool result = new PlaneDAO().Delete(Id);
            return result;

        }
        [WebMethod]
        public bool Update(Plane newPlane)
        {
            bool result = new PlaneDAO().Update(newPlane);
            return result;
        }
        [WebMethod]
        public bool AddNew(Plane newPlane)
        {
            bool result = new PlaneDAO().Insert(newPlane);
            return result;
        }

    }
}
