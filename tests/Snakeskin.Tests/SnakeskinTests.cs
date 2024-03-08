using Xunit.Abstractions;

namespace Snakeskin.Tests
{
    public class SnakeskinTests
    {
        private readonly ITestOutputHelper _output;

        private const int MAX_VALUE = 1_000_000;

        public SnakeskinTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void BooleanTest()
        {
            var value = Snakeskin.Boolean();

            Assert.True(value == true || value == false);
        }

        [Fact]
        public void BooleanTest1()
        {
            var value = Snakeskin.Boolean(0.5f);

            Assert.True(value == true || value == false);
        }

        [Fact]
        public void DateTimeTest()
        {
            var value = Snakeskin.DateTime();

            Assert.True(value >= DateTime.MinValue && value <= DateTime.MaxValue);
        }

        [Fact]
        public void DateTimeTest1()
        {
            var value = Snakeskin.DateTime(DateTime.MinValue, DateTime.MaxValue);

            Assert.True(value >= DateTime.MinValue && value <= DateTime.MaxValue);
        }

        [Fact]
        public void GuidTest()
        {
            var value = Snakeskin.Guid();

            Assert.NotEqual(Guid.Empty, value);
        }

        [Fact]
        public void GuidTest1()
        {
            var value = Snakeskin.Guid(true);

            Assert.NotEqual(Guid.Empty, value);
        }

        [Fact]
        public void IntTest()
        {
            var value = Snakeskin.Int();

            Assert.True(value >= 0 && value <= 100);
        }

        [Fact]
        public void IntTest1()
        {
            var value = Snakeskin.Int(0, 100);

            Assert.True(value >= 0 && value <= 100);
        }

        [Fact]
        public void FloatTest()
        {
            var value = Snakeskin.Float();

            Assert.True(value >= 0 && value <= 100);
        }

        [Fact]
        public void FloatTest1()
        {
            var value = Snakeskin.Float(0, 100);

            Assert.True(value >= 0 && value <= 100);
        }

        [Fact]
        public void DoubleTest()
        {
            var value = Snakeskin.Double();

            Assert.True(value >= 0 && value <= 100);
        }

        [Fact]
        public void DoubleTest1()
        {
            var value = Snakeskin.Double(0, 100);

            Assert.True(value >= 0 && value <= 100);
        }

        [Fact]
        public void DecimalTest()
        {
            var value = Snakeskin.Decimal();

            Assert.True(value >= 0 && value <= 100);
        }

        [Fact]
        public void DecimalTest1()
        {
            var value = Snakeskin.Decimal(0, 100);

            Assert.True(value >= 0 && value <= 100);
        }

        [Fact]
        public void StringTest()
        {
            var value = Snakeskin.String();

            Assert.True(value.Length >= 0);
        }

        [Fact]
        public void StringTest1()
        {
            var value = Snakeskin.String(10, "abc", true);

            Assert.True(value.Length == 10);
        }

        [Fact]
        public void StringTest2()
        {
            var value = Snakeskin.String(10, 20, "abc", true);

            Assert.True(value.Length >= 10 && value.Length <= 20);
        }

        [Fact]
        public void NameTest()
        {
            for(int i = 0; i < MAX_VALUE; i++)
            {
                var value = Snakeskin.Name();

                Assert.True(value.Length >= 0);

                _output.WriteLine(value);
            }
        }

        [Fact]
        public void NameTest1()
        {
            var value = Snakeskin.Name(10, "abc", true);

            Assert.True(value.Length == 10);
        }

        [Fact]
        public void NameTest2()
        {
            var value = Snakeskin.Name(10, 20, "abc", true);

            Assert.True(value.Length >= 10 && value.Length <= 20);
        }

        [Fact]
        public void PhoneTest()
        {
            var value = Snakeskin.Phone();

            Assert.True(value.Length == 11);
        }

        [Fact]
        public void PhoneTest1()
        {
            var value = Snakeskin.PhoneV2(86);

            Assert.True(value.Length >= 11);
        }

        [Fact]
        public void TelephoneTest()
        {
            var value = Snakeskin.Telephone();

            Assert.True(value.Length == 11);
        }
    }
}