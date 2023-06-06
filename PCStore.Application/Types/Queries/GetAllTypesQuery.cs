﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Types.Queries
{
    public record GetAllTypesQuery : IRequest<IEnumerable<PCStore.Domain.PCStoreEntities.Types>>;
}
