using System;
using Xunit;
using Source;

namespace Test {

    public class TokenSpec {

        private Lips lips = new Lips();

        [Fact]
        public void ReaderTest() {
            var error = (TokenError)lips.Eval("123.a");
            Assert.IsType<TokenError>(error);
            Assert.Equal(4, error.Col);
            Assert.Equal(0, error.Row);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("123.456")]
        [InlineData("123.456E+7")]
        [InlineData("123.456E-7")]
        [InlineData("123.456E7")]
        [InlineData("123.456e+7")]
        [InlineData("123.456e-7")]
        [InlineData("123.456e7")]
        public void NumberParsing(string expr) {
            var result = lips.Eval(expr);
            Assert.IsType<TokenNumber>(result);
            Assert.Equal(double.Parse(expr), ((TokenNumber)result).Value);
        }

        [Fact]
        public void NumberErrors() {
            Assert.IsType<TokenError>(lips.Eval("123.a"));
        }

        [Theory]
        [InlineData(@"a")]
        [InlineData(@"a b")]
        [InlineData(@"(a")]
        [InlineData(@")a")]
        [InlineData(@"(a)")]
        public void StringParsing(string expr) {
            var result = lips.Eval(@"""" + expr + @"""");
            Assert.IsType<TokenString>(result);
            Assert.Equal(expr, ((TokenString)result).Value);
        }

        [Theory]
        [InlineData(@"""a")]
        public void StringErrors(string expr) {
            Assert.IsType<TokenError>(lips.Eval(expr));
        }

        [Theory]
        [InlineData(";abc", "abc")]
        [InlineData(";a;b;c", "a;b;c")]
        [InlineData(";a;b\nc", "a;b")]
        public void CommentParsing(string expr, string value) {
            var result = lips.Eval(expr);
            Assert.IsType<TokenComment>(result);
            Assert.Equal(value, ((TokenComment)result).Value);
        }

        [Theory]
        [InlineData(@"++")]
        [InlineData(@"--")]
        [InlineData(@"!")]
        [InlineData(@"+")]
        [InlineData(@"-")]
        [InlineData(@"*")]
        [InlineData(@"/")]
        [InlineData(@"%")]
        [InlineData(@"^")]
        [InlineData(@"<")]
        [InlineData(@">")]
        [InlineData(@"<=")]
        [InlineData(@">=")]
        [InlineData(@"==")]
        [InlineData(@"!=")]
        [InlineData(@"|")]
        [InlineData(@"||")]
        [InlineData(@"&")]
        [InlineData(@"&&")]
        [InlineData(@"(")]
        [InlineData(@")")]
        public void SymbolParsing(string expr) {
            Assert.Equal(expr, ((TokenSymbol)lips.Eval(expr)).Value);
        }

        [Theory]
        [InlineData(@"true")]
        [InlineData(@"false")]
        [InlineData(@"if")]
        [InlineData(@"for")]
        [InlineData(@"while")]
        [InlineData(@"func")]
        [InlineData(@"var")]
        [InlineData(@"set")]
        public void KeywordParsing(string expr) {
            var result = lips.Eval(expr);
            Assert.IsType<TokenKeyword>(result);
            Assert.Equal(expr, ((TokenKeyword)result).Value);
        }

        [Theory]
        [InlineData("\nif\n")]
        [InlineData("\n123\n")]
        public void Eof(string expr) {
            lips.Eval(expr);
            Assert.IsType<TokenEof>(lips.Eval(expr));
        }

    }
}