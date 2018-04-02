using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IInvoiceService
    {
         IEnumerable<Invoice> GetAll();
         bool Add(Invoice model);
         bool Delete(int id);
         bool Update(Invoice model);
        Invoice Get(int id);
         
    }

    public class InvoiceService : IInvoiceService
    {
        private readonly CostumerDbContext _costumerDbContext;

        public InvoiceService(
            CostumerDbContext costumerDbContext
            )
        {
            _costumerDbContext = costumerDbContext;
        }

        public IEnumerable<Invoice> GetAll()
        {
            var result = new List<Invoice>();
          
            try
            {
                for (int i = 1; i <= 5; i++)
                {

                }


                    DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123);
                    String.Format("{0:MM/dd/yyyy}", dt);  
                
          
                result = _costumerDbContext.Invoice.ToList();

            }
            catch (System.Exception)
            {
               
            }
            return result;
        }

        public Invoice Get(int id )
        {
            var result = new Invoice();

            try
            {
                result = _costumerDbContext.Invoice.Single(x => x.InvoiceId == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(Invoice model)
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

        public bool Update(Invoice model)
        {
            try
            {
                var originalModel = _costumerDbContext.Invoice.Single(x =>
                x.InvoiceId == model.InvoiceId
                );
                originalModel.CostumerId = model.CostumerId;
                originalModel.CompanyId = model.CostumerId;
                originalModel.TotalAmount = model.TotalAmount;
                originalModel.AmountPaid = model.AmountPaid;
                originalModel.BalanceDue = model.BalanceDue;
                originalModel.Notes = model.Notes;
                originalModel.Status = model.Notes;
               
                originalModel.InvoiceDate = model.InvoiceDate;
                originalModel.DueDate = model.DueDate;
                originalModel.Status = model.Notes;
                originalModel.Costumer = model.Costumer;
                originalModel.Company = model.Company;



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
                _costumerDbContext.Entry(new Invoice { InvoiceId = id}).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
