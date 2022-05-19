using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            // if (DateTime.Now.Hour == 22) return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            var result = BusinessRules.Run(CheckIfCategoryExists(categoryId));
            if (result.Success!=true)
            {
                return (IDataResult<List<Product>>)result;
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductCategoryDto>> GetProductCategory()
        {
            return new SuccessDataResult<List<ProductCategoryDto>>(_productDal.GetProductCategory());
            // return new ErrorDataResult<List<ProductCategoryDto>>(new List<ProductCategoryDto>(), Messages.ErrorProductsListed);
        }

        public IDataResult<List<ProductSuppliersDto>> GetProductSupplier()
        {
            return new SuccessDataResult<List<ProductSuppliersDto>>(_productDal.GetProductSupplier());
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            var result = BusinessRules.Run(CheckIfProductExists(productId));
            if (result.Success != true)
            {
                return (IDataResult<Product>)result;
            }

            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public List<IResult> Add(Product product)
        {
            var result = BusinessRules.RunMultiple(CheckIfCategoryExistsForProduct(product.CategoryId), CheckIfProductNameExists(product.ProductName),
                CheckIfProductOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());
            if (result.Count > 0)
            {
                return result;
            }

            _productDal.Add(product);
            return new List<IResult> { new SuccessResult(Messages.ProductAdded) };
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(int productId)
        {
            var result = BusinessRules.Run(CheckIfProductExists(productId));
            if (result.Success!=true)
            {
                return result;
            }
            var entity = GetById(productId);
            _productDal.Delete(entity.Data);
            return new SuccessResult(Messages.ProductDeleted);
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            return null;
        }

        private IResult CheckIfProductOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlredyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryExistsForProduct(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll().Data.Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }

        private IDataResult<Product> CheckIfProductExists(int productId)
        {
            var result = _productDal.GetAll(product => product.ProductId == productId).Any();
            if (!result)
            {
                return new ErrorDataResult<Product>(Messages.ProductNotFound);
            }

            return new SuccessDataResult<Product>();
        }
        private IDataResult<List<Product>> CheckIfCategoryExists(int categoryId)
        {
            var result = _productDal.GetAll(product => product.CategoryId== categoryId).Any();
            if (!result)
            {
                return new ErrorDataResult<List<Product>>(Messages.CategoryNotFound);
            }

            return new SuccessDataResult<List<Product>>();
        }
    }
}