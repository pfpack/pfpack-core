#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static bool Equals(Optional<T> left, Optional<T> right)
            =>
            left.Equals(right);

        public static bool operator ==(Optional<T> left, Optional<T> right)
            =>
            left.Equals(right);

        public static bool operator !=(Optional<T> left, Optional<T> right)
            =>
            left.Equals(right) is false;

        public override bool Equals(object? obj)
            =>
            obj is Optional<T> other &&
            Equals(other);
    }
}
