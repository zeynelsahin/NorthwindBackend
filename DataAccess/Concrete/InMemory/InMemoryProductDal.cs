using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return null;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return null;
        }

        public void Add(Product entity)
        {
        }

        public void Update(Product entity)
        {
        }

        public void Delete(Product entity)
        {
        }

        public List<ProductCategoryDto> GetProductCategory()
        {
            return null;
        }

        public List<ProductSuppliersDto> GetProductSupplier()
        {
            return null;
        }
    }
}