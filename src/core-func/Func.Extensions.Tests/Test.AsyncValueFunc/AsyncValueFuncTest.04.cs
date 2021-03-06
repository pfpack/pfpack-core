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
        public void From_04_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType?, string, RecordType, StructType, CancellationToken, ValueTask<Guid>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public async ValueTask From_04_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RefType? sourceFuncResult)
        {
            var actual = AsyncValueFunc.From<object, int, RecordType?, StructType, RefType?>(
                (_, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: true);

            var actualResult = await actual.InvokeAsync(
                new object(), MinusFifteen, PlusFifteenIdLowerSomeStringNameRecord, default, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}