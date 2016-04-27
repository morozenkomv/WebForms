using WebForm.DAL;
using WebForm.DAL.Infrastructure;
using WebForm.Data;

namespace Store.DAL.Repositories
{
    public class ProductUnitRepository : Repository<ApplicationUser>, IProductUnitRepository
    {
        public ProductUnitRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IProductUnitRepository : IRepository<ApplicationUser>
    {

    }
}
