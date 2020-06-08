﻿using System;
using CustomerApi.Models.v1;
using FluentValidation;

namespace CustomerApi.Validators.v1
{
    public class UpdateCustomerModelValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerModelValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotNull()
                .MinimumLength(2).
                WithMessage("The first name must be at least 2 character long");
            
            RuleFor(customer => customer.LastName)
                .NotNull()
                .MinimumLength(2)
                .WithMessage("The last name must be at least 2 character long");

            RuleFor(customer => customer.Birthday)
                .InclusiveBetween(DateTime.Now.AddYears(-150).Date, DateTime.Now)
                .WithMessage("The birthday must not be longer ago than 150 years and can not be in the future");
                
            RuleFor(customer => customer.Age)
                .InclusiveBetween(0, 150)
                .WithMessage("The minimum age is 0 and the maximum age is 150 years");
        }
    }
}