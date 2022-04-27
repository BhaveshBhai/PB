using PBSA.Models;
using PBSA.Request;
using PBSA.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Interface
{
    public interface ISalesService
    {
        Task<int> CreateSale(SalesRequest salesRequest);
        Task<Models.Sale> GetSaleById(int id);
        Task<SaleResponse> GetSaleRespone(Models.Sale sale);
        Task<SaleLine> GetSaleLineById(int saleLineId);
    }
}
