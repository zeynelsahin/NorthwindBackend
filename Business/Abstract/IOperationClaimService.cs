using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<OperationClaim> GetById(int operationClaimId);
        IDataResult<List<OperationClaim>> GetAll();

        IResult Add(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IResult Delete(int operationClaimId);
    }
}