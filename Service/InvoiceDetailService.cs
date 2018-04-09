using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IInvoiceDetailService
    {
         IEnumerable<InvoiceDetail> GetAll();
         bool Add(InvoiceDetail model);
         bool Delete(int id);
         bool Update(InvoiceDetail model);
        IEnumerable<InvoiceDetail> Get(int id);
         
    }

    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly CostumerDbContext _costumerDbContext;

        public InvoiceDetailService(
            CostumerDbContext costumerDbContext
            )
        {
            _costumerDbContext = costumerDbContext;
        }

        public IEnumerable<InvoiceDetail> GetAll()
        {

            var result = new List<InvoiceDetail>();

            try
            {
                
              result = _costumerDbContext.InvoiceDetail.ToList();
               
            }
            catch (System.Exception)
            {
               
            }
            return result;
        }

        public IEnumerable<InvoiceDetail> Get(int id )
        {

            var invoiceDetails = new List<InvoiceDetail>();

            try
            {
                invoiceDetails = _costumerDbContext.InvoiceDetail
                                              .Where(inv => inv.InvoiceId == id)
                                              .ToList();

            }
            catch (System.Exception)
            {

            }
            return invoiceDetails;

        }

        public bool Add(InvoiceDetail model)
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

        public bool Update(InvoiceDetail model)
        {
            try
            {
                var originalModel = _costumerDbContext.InvoiceDetail.Single(x =>
                x.InvoiceDetailId == model.InvoiceDetailId
                );
                originalModel.ProductId = model.ProductId;
                originalModel.Quantity = model.Quantity;
                originalModel.UnitPrice = model.UnitPrice;
                originalModel.Total = model.Total;
                originalModel.InvoiceId = model.InvoiceId;
                
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
                _costumerDbContext.Entry(new InvoiceDetail { InvoiceDetailId = id}).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
