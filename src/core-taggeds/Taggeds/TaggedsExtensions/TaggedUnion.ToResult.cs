#nullable enable

namespace System
{
    partial class TaggedsExtensions
    {
        public static Result<TSuccess, TFailure> ToResult<TSuccess, TFailure>(
            this TaggedUnion<TSuccess, TFailure> union)
            where TFailure : struct
            =>
            union.Fold(
                Result<TSuccess, TFailure>.Success,
                Result<TSuccess, TFailure>.Failure);
    }
}
