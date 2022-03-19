using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace PlaneSite
{
    class PlaneDAO
    {
        MyDBDataContext db = new MyDBDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
    //    String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public List<Plane> SelectAll()
        {

            List<Plane> planes = db.Planes.ToList();
            return planes;
         
        }
        public List<Plane> SelectByKeyword(String keyword)
        {
            List<Plane> planes = db.Planes.Where(b => b.Name.Contains(keyword)).ToList();
            return planes;

        }

        public Plane SelectById(int Id)
        {
            Plane plane = db.Planes.SingleOrDefault(b => b.Id == Id);
            return plane;
        }

        public bool Insert(Plane newPlane)
        {
            try
            {
                db.Planes.InsertOnSubmit(newPlane);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }

        }

        public bool Delete(int Id)
        {
            Plane dbPlane = db.Planes.SingleOrDefault(b => b.Id == Id);
            if(dbPlane != null)
            {
                try
                {
                    db.Planes.DeleteOnSubmit(dbPlane);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
         
        }

        public bool Update(Plane newPlane)
        {
            Plane dbPlane = db.Planes.SingleOrDefault(b => b.Id == newPlane.Id);
            if(dbPlane != null)
            {
                try
                {
                    dbPlane.Brand = newPlane.Brand;
                    dbPlane.Name = newPlane.Name;
                    dbPlane.Price = newPlane.Price;
                    dbPlane.Size = newPlane.Size;
                    db.SubmitChanges();
                    return true;

                }
                catch { return false; }
            }
            return false;

        }

    }
}


    

