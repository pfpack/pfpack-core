#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FilterNotNullOptionalExtensionsTest
    {
        [Test]
        public void FilterNotNullOrThrow_SourceValueIsNotNull_ExpectSource()
        {
            var source = Optional<RefType?>.Present(ZeroIdRefType);

            var actual = source.FilterNotNullOrThrow();
            Assert.AreEqual(source, actual);
        }

        [Test]
        public void FilterNotNullOrThrow_SourceValueIsNull_ExpectInvalidOperationException()
        {
            var source = Optional<StructType?>.Present(null);
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.FilterNotNullOrThrow());
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_ExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FilterNotNullOrThrow(null!));
            Assert.AreEqual("exceptionFactory", ex!.ParamName);
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_SourceValueIsNotNull_ExpectSource()
        {
            var source = Optional<RefType?>.Present(ZeroIdRefType);

            var actual = source.FilterNotNullOrThrow(() => new SomeException());
            Assert.AreEqual(source, actual);
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_SourceValueIsNull_ExpectCreatedException()
        {
            var source = Optional<StructType?>.Present(null);
            var resultException = new SomeException();

            var ex = Assert.Throws<SomeException>(() => _ = source.FilterNotNullOrThrow(() => resultException));
            Assert.AreSame(resultException, ex);
        }

        [Test]
        public void FilterNotNullOrThrow_SourceValueIsNotNullRefType_ExpectPresentNotNullable()
        {
            var sourceValue = PlusFifteenIdRefType;
            var source = Optional<RefType?>.Present(sourceValue);

            var actual = source.FilterNotNullOrThrow();
            var expected = Optional<RefType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullOrThrow_SourceValueIsNullRefType_ExpectInvalidOperationException()
        {
            var source = Optional<RefType?>.Present(null);
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.FilterNotNullOrThrow());
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_RefTypeExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = Optional<RefType?>.Present(PlusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FilterNotNullOrThrow(null!));
            Assert.AreEqual("exceptionFactory", ex!.ParamName);
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_SourceValueIsNotNullRefType_ExpectPresentNotNullable()
        {
            var sourceValue = PlusFifteenIdRefType;
            var source = Optional<RefType?>.Present(sourceValue);

            var actual = source.FilterNotNullOrThrow(() => new SomeException());
            var expected = Optional<RefType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_SourceValueIsNullRefType_ExpectCreatedException()
        {
            var source = Optional<RefType?>.Present(null);
            var createdException = new SomeException();

            var actualExcepton = Assert.Throws<SomeException>(
                () => _ = source.FilterNotNullOrThrow(() => createdException));
            Assert.AreSame(createdException, actualExcepton);
        }

        [Test]
        public void FilterNotNullOrThrow_SourceValueIsNotNullStructType_ExpectPresentNotNullable()
        {
            var sourceValue = SomeTextStructType;
            var source = Optional<StructType?>.Present(sourceValue);

            var actual = source.FilterNotNullOrThrow();
            var expected = Optional<StructType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullOrThrow_SourceValueIsNullStructType_ExpectInvalidOperationException()
        {
            var source = Optional<StructType?>.Present(null);
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.FilterNotNullOrThrow());
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_StructExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = Optional<StructType?>.Present(null);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FilterNotNullOrThrow(null!));
            Assert.AreEqual("exceptionFactory", ex!.ParamName);
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_SourceValueIsNotNullStructType_ExpectPresentNotNullable()
        {
            var sourceValue = NullTextStructType;
            var source = Optional<StructType?>.Present(sourceValue);

            var actual = source.FilterNotNullOrThrow(() => new SomeException());
            var expected = Optional<StructType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_SourceValueIsNullStructType_ExpectCreatedException()
        {
            var source = Optional<StructType?>.Present(null);
            var createdException = new SomeException();

            var actualExcepton = Assert.Throws<SomeException>(
                () => _ = source.FilterNotNullOrThrow(() => createdException));
            Assert.AreSame(createdException, actualExcepton);
        }
    }
}
