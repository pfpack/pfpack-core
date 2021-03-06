#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class TaggedUnionResultExtensions
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        public void Result_ToTaggedUnion_SourceResultIsDefault_ExpectUnionSecondOfDefaultValue(
            Result<RefType?, StructType> sourceResult)
        {
            var actual = sourceResult.ToTaggedUnion();
            var expected = TaggedUnion<RefType?, StructType>.Second(default(StructType));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public void Result_ToTaggedUnion_SourceResultIsFailure_ExpectUnionSecondOfSourceFailureValue(
            Result<RefType, StructType> sourceResult)
        {
            var actual = sourceResult.ToTaggedUnion();
            var expected = TaggedUnion<RefType, StructType>.Second(SomeTextStructType);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        public void Result_ToTaggedUnion_SourceResultIsSuccessAndSourceValueIsNull_ExpectUnionFirstOfNullValue(
            Result<RefType?, StructType> sourceResult)
        {
            var actual = sourceResult.ToTaggedUnion();
            var expected = TaggedUnion<RefType?, StructType>.First(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void Result_ToTaggedUnion_SourceResultIsSuccessAndSourceValueIsNotNull_ExpectUnionFirstOfSourceSuccessValue(
            Result<RefType, StructType> sourceResult)
        {
            var actual = sourceResult.ToTaggedUnion();
            var expected = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

            Assert.AreEqual(expected, actual);
        }
    }
}