using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ICompanyService
    {
         IEnumerable<Company> GetAll();
         bool Add(Company model);
         bool Delete(int id);
         bool Update(Company model);
        Company Get(int id);
         
    }

    public class CompanyService : ICompanyService
    {
        private readonly FactVentoryDbContext _costumerDbContext;

        public CompanyService(
            FactVentoryDbContext costumerDbContext
            )
        {
            _costumerDbContext = costumerDbContext;
        }

        public IEnumerable<Company> GetAll()
        {
            var result = new List<Company>();

            try
            {
                result = _costumerDbContext.Company.ToList();
            }
            catch (System.Exception)
            {
               
            }
            return result;
        }

        public Company Get(int id )
        {
            var result = new Company();

            try
            {
                result = _costumerDbContext.Company.Single(x => x.CompanyId == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(Company model)
        {
            try
            {
                _costumerDbContext.Add(model);
                _costumerDbContext.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Company model)
        {
            try
            {
                var originalModel = _costumerDbContext.Company.Single(x =>
                x.CompanyId == model.CompanyId
                );
                originalModel.CompanyName = model.CompanyName;
                originalModel.PhoneNumber = model.PhoneNumber;
                originalModel.Email = model.Email;
                originalModel.Address = model.Address;

                _costumerDbContext.Update(originalModel);
                _costumerDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _costumerDbContext.Entry(new Company { CompanyId = id}).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _costumerDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

    }
}
