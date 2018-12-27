using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Constraints
{
    public class ConstraintCollection
    {
        private readonly IServiceProvider _serviceProvider;

        public ConstraintCollection(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetConstraint<T>() where T:ConstraintValidatorBase
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
