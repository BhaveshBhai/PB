using PBSA.Request;

namespace PBSA.Interface
{
    public interface IProductService
    {
        int CreateProduct(ProductRequest product);
    }
}
