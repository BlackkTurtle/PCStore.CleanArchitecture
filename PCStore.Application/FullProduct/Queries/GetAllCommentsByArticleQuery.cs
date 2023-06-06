using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.DTOs;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.FullProduct.Queries
{
    public record GetFullProductByArticleQuery(int id) : IRequest<FullProductDTO>;
}
