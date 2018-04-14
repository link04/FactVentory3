using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        bool Sender(Invoice model);

    }

    public class InvoiceService : IInvoiceService
    {
        private readonly FactVentoryDbContext _costumerDbContext;

        public InvoiceService(
            FactVentoryDbContext costumerDbContext
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

        public bool Add(Invoice model)
        {
            try
            {
                _costumerDbContext.Add(model);
                _costumerDbContext.SaveChanges();

                var id = model.InvoiceId;

                (from d in _costumerDbContext.InvoiceDetail
                 where d.InvoiceId == 0
                 select d).ToList().ForEach(x => x.InvoiceId = id);

                _costumerDbContext.SaveChanges();


            }

            catch (System.Exception)
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

                originalModel.Status = model.Status;
                originalModel.InvoiceDate = model.InvoiceDate;
                originalModel.DueDate = model.DueDate;
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
                _costumerDbContext.Entry(new Invoice { InvoiceId = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _costumerDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Sender(Invoice model)
        {

            var id = model.CostumerId;

           var costumer = _costumerDbContext.Costumer.Single(x => x.CostumerId == id);

            var idMail = costumer.Email;



            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("FactVentory@gmail.com");
                msg.To.Add(idMail);
                msg.Subject = "Correo de Factura.";
                msg.Body =
                    "<div>" +
                        "<h1>Gracias por utlizar nuestros Servicios.</h1>" +
                        "<br>" +
                        "<p> Aqui le hacemos envio de su Factura. " +
                         costumer.FullName + "." +
                         "<br>" +
                        "<p>Esperando Escuchar de usted nuevamente FV.</p>" +
                    "</div>";
                msg.IsBodyHtml = true;
                MailAddress ms = new MailAddress(idMail);

                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 587;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential("FactVentory@gmail.com",  model.Company);
                sc.EnableSsl = true;
                sc.Send(msg);

            }
            catch (System.Exception)
            {
                return false;
            }
            return true;

        }
    }
}
