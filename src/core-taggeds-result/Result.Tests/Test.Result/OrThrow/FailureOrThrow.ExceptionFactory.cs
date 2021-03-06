#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        public void FailureOrThrowWithExceptionFactory_SourceIsDefault_ExpectDefaultFailureValue(
            Result<RefType, StructType> source)
        {
            var actual = source.FailureOrThrow(() => new SomeException());
            var expected = default(StructType);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public void FailureOrThrowWithExceptionFactory_SourceIsFailure_ExpectFailureValue(
            Result<RefType, StructType> source)
        {
            var actual = source.FailureOrThrow(() => new SomeException());
            var expected = SomeTextStructType;

            Assert.AreEqual(expected, actual);
        }

        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void FailureOrThrowWithExceptionFactory_SourceIsSuccess_ExpectExceptionFromFactory(
            Result<RefType, StructType> source)
        {
            var exceptionFromFactory = new SomeException();

            var actualException = Assert.Throws<SomeException>(
                () => _ = source.FailureOrThrow(() => exceptionFromFactory));
                
            Assert.AreEqual(exceptionFromFactory, actualException);
        }
    }
}