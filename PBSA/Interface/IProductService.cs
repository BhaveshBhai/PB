using PBSA.Models.DB;
using PBSA.Request;

namespace PBSA.Interface
{
    public interface IProductService
    {
        int CreateProduct(ProductRequest product);
        Product GetProductByCode(string code);
    }
}
