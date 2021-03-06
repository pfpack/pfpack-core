#nullable enable

using PrimeFuncPack.Core;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static implicit operator Result<TSuccess, TFailure>(TSuccess success)
            =>
            new(success);

        public static implicit operator Result<TSuccess, TFailure>(TFailure failure)
            =>
            new(failure);

        public static implicit operator Result<TSuccess, TFailure>(SuccessBuilder<TSuccess> success)
            =>
            success.With<TFailure>();

        public static implicit operator Result<TSuccess, TFailure>(FailureBuilder<TFailure> failure)
            =>
            failure.With<TSuccess>();
    }
}
