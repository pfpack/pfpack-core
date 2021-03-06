#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class AsyncValueFuncTest
    {
        [Fact]
        public void From_05_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType?, object, Guid, StructType, RecordType, CancellationToken, ValueTask<string?>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public async ValueTask From_05_ThenInvokeAsync_ExpectResultOfSourceFunc(
            StructType sourceFuncResult)
        {
            var actual = AsyncValueFunc.From<int?, RecordType, RefType?, string, object, StructType>(
                (_, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: false);

            var actualResult = await actual.InvokeAsync(
                MinusFifteen, PlusFifteenIdSomeStringNameRecord, null, SomeString, new(), cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}