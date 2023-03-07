using DevsonMotors.ViewModels;
using DevsonMotors.Models;
using Microsoft.Identity.Client;

namespace DevsonMotors.Domains
{
    public interface IProductsService
    {
        List<Product> GetProductList();
        Product GetProductById(int ProductId);
        ResponseModel SaveProduct(Product product);
        ResponseModel DeleteProduct(int ProductId);
    }

}


