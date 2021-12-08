using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CleanArchitecture.SharedAbstractions.ValueObjects
{
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
    {
        protected const int HashCodeSeed = 19;
        protected const int HashCodeMultiplier = 57;

        public override bool Equals(object obj)
            => Equals(obj as ValueObject<T>);

        public bool Equals(ValueObject<T> other)
            => this == other;

        public override int GetHashCode()
            => GetFields()
                .Where(value => value != null)
                .Aggregate(
                    HashCodeSeed,
                    (acc, next) => unchecked(
                                            (acc * HashCodeMultiplier) + next.GetHashCode()));

        private IEnumerable<object> GetFields()
            => GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Select(field => field.GetValue(this));

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (y is null || x is null)
            {
                return false;
            }

            return x
                .GetFields()
                .Zip(
                    y.GetFields(),
                    (a, b) => ReferenceEquals(a, b)
                                                        || (a?.Equals(b) ?? false))
                .All(b => b);
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
            => !(x == y);
    }
}