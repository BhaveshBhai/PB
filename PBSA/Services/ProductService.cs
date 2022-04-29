using PBSA.Interface;
using PBSA.Models.DB;
using PBSA.Request;
using System.Linq;

namespace PBSA.Services
{
    public class ProductService : IProductService
    {
        public int CreateProduct(ProductRequest product)
        {
            throw new System.NotImplementedException();
        }

        public Product GetProductByCode(string code)
        {
            using (var db = new PBSAContext())
            {
                return db.Product.Where(x=>x.Code==code).FirstOrDefault();
            }
        }
    }
}
