using Core.DataAccess.EntityFramework;
using Core.Entities.Concete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, NorthwindContext>, IUserOperationClaimDal
    {
    }
}