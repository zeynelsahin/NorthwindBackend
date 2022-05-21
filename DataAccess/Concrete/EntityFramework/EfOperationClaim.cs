using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaim : EfEntityRepositoryBase<OperationClaim, NorthwindContext>, IOperationClaimDal
    {
    }
}