#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<T> Present<T>(T value)
            =>
            Optional<T>.Present(value);

        public static Optional<T> Absent<T>()
            =>
            Optional<T>.Absent;

        public static Optional<T> Absent<T>(Unit unit) => unit switch
        {
            _ =>
            Optional<T>.Absent
        };
    }
}
