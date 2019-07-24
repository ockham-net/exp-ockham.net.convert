using System;
using Xunit;
using OData = Ockham.Data;

namespace Ockham.Data.Tests
{
    public class ConvertCoreTests
    { 
        private static Func<object, Type, ConvertOptions, bool, object, object> fnTo =
            Ockham.Test.MethodReflection.GetMethodCaller<Func<object, Type, ConvertOptions, bool, object, object>>(typeof(OData.Convert), "To");

       
        [Fact(DisplayName = "Convert.To:ImmediateReturnNullForNullReference")]
        public void ImmediateReturnNullForNullReference()
        {
            Type tRefType = typeof(object);
            foreach (var permutation in OptionsPermutation.GetAll(new object()))
            {
                Assert.Null(fnTo(null, tRefType, permutation.ConvertOptions, permutation.IgnoreError, permutation.DefaultValue));
            }
        }

        [Fact(DisplayName = "Convert.To:ImmediateReturnTargetReferenceType")]
        public void ImmediateReturnTargetReferenceType()
        {
            string lSourceValue = "foo bar baz";

            foreach (var permutation in OptionsPermutation.GetAll("a different string"))
            {
                Assert.Same(lSourceValue, fnTo(lSourceValue, typeof(string), permutation.ConvertOptions, permutation.IgnoreError, permutation.DefaultValue));
            }
        }

        [Fact(DisplayName = "Convert.To:ImmediateReturnTargetValueType")]
        public void ImmediateReturnTargetValueType()
        {
            int lIntValue = 42;

            foreach (var permutation in OptionsPermutation.GetAll(923))
            {
                Assert.Equal(lIntValue, fnTo(lIntValue, typeof(int), permutation.ConvertOptions, permutation.IgnoreError, permutation.DefaultValue));
            }
        }

        [Fact(DisplayName = "Convert.To:Empty input for nullable returns null")]
        public void EmptyInputForNullableReturnsNull()
        {
            Type lNullableType = typeof(int?);

            foreach (var permutation in OptionsPermutation.GetAll((int?)342))
            {
                Assert.Null(fnTo(null, lNullableType, permutation.ConvertOptions, permutation.IgnoreError, permutation.DefaultValue));
            }
        }

        [Fact(DisplayName = "Convert.To:Non-empty input for nullable returns underlying value (int)")]
        public void NonEmptyInputForNullableReturnsUnderlyingValue_Int()
        {
            Type lNullableType = typeof(int?);

            foreach (var permutation in OptionsPermutation.GetAll((int?)342))
            {
                foreach (object lInput in ConvertTestData.Int49Inputs)
                {
                    object lResult = fnTo(lInput, lNullableType, permutation.ConvertOptions, permutation.IgnoreError, permutation.DefaultValue);
                    Assert.IsAssignableFrom<int>(lResult);
                    Assert.Equal(49, (int)lResult);
                }
            }
        }

        [Fact(DisplayName = "Convert.To:Non-empty input for nullable returns underlying value (enum)")]
        public void NonEmptyInputForNullableReturnsUnderlyingValue_Enum()
        {
            Type lNullableType = typeof(TestShortEnum?);

            foreach (var permutation in OptionsPermutation.GetAll((TestShortEnum?)TestShortEnum.One))
            {
                foreach (object lInput in ConvertTestData.Int49Inputs)
                {
                    object lResult = fnTo(lInput, lNullableType, permutation.ConvertOptions, permutation.IgnoreError, permutation.DefaultValue);
                    Assert.IsAssignableFrom<TestShortEnum>(lResult);
                    Assert.Equal(TestShortEnum.FortyNine, (TestShortEnum)lResult);
                }
            }
        }

        [Fact(DisplayName = "Convert.To:NullToValueDefault")]
        public void NullToValueDefault()
        {
            // Int, no explicit default
            ConvertAssert.Equal(0, fnTo(null, typeof(int), ConvertOptions.NullToValueDefault, false, null));
            ConvertAssert.Equal(0, fnTo(DBNull.Value, typeof(int), ConvertOptions.NullToValueDefault, false, null));
            ConvertAssert.Equal(0, fnTo(string.Empty, typeof(int), ConvertOptions.NullToValueDefault | ConvertOptions.EmptyStringAsNull, false, null));

            // Int, explicit default
            ConvertAssert.Equal(42, fnTo(null, typeof(int), ConvertOptions.NullToValueDefault, false, 42));
            ConvertAssert.Equal(42, fnTo(DBNull.Value, typeof(int), ConvertOptions.NullToValueDefault, false, 42));
            ConvertAssert.Equal(42, fnTo(string.Empty, typeof(int), ConvertOptions.NullToValueDefault | ConvertOptions.EmptyStringAsNull, false, 42));

            // Enum, no explicit default
            ConvertAssert.Equal((TestShortEnum)0, fnTo(null, typeof(TestShortEnum), ConvertOptions.NullToValueDefault, false, null));
            ConvertAssert.Equal((TestShortEnum)0, fnTo(DBNull.Value, typeof(TestShortEnum), ConvertOptions.NullToValueDefault, false, null));
            ConvertAssert.Equal((TestShortEnum)0, fnTo(string.Empty, typeof(TestShortEnum), ConvertOptions.NullToValueDefault | ConvertOptions.EmptyStringAsNull, false, null));

            // Enum, explicit default
            ConvertAssert.Equal(TestShortEnum.One, fnTo(null, typeof(TestShortEnum), ConvertOptions.NullToValueDefault, false, TestShortEnum.One));
            ConvertAssert.Equal(TestShortEnum.One, fnTo(DBNull.Value, typeof(TestShortEnum), ConvertOptions.NullToValueDefault, false, TestShortEnum.One));
            ConvertAssert.Equal(TestShortEnum.One, fnTo(string.Empty, typeof(TestShortEnum), ConvertOptions.NullToValueDefault | ConvertOptions.EmptyStringAsNull, false, TestShortEnum.One));

        }

        // Ensure the IgnoreError causes the default value to be returned on null input, even WITHOUT the ConvertOptions.NullToValueDefault flag

        [Fact(DisplayName = "Convert.To:NullToValueDefault_IgnoreError")]
        public void NullToValueDefault_IgnoreError()
        {

            // Int, no explicit default
            ConvertAssert.Equal(0, fnTo(null, typeof(int), ConvertOptions.None, true, null));
            ConvertAssert.Equal(0, fnTo(DBNull.Value, typeof(int), ConvertOptions.None, true, null));
            ConvertAssert.Equal(0, fnTo(string.Empty, typeof(int), ConvertOptions.EmptyStringAsNull, true, null));

            // Int, explicit default
            ConvertAssert.Equal(42, fnTo(null, typeof(int), ConvertOptions.None, true, 42));
            ConvertAssert.Equal(42, fnTo(DBNull.Value, typeof(int), ConvertOptions.None, true, 42));
            ConvertAssert.Equal(42, fnTo(string.Empty, typeof(int), ConvertOptions.EmptyStringAsNull, true, 42));

            // Enum, no explicit default
            ConvertAssert.Equal((TestShortEnum)0, fnTo(null, typeof(TestShortEnum), ConvertOptions.None, true, null));
            ConvertAssert.Equal((TestShortEnum)0, fnTo(DBNull.Value, typeof(TestShortEnum), ConvertOptions.None, true, null));
            ConvertAssert.Equal((TestShortEnum)0, fnTo(string.Empty, typeof(TestShortEnum), ConvertOptions.EmptyStringAsNull, true, null));

            // Enum, explicit default
            ConvertAssert.Equal(TestShortEnum.One, fnTo(null, typeof(TestShortEnum), ConvertOptions.None, true, TestShortEnum.One));
            ConvertAssert.Equal(TestShortEnum.One, fnTo(DBNull.Value, typeof(TestShortEnum), ConvertOptions.None, true, TestShortEnum.One));
            ConvertAssert.Equal(TestShortEnum.One, fnTo(string.Empty, typeof(TestShortEnum), ConvertOptions.EmptyStringAsNull, true, TestShortEnum.One));

        }

        [Fact(DisplayName = "Convert.To:NullToValueTypeRaisesError")]
        public void NullToValueTypeRaisesError()
        {
            Assert.Throws<ArgumentNullException>(() => fnTo(null, typeof(int), ConvertOptions.None, false, null));
            Assert.Throws<ArgumentNullException>(() => fnTo(DBNull.Value, typeof(int), ConvertOptions.None, false, null));
            Assert.Throws<ArgumentNullException>(() => fnTo(string.Empty, typeof(int), ConvertOptions.EmptyStringAsNull, false, null));

            Assert.Throws<ArgumentNullException>(() => fnTo(null, typeof(TestShortEnum), ConvertOptions.None, false, null));
            Assert.Throws<ArgumentNullException>(() => fnTo(DBNull.Value, typeof(TestShortEnum), ConvertOptions.None, false, null));
            Assert.Throws<ArgumentNullException>(() => fnTo(string.Empty, typeof(TestShortEnum), ConvertOptions.EmptyStringAsNull, false, null));
        }

        [Fact(DisplayName = "Convert.To:IgnoreErrorsReturnsDefuault")]
        public void Invalid_IgnoreErrorsReturnsDefuault()
        {
            object lInput = new System.Random();

            // Int, no explicit default
            ConvertAssert.Equal(0, fnTo(string.Empty, typeof(int), ConvertOptions.None, true, null));
            ConvertAssert.Equal(0, fnTo(lInput, typeof(int), ConvertOptions.None, true, null));

            // Int, explicit default
            ConvertAssert.Equal(42, fnTo(string.Empty, typeof(int), ConvertOptions.None, true, 42));
            ConvertAssert.Equal(42, fnTo(lInput, typeof(int), ConvertOptions.None, true, 42));

            // Enum, no explicit default
            ConvertAssert.Equal((TestShortEnum)0, fnTo(string.Empty, typeof(TestShortEnum), ConvertOptions.None, true, null));
            ConvertAssert.Equal((TestShortEnum)0, fnTo(lInput, typeof(TestShortEnum), ConvertOptions.None, true, null));

            // Enum, explicit default
            ConvertAssert.Equal(TestShortEnum.One, fnTo(string.Empty, typeof(TestShortEnum), ConvertOptions.None, true, TestShortEnum.One));
            ConvertAssert.Equal(TestShortEnum.One, fnTo(lInput, typeof(TestShortEnum), ConvertOptions.None, true, TestShortEnum.One));
        }

        [Fact(DisplayName = "Convert.To:HeedErrorsRaisesException")]
        public void Invalid_HeedErrorsRaisesException()
        {
            object lInput = new System.Random();

            Assert.Throws<InvalidCastException>(() => fnTo(string.Empty, typeof(int), ConvertOptions.None, false, null));
            Assert.Throws<InvalidCastException>(() => fnTo(lInput, typeof(int), ConvertOptions.None, false, null));

            Assert.Throws<InvalidCastException>(() => fnTo(string.Empty, typeof(TestShortEnum), ConvertOptions.None, false, null));
            Assert.Throws<InvalidCastException>(() => fnTo(lInput, typeof(TestShortEnum), ConvertOptions.None, false, null));
        }
    }
}
