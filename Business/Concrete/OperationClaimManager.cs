using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.OperationClaimsListed);
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<OperationClaim> GetById(int operationClaimId)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(claim => claim.Id == operationClaimId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        // [TransactionScopeAspect]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperaClaimUpdated);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Delete(int operationClaimId)
        {
            var entity = _operationClaimDal.Get(operationClaim => operationClaim.Id == operationClaimId);
            _operationClaimDal.Delete(entity);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }
    }
}