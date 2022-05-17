using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
       
        List<IResult> Add(Product product);
        IResult UpdateProduct(Product product);

        IResult AddTransactionalTest(Product product);
        
    }
}