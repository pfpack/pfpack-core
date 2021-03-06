#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class AsyncFuncTest
    {
        [Fact]
        public void From_09_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<long, RefType?, StructType, RecordType, DateTimeOffset, int?, RecordType?, object?, RefType, CancellationToken, Task<object?>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public async Task From_09_ThenInvokeAsync_ExpectResultOfSourceFunc(
            StructType sourceFuncResult)
        {
            var actual = AsyncFunc.From<RecordType, RefType, int, object?, StructType, string, RecordType?, string?, RefType?, StructType>(
                (_, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: false);

            var actualResult = await actual.InvokeAsync(
                ZeroIdNullNameRecord, MinusFifteenIdRefType, MinusFifteen, new(), default, SomeString, null, WhiteSpaceString, MinusFifteenIdRefType, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}