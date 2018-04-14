using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ICostumerService
    {
         IEnumerable<Costumer> GetAll();
         bool Add(Costumer model);
         bool Delete(int id);
         bool Update(Costumer model);
         Costumer Get(int id);
         
    }

    public class CostumerService: ICostumerService
    {
        private readonly FactVentoryDbContext _costumerDbContext;

        public CostumerService(
            FactVentoryDbContext costumerDbContext
            )
        {
            _costumerDbContext = costumerDbContext;
        }

        public IEnumerable<Costumer> GetAll()
        {
            var result = new List<Costumer>();

            try
            {
                result = _costumerDbContext.Costumer.ToList();
            }
            catch (System.Exception)
            {
               
            }
            return result;
        }

        public Costumer Get(int id )
        {
            var result = new Costumer();

            try
            {
                result = _costumerDbContext.Costumer.Single(x => x.CostumerId == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(Costumer model)
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

        public bool Update(Costumer model)
        {
            try
            {
                var originalModel = _costumerDbContext.Costumer.Single(x =>
                x.CostumerId == model.CostumerId
                );
                originalModel.FullName = model.FullName;
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
                _costumerDbContext.Entry(new Costumer {CostumerId = id}).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
