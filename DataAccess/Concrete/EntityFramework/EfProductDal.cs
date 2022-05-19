using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductCategoryDto> GetProductCategory()
        {
            using (var context = new NorthwindContext())
            {
                var result = from p in context.Products
                    join c in context.Categories on p.CategoryId equals c.CategoryId
                    select new ProductCategoryDto
                    {
                        ProductId = p.ProductId, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitsInStock = p.UnitsInStock, UnitPrice = p.UnitPrice
                    };
                return result.ToList();
            }
        }

        public List<ProductSuppliersDto> GetProductSupplier()
        {
            using (var context = new NorthwindContext())
            {
                var result = from product in context.Products
                    join supplier in context.Suppliers on product.SupplierId equals supplier.SupplierID
                    select new ProductSuppliersDto()
                    {
                        Product = product,
                        Supplier = supplier

                        //Products
                        // ProductID = product.ProductId,
                        // ProductName = product.ProductName,
                        // SupplierID = product.SupplierId,
                        // CategoryID = product.CategoryId,
                        // // QuantityPerUnit = product.QuantityPerUnit,
                        //  UnitPrice = product.UnitPrice,
                        //  UnitsInStock = product.UnitsInStock,
                        //  UnitsOnOrder = product.UnitsOnOrder,
                        //  ReorderLevel = product.ReorderLevel,
                        //  Discontinued = product.Discontinued,
                        //
                        // // Suppliers
                        //  CompanyName = supplier.CompanyName,
                        //  ContactName = supplier.ContactName,
                        //  ContactTitle = supplier.ContactTitle,
                        //  Address = supplier.Address,
                        //  City = supplier.City,
                        //  Region = supplier.City,
                        //  PostalCode = supplier.PostalCode,
                        //  Country = supplier.Country,
                        //  Phone = supplier.Phone,
                        //  Fax = supplier.Fax,
                        //  HomePage = supplier.HomePage
                    };
                return result.ToList();
            }
        }
    }
}