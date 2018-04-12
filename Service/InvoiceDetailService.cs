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
         bool Update(int id);
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

                var id = model.ProductId;
                var quantity = model.Quantity;

                (from p in _costumerDbContext.Product
                 where p.ProductId == id
                 select p).ToList().ForEach(x => x.Quantity = (x.Quantity - quantity));

                _costumerDbContext.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool  Update(int id )
        {
            try
            {
                var originalModel = _costumerDbContext.InvoiceDetail.Single(x =>
                x.InvoiceId == 0
                );
               
                originalModel.InvoiceId = id;
                
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
                var result = _costumerDbContext.InvoiceDetail.Single(x => x.InvoiceDetailId == id);
                var inventario = _costumerDbContext.Product.Single(x => x.ProductId == result.ProductId);

                inventario.Quantity = (inventario.Quantity + result.Quantity);
                _costumerDbContext.InvoiceDetail.Remove(_costumerDbContext.InvoiceDetail.Find(id));
               // _costumerDbContext.Entry(new InvoiceDetail { result.InvoiceDetailId = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
