using Business_Object_Layer_BOL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access_Layer_DAL_
{
    public interface ILoginDb
    {
        IEnumerable<Login> GetAll();
        Login GetById(int id);

        bool Insert(Login obj);
        bool Update(Login obj);
        bool Delete(int id);
        bool IsSerValid(string username, string password);

    }
    public class LoginDb : ILoginDb
    {
        private readonly EMDbContext EMDbContext;
        public LoginDb(EMDbContext _EMDbContext)
        {
            EMDbContext = _EMDbContext;
        }
        public IEnumerable<Login> GetAll()
        {
            return EMDbContext.Login;
        }
        public Login GetById(int obj)
        {
            var LoginUser = EMDbContext.Login.Find(obj);
            return LoginUser;
        }
        public bool Insert(Login obj)
        {
            EMDbContext.Login.Add(obj);
            EMDbContext.SaveChanges();
            return true;
        }
        public bool Update(Login obj)
        {
            EMDbContext.Login.Update(obj);
            EMDbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var record = EMDbContext.Login.Find(id);
            EMDbContext.Login.Remove(record);
            EMDbContext.SaveChanges();
            return true;
        }

        public bool IsSerValid(string username, string password)
        {
           bool IsValid = false;
          var result=  EMDbContext.Login.FirstOrDefault(x=> x.UserName==username && x.Password==password);
            if (result!=null )
            {
                IsValid = true;
            }
            return IsValid;
        }
    }
}
