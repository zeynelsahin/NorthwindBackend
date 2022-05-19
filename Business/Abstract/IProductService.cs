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
        IDataResult<List<ProductCategoryDto>> GetProductCategory();
        IDataResult<List<ProductSuppliersDto>> GetProductSupplier();
        
       
        List<IResult> Add(Product product);
        IResult Update(Product product);
        IResult Delete(int productId);

        IResult AddTransactionalTest(Product product);
        
    }
}