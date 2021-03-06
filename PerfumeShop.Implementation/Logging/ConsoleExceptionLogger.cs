using PerfumeShop.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void Log(Exception ex)
        {
            Console.WriteLine(ex.Message + "\n" + ex.Data + "\n" + ex.InnerException);
        }
    }
}
