using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation
{
    public abstract class EfUseCase
    {
        protected PerfumeContext Context;

        protected EfUseCase(PerfumeContext context)
        {
            Context = context;
        }
    }
}
