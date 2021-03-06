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
        public void From_07_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RecordType, string, RefType?, object, Guid?, int, StructType, CancellationToken, ValueTask<int>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public async ValueTask From_07_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RecordType? sourceFuncResult)
        {
            var actual = AsyncValueFunc.From<string?, int, RefType?, object, RecordType, string, StructType, RecordType?>(
                (_, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: true);

            var actualResult = await actual.InvokeAsync(
                SomeString, PlusFifteen, MinusFifteenIdRefType, SomeTextStructType, null!, EmptyString, LowerSomeTextStructType, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}