using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace MvcDemoApplication.web.Models
{
    public class FluentDataModelValidator : AbstractValidator<FluentDataModel>
    {
        public FluentDataModelValidator()
        {
           RuleFor(x => x.ValString1)
            .NotNull();
            RuleFor(x => x.ValString2)
                .NotNull()
                .Length(6, 100);

            RuleFor(y => y.ValDouble1).InclusiveBetween(40.0, 50.0);

            RuleFor(customer => customer.ApplicationSubmitted).NotEmpty().When(customer => customer.SelectedApplicationStatus > 0);
        }
        
    }
}