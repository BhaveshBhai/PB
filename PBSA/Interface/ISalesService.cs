using PBSA.Models.DB;
using PBSA.Request;
using PBSA.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PBSA.Interface
{
    public interface ISalesService
    {
        Task<int> CreateSale(SalesRequest salesRequest);
        Task<Sale> GetSaleById(int id);
        Task<SalesResponse> GetSaleRespone(Sale sale);
        Task<SaleLine> GetSaleLineById(int saleLineId);
    }
}
