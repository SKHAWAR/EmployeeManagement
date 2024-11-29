using Business_Object_Layer_BOL_;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer_DAL_
{
    public interface IEmployeeInformationDb
    {
        List<EmployeeInformation> GetAll();
        EmployeeInformation GetById(string id);

        bool Insert(EmployeeInformation obj);
        bool Update(EmployeeInformation obj);
        bool Delete(int id);

    }
    public class EmployeeInformationDb : IEmployeeInformationDb
    {
        private readonly EMDbContext EMDbContext;
        public EmployeeInformationDb(EMDbContext _EMDbContext)
        {
            EMDbContext = _EMDbContext;
        }
        public List<EmployeeInformation> GetAll()
        {
            return EMDbContext.EmployeeInformation.ToList();
        }
        public EmployeeInformation GetById(string obj)
        {
            var EmployeeInformationUser = EMDbContext.EmployeeInformation.Find(obj);
            return EmployeeInformationUser;
        }
        public bool Insert(EmployeeInformation obj)
        {
            EMDbContext.EmployeeInformation.Add(obj);
            EMDbContext.SaveChanges();
            return true;
        }
        public bool Update(EmployeeInformation obj)
        {
            EMDbContext.EmployeeInformation.Update(obj);
            EMDbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var record = EMDbContext.EmployeeInformation.Find(id);
            EMDbContext.EmployeeInformation.Remove(record);
            EMDbContext.SaveChanges();
            return true;
        }

    }
}
