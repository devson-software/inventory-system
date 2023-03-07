using DevsonMotors.Models;
using DevsonMotors.ViewModels;

namespace DevsonMotors.Domains
{
    public class ProductService
    {
        public class ProductsService : IProductsService
        {
            private InventoryContext _context;
            public ProductsService(InventoryContext context)
            {
                _context = context;
            }

            public Product GetProductById(int ProductId)
            {
                Product product;
                try
                {
                    product = _context.Find<Product>(ProductId);
                }
                catch (Exception)
                {
                    throw;
                }
                return product;
            }

            List<Product> GetProductList()
            {
                List<Product> productList;
                try
                {
                    productList = _context.Set<Product>().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return productList;
            }

            List<Product> IProductsService.GetProductList()
            {
                List<Product> productList;
                try
                {
                    productList = _context.Set<Product>().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return productList;
            }

            ResponseModel IProductsService.SaveProduct(Product product)
            {

                ResponseModel responseModel = new ResponseModel();
                try
                {
                    int ProductId = 0;
                    List<Product> _tempList = GetProductList();
                    Product matchingProduct = null;
                    foreach(Product product1 in _tempList)
                    {
                        if(product1.ProductName == product.ProductName)
                        {
                            matchingProduct = product1;
                            ProductId = (int)product1.ProductId;
                            break;
                        }
                    }

                    if (matchingProduct == null)
                    {
                       /* _tempAdd.ProductName = product.ProductName;
                        _tempAdd.Description = product.Description;
                        _tempAdd.Price = product.Price;
                        _tempAdd.QuintityInStock = product.QuintityInStock;*/
                        _context.Add<Product>(product);
                        responseModel.Message = "Product Inserted Successfully";
                    }
                    else
                    {
                    Product _tempUpdate = GetProductById(ProductId);
                        _tempUpdate.QuintityInStock = _tempUpdate.QuintityInStock + product.QuintityInStock;
                        _context.Update<Product>(_tempUpdate);
                        responseModel.Message = "Product Update Successfully";
                    }
                    _context.SaveChanges();
                    responseModel.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Error : " + ex.Message;
                }
                return responseModel;
            }

            ResponseModel IProductsService.DeleteProduct(int ProductId)
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    Product _temp = GetProductById(ProductId);
                    if (_temp != null)
                    {
                        _context.Remove<Product>(_temp);
                        _context.SaveChanges();
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Product Delete Successfully";
                    }
                    else
                    {
                        responseModel.IsSuccess = false;
                        responseModel.Message = "Product Not Found";
                    }
                }
                catch (Exception ex)
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Error : " + ex.Message;
                }
                return responseModel;
            }
        }
    }
}
