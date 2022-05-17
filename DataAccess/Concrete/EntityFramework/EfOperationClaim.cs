using Core.DataAccess.EntityFramework;
using Core.Entities.Concete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaim : EfEntityRepositoryBase<OperationClaim, NorthwindContext>, IOperationClaimDal
    {
    }
}