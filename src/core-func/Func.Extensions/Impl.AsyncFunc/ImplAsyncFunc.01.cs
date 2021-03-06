#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncFunc<T, TResult> : IAsyncFunc<T, TResult>
    {
        private readonly Func<T, CancellationToken, Task<TResult>> funcAsync;

        public ImplAsyncFunc(
            Func<T, CancellationToken, Task<TResult>> funcAsync)
            =>
            this.funcAsync = funcAsync;

        public Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
            =>
            funcAsync.Invoke(arg, cancellationToken);
    }
}