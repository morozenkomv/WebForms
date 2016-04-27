using WebForm.Data;

namespace WebForm.DAL.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ApplicationDbContext dbContext;
        public ApplicationDbContext Init()
        {
            return dbContext ?? (dbContext = new ApplicationDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
