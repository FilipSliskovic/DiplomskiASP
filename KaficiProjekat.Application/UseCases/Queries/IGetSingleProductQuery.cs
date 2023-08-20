﻿using KaficiProjekat.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Application.UseCases.Queries
{
    public interface IGetSingleProductQuery : IQuery<int,ProductDTO>
    {
    }
}
