using System;
using System.Collections.Generic;
using Calculator.Domain.Base.Model;

namespace Calculator.Domain.Model
{
    public class Operation : Entity, IAggregateRoot
    {
        public long Id { get; set; }
        public string Equation { get; set; }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return Id;
        }
    }
}