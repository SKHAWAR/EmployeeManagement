using Business_Object_Layer_BOL_;
using Data_Access_Layer_DAL_;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer
{
    public interface ILoginBs
    {
        IEnumerable<Login> GetAll();
        Login GetById(int id);

        bool Insert(Login obj);
        bool Update(Login obj);
        bool Delete(int id);
        bool IsSerValid(string username, string password);


    }
    public class LoginBs : ILoginBs
    {
        public readonly ILoginDb loginDb;
        public LoginBs(ILoginDb _loginDb)
        {
            loginDb = _loginDb;
        }
        public IEnumerable<Login> GetAll()
        {
            return loginDb.GetAll();
        }
        public Login GetById(int obj)
        {
           return loginDb.GetById(obj);
        }
        public bool Insert(Login obj)
        {
            loginDb.Insert(obj);
            return true;
        }
        public bool Update(Login obj)
        {
             loginDb.Update(obj);
            return true;
        }
        public bool Delete(int id)
        {
            loginDb.Delete(id);
            return true;
        }
        public bool IsSerValid(string username, string password)
        {
            return loginDb.IsSerValid(username,password);
        }
    }
}
