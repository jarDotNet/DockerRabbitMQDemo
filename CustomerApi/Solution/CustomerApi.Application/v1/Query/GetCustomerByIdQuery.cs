﻿using CustomerApi.Domain.Entities;
using MediatR;
using System;

namespace CustomerApi.Application.v1.Query
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}