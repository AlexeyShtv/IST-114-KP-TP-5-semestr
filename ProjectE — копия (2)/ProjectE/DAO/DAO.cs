using ProjectE.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectE.DAO
{
    public class DAO<T> where T : class
    {
        ProjectEDataContext db = new ProjectEDataContext();

        public void init()
        {
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            else
            {
                db.DeleteDatabase(); 
            }      
        }


        public IEnumerable<T> Select(Func<T, bool> predicate)
        {
            return (db.GetTable<T>().Where(predicate));
        }

        public IEnumerable<T> Select()
        {
            return (db.GetTable<T>());
        }

        public T Single(Func<T, bool> predicate)
        {
            return (db.GetTable<T>().SingleOrDefault(predicate));
        }

        public void Insert(T obj)
        {
            db.GetTable<T>().InsertOnSubmit(obj);
            Submit();
        }

        public void Insert(IEnumerable<T> obj)
        {
            db.GetTable<T>().InsertAllOnSubmit(obj);
            Submit();
        }

        public void Delete(T obj)
        {
            db.GetTable<T>().DeleteOnSubmit(obj);
            Submit();
        }

        public void Submit()
        {
            db.SubmitChanges();
        }
    }
}