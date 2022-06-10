﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.Logging
{
    public interface IUseCaseLogger
    {
        void Log(UseCaseLog log);
        IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search);
    }
}
