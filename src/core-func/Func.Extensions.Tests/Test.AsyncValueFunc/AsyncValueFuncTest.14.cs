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
        public void From_14_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<int?, object?, RefType?, RefType, StructType, DateTime, int, RecordType, DateTimeKind, RecordType?, object, string, long, object, CancellationToken, ValueTask<RecordType>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public async ValueTask From_14_ThenInvokeAsync_ExpectResultOfSourceFunc(
            StructType sourceFuncResult)
        {
            var actual = AsyncValueFunc.From<int?, RefType, object?, decimal, RecordType?, StructType, long, RefType, int, DateTimeKind, object, long, RefType, int, StructType>(
                (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: false);

            var actualResult = await actual.InvokeAsync(
                PlusFifteen, MinusFifteenIdRefType, new(), decimal.MinusOne, MinusFifteenIdSomeStringNameRecord, SomeTextStructType, long.MinValue, PlusFifteenIdRefType, int.MaxValue, DateTimeKind.Utc, null!, long.MinValue, MinusFifteenIdRefType, int.MinValue, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}