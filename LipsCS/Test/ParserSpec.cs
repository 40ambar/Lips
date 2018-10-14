using Xunit;
using Source;
using System;
using Source.Tokens;

namespace Test {

    public class ParserSpec {

        [Theory]
        [InlineData(";bla bla", null)]
        [InlineData(";* bla bla  \n asda *;", null)]
        public void CommentTest(string source, Ast expected) {
            var parser = new Parser(source);
            Assert.Equal(expected, parser.Read());
        }

        [Theory]
        [InlineData(@"""deneme""", "deneme")]
        [InlineData("123", 123.0)]
        [InlineData("true", true)]
        public void LiteralTest(string source, object expected) {
            var parser = new Parser(source);
            
            Assert.Equal(
                expected,
                Assert.IsType<Literal>(parser.Read()).Value
            );
        }
    }

}