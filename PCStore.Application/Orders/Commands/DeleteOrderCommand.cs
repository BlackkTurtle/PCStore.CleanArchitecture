﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Data.SqlClient.DataClassification;

namespace PCStore.Application.Orders.Commands
{
    public record DeleteOrderCommand(int id) : IRequest;
}
