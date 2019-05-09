using Xunit;

namespace FizzBuzzLibrary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void should_return_FizzBuzz_when_receive_a_valid_multiple_of_three_and_five()
        {
            Assert.Equal("FizzBuzz", FizzBuzz.FizzBuzzPrint(15));
        }
        [Fact]
        public void should_return_Fizz_when_receive_a_valid_multiple_of_three_but_not_five()
        {
            Assert.Equal("Fizz", FizzBuzz.FizzBuzzPrint(3));
        }
        [Fact]
        public void should_return_Buzz_when_receive_a_valid_multiple_of_five_but_not_three()
        {
            Assert.Equal("Buzz", FizzBuzz.FizzBuzzPrint(5));
        }
        [Fact]
        public void should_return_received_integer_when_receive_a_valid_integer_that_is_not_a_multiple_of_three_or_five()
        {
            Assert.Equal("7", FizzBuzz.FizzBuzzPrint(7));
        }
        [Fact]
        public void should_return_nothing_when_receive_an_invalid_integer()
        {
            Assert.Equal("", FizzBuzz.FizzBuzzPrint(101));
        }
    }
}
