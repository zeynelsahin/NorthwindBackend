using System.Collections.Generic;
using Core.Entities.Concete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<UserOperationClaim> GetById(int userOperationClaimId);
        IDataResult<UserOperationClaim> GetByUserId(int userId);
        IDataResult<UserOperationClaim> GetByOperationClaimId(int operationClaimId);

        List<IResult> Add(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        IResult Delete(int operationClaimId);
        
        
    }
}