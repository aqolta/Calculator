using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Domain.Base.Model
{
    public abstract class Entity
    {
        protected abstract IEnumerable<object> GetIdentityComponents();
    }
}
