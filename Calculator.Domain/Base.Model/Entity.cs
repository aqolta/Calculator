using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Domain.Base.Model
{
    public abstract class Entity
    {
        protected abstract IEnumerable<object> GetIdentityComponents();

        public virtual IEnumerable<INotification> GetDomainEventsToBeProducedOnEverySave()
        {
            return new INotification[0];
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (GetUnproxiedType(this) != GetUnproxiedType(obj)) return false;
            var other = obj as Entity;
            return GetIdentityComponents().SequenceEqual(other.GetIdentityComponents());
        }

        public override int GetHashCode()
        {
            var hash = 17;
            foreach (var obj in GetIdentityComponents())
                hash = hash * 23 + (obj != null ? obj.GetHashCode() : 0);
            return hash;
        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return Equals(right, null);
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        internal static Type GetUnproxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";
            const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
                return type.BaseType;

            return type;
        }
    }
}
