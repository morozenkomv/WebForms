using WebForm.Data;
using System;

namespace WebForm.DAL.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }
}
