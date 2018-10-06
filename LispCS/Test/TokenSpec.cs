using System;
using Xunit;
using Source;

namespace Test {

    public class TokenSpec {
        // 123.456E+789
        Lips lips = new Lips();
        
        [Theory]
        [InlineData("234", 234.0)]
        [InlineData("234.456", 234.456)]
        [InlineData("234.456E+2", 234.456E+2)]
        [InlineData("234.456E-2", 234.456E-2)]
        [InlineData("234.456E2", 234.456E2)]
        [InlineData("234.456e+2", 234.456E+2)]
        [InlineData("234.456e-2", 234.456E-2)]
        [InlineData("234.456e2", 234.456E2)]
        public void Should_parse_number(string expr, double value) {
            Assert.Equal(((TokenNumber)lips.Eval(expr)).Value, value);
        }

        [Fact]
        public void Should_raise_error_if_no_digit_after_dot() {
            Assert.IsType<TokenError>(lips.Eval("234.a"));
        }    
    }
}