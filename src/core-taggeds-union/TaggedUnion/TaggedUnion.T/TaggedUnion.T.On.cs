#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TFirst, TSecond> On(
            Func<TFirst, Unit> onFirst,
            Func<TSecond, Unit> onSecond)
        {
            _ = onFirst ?? throw new ArgumentNullException(nameof(onFirst));
            _ = onSecond ?? throw new ArgumentNullException(nameof(onSecond));

            return InternalOn(onFirst, onSecond, This);
        }

        public TaggedUnion<TFirst, TSecond> On(
            Action<TFirst> onFirst,
            Action<TSecond> onSecond)
        {
            _ = onFirst ?? throw new ArgumentNullException(nameof(onFirst));
            _ = onSecond ?? throw new ArgumentNullException(nameof(onSecond));

            return InternalOn(onFirst.InvokeThenToUnit, onSecond.InvokeThenToUnit, This);
        }

        public Task<TaggedUnion<TFirst, TSecond>> OnAsync(
            Func<TFirst, Task<Unit>> onFirstAsync,
            Func<TSecond, Task<Unit>> onSecondAsync)
        {
            _ = onFirstAsync ?? throw new ArgumentNullException(nameof(onFirstAsync));
            _ = onSecondAsync ?? throw new ArgumentNullException(nameof(onSecondAsync));

            return InternalOn(onFirstAsync, onSecondAsync, ThisAsync);
        }

        public Task<TaggedUnion<TFirst, TSecond>> OnAsync(
            Func<TFirst, Task> onFirstAsync,
            Func<TSecond, Task> onSecondAsync)
        {
            _ = onFirstAsync ?? throw new ArgumentNullException(nameof(onFirstAsync));
            _ = onSecondAsync ?? throw new ArgumentNullException(nameof(onSecondAsync));

            return InternalOn(onFirstAsync, onSecondAsync, ThisAsync);
        }

        public ValueTask<TaggedUnion<TFirst, TSecond>> OnValueAsync(
            Func<TFirst, ValueTask<Unit>> onFirstAsync,
            Func<TSecond, ValueTask<Unit>> onSecondAsync)
        {
            _ = onFirstAsync ?? throw new ArgumentNullException(nameof(onFirstAsync));
            _ = onSecondAsync ?? throw new ArgumentNullException(nameof(onSecondAsync));

            return InternalOn(onFirstAsync, onSecondAsync, ThisValueAsync);
        }

        public ValueTask<TaggedUnion<TFirst, TSecond>> OnValueAsync(
            Func<TFirst, ValueTask> onFirstAsync,
            Func<TSecond, ValueTask> onSecondAsync)
        {
            _ = onFirstAsync ?? throw new ArgumentNullException(nameof(onFirstAsync));
            _ = onSecondAsync ?? throw new ArgumentNullException(nameof(onSecondAsync));

            return InternalOn(onFirstAsync, onSecondAsync, ThisValueAsync);
        }
    }
}
