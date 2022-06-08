using PerfumeShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.DataAccess.Extensions
{
    public static class ExtensionMethods
    {
        public static void DeactivateEntity(this PerfumeContext context, Entity e)
        {
            e.IsActive = false;
            context.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public static void SoftDeleteEntity(this PerfumeContext context, Entity e)
        {
            e.IsDeleted = true;
            e.DeletedAt = DateTime.UtcNow;
            context.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
