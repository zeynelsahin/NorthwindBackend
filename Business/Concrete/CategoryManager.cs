using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Category> GetById(int categoryId)
        {
            var result = BusinessRules.Run(CheckIfCCategoryExistsDataResult(categoryId));
            if (result.Success != true)
            {
                return (IDataResult<Category>)result;
            }

            var category = _categoryDal.Get(category => category.CategoryId == categoryId);
            return new SuccessDataResult<Category>(category, Messages.CategoryListed);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccesResult(Messages.CategoryAdded);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Update(Category category)
        {
            var result = BusinessRules.Run(CheckIfCCategoryExistsDataResult(category.CategoryId));
            if (result.Success != true)
            {
                return (IDataResult<Category>)result;
            }

            _categoryDal.Update(category);
            return new SuccesResult(Messages.CategoryUpdated);
        }

        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Delete(int categoryId)
        {
            var result = BusinessRules.Run(CheckIfCCategoryExists(categoryId));
            if (result.Success != true)
            {
                return result;
            }

            var entity = GetById(categoryId);
            _categoryDal.Delete(entity.Data);
            return new SuccesResult(Messages.CategoryDeleted);
        }

        private IResult CheckIfCCategoryExists(int categoryId)
        {
            var result = _categoryDal.GetAll(category => category.CategoryId == categoryId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            return new SuccesResult();
        }

        private IDataResult<Category> CheckIfCCategoryExistsDataResult(int? categoryId)
        {
            var result = _categoryDal.GetAll(category => category.CategoryId == categoryId).Any();
            if (!result)
            {
                return new ErrorDataResult<Category>(Messages.CategoryNotFound);
            }

            return new SuccessDataResult<Category>();
        }
    }
}