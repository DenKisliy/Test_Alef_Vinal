using BusinessObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Query
    {
        public void CreateProduct(Product newProduct)
        {
            using (ApplicationContext dataBase = new ApplicationContext())
            {
                dataBase.Products.Add(newProduct);
                dataBase.SaveChanges();
            }
        }
        public void UpdateProduct(Product updateProduct)
        {
            using (ApplicationContext dataBase = new ApplicationContext())
            {
                dataBase.Products.Update(updateProduct);
                dataBase.SaveChanges();
            }
        }
        public Product GetProduct(int id)
        {
            using (ApplicationContext dataBase = new ApplicationContext())
            {
                return dataBase.Products.Find(id);
            }
        }

        public List<Product> GetListProducts()
        {
            using (ApplicationContext dataBase = new ApplicationContext())
            {
                return dataBase.Products.ToList();
            }
        }
    }
}
