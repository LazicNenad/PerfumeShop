using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases
{
    public interface IQuery<in TRequest, out TResult> : IUseCase
    {
        TResult Execute(TRequest request);
    }
}
