using Business_Object_Layer_BOL_;
using Data_Access_Layer_DAL_;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer
{
    public interface IEmployeeInformationBs
    {
        List<EmployeeInformation> GetAll();
        EmployeeInformation GetById(string id);

        bool Insert(EmployeeInformation obj);
        bool Update(EmployeeInformation obj);
        bool Delete(int id);

    }
    public class EmployeeInformationBs : IEmployeeInformationBs
    {
        private readonly IEmployeeInformationDb EmployeeInformationDb;
        public EmployeeInformationBs(IEmployeeInformationDb _EmployeeInformationDb)
        {
            EmployeeInformationDb = _EmployeeInformationDb;
        }
        public List<EmployeeInformation> GetAll()
        {
            return EmployeeInformationDb.GetAll();
        }
        public EmployeeInformation GetById(string obj)
        {
            return EmployeeInformationDb.GetById(obj);
        }
        public bool Insert(EmployeeInformation obj)
        {
            EmployeeInformationDb.Insert(obj);
            return true;
        }
        public bool Update(EmployeeInformation obj)
        {
            EmployeeInformationDb.Update(obj);
            return true;
        }
        public bool Delete(int id)
        {
            EmployeeInformationDb.Delete(id);
            return true;
        }
    }
}
