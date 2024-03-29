﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Application.UseCases.Queries
{
    public interface IGetUseCaseLogsQuery : IQuery<UseCaseLogSearch, IEnumerable<UseCaseLog>>
    {
    }
}
