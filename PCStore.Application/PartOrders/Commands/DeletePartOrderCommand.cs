using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Data.SqlClient.DataClassification;

namespace PCStore.Application.PartOrders.Commands
{
    public record DeletePartOrderCommand(int id) : IRequest;
}
