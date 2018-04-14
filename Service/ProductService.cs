using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IProductService
    {
         IEnumerable<Product> GetAll();
         bool Add(Product model);
         bool Delete(int id);
         bool Update(Product model);
         Product Get(int id);
         
    }

    public class  ProductService : IProductService
    {
        private readonly FactVentoryDbContext _costumerDbContext;

        public ProductService(
            FactVentoryDbContext costumerDbContext
            )
        {
            _costumerDbContext = costumerDbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            var result = new List<Product>();

            try
            {
                result = _costumerDbContext.Product.ToList();
            }
            catch (System.Exception)
            {
               
            }
            return result;
        }

        public Product Get(int id )
        {
            var result = new Product();

            try
            {
                result = _costumerDbContext.Product.Single(x => x.ProductId == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(Product model)
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

        public bool Update(Product model)
        {
            try
            {
                var originalModel = _costumerDbContext.Product.Single(x =>
                x.ProductId == model.ProductId
                );
                originalModel.ProductName = model.ProductName;
                originalModel.UnitPrice = model.UnitPrice;
                originalModel.Quantity = model.Quantity;
                originalModel.Description = model.Description;

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
                _costumerDbContext.Entry(new Product { ProductId = id}).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
