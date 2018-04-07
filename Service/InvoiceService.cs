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
          
              result = _costumerDbContext.Invoice.ToList();

            }
            catch (System.Exception)
            {
               
            }
            return result;
        }



        public Invoice Get(int id)
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

        /* = (from costumer in _costumerDbContext.Costumer
                        where !_costumerDbContext.Invoice.Any(i =>i.CostumerId == costumer.CostumerId)
                        select costumer.FullName ).ToList()*/

        /* var invoices = _costumerDbContext.Invoice
                                  .Join(_costumerDbContext.Costumer,
                                  inv => inv.CostumerId,
                                  cost => cost.CostumerId,
                                  (inv, cost) => new { Inv = inv, Cost = cost.FullName })
                                  .Where(inv => inv.Inv.CostumerId == id);*/


        /*
              List < Invoice > =_costumerDbContext.Invoice
                                       .Join(_costumerDbContext.Costumer,
                                        inv => inv.CostumerId,
                                        cost => cost.CostumerId,
                                        (inv, cost) => new { Cost = cost.FullName, Inv = inv })
                                        .Where(invAndCost => invAndCost.Inv.InvoiceId == id);*/

        /*   var invoices = _costumerDbContext.Invoice.Select(i =>

              new
              {
                  InvoiceId = i.InvoiceId,
                  CostumerId = i.CostumerId,
                  CompanyId = i.CompanyId,
                  TotalAmount = i.TotalAmount,
                  AmountPaid = i.AmountPaid,
                  BalanceDue = i.BalanceDue,
                  Notes = i.Notes,
                  InvoiceDate = i.InvoiceDate,
                  DueDate = i.DueDate,
                  Status = i.Status,
                  Costumer = i.Costumer.FullName,
                  Company = i.Company,

              }).Where(i => i.InvoiceId == id).ToList(); */






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
                originalModel.CompanyId = model.CompanyId;
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
