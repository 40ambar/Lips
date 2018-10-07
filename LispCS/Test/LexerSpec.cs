using Xunit;
using Source;
using Source.Tokens;

namespace Test {

    public class LexerSpec {

        //[Theory]
        //[InlineData("123")]
        //[InlineData("123.456")]
        //[InlineData("123.456E+7")]
        //[InlineData("123.456E-7")]
        //[InlineData("123.456E7")]
        //[InlineData("123.456e+7")]
        //[InlineData("123.456e-7")]
        //[InlineData("123.456e7")]
        //public void NumberParsing(string expr) {
        //    var lexer = new Lexer(expr);
        //    var result = lexer.Read();
        //    Assert.IsType<TokenNumber>(result);
        //    Assert.Equal(double.Parse(expr), ((TokenNumber)result).Value);
        //}

        [Fact]
        public void NumberErrors() {
            var lexer = new Lexer("123.a");
            Assert.IsType<TokenError>(lexer.Read());
        }

        //[Theory]
        //[InlineData(@"a")]
        //[InlineData(@"a b")]
        //[InlineData(@"(a")]
        //[InlineData(@")a")]
        //[InlineData(@"(a)")]
        //public void StringParsing(string expr){
        //    var lexer = new Lexer(@"""" + expr + @"""");
        //    var result = lexer.Read();
        //    Assert.IsType<TokenString>(result);
        //    Assert.Equal(expr, ((TokenString)result).Value);
        //}

        //[Theory]
        //[InlineData(@"""a")]
        //public void StringErrors(string expr) {
        //    var lexer = new Lexer(expr);
        //    Assert.IsType<TokenError>(lexer.Read());
        //}

        //[Theory]
        //[InlineData(";abc", "abc")]
        //[InlineData(";a;b;c", "a;b;c")]
        //[InlineData(";a;b\nc", "a;b")]
        //public void CommentParsing(string expr, string value) {
        //    var lexer = new Lexer(expr);
        //    var result = lexer.Read();
        //    Assert.IsType<TokenComment>(result);
        //    Assert.Equal(value, ((TokenComment)result).Value);
        //}

        //[Theory]
        //[InlineData(@"++")]
        //[InlineData(@"--")]
        //[InlineData(@"!")]
        //[InlineData(@"+")]
        //[InlineData(@"-")]
        //[InlineData(@"*")]
        //[InlineData(@"/")]
        //[InlineData(@"%")]
        //[InlineData(@"^")]
        //[InlineData(@"<")]
        //[InlineData(@">")]
        //[InlineData(@"<=")]
        //[InlineData(@">=")]
        //[InlineData(@"==")]
        //[InlineData(@"!=")]
        //[InlineData(@"|")]
        //[InlineData(@"||")]
        //[InlineData(@"&")]
        //[InlineData(@"&&")]
        //[InlineData(@"(")]
        //[InlineData(@")")]
        //public void SymbolParsing(string expr) {
        //    var lexer = new Lexer(expr);
        //    Assert.Equal(expr, ((TokenSymbol)lexer.Read()).Value);
        //}

        //[Theory]
        //[InlineData(@"true")]
        //[InlineData(@"false")]
        //[InlineData(@"if")]
        //[InlineData(@"for")]
        //[InlineData(@"while")]
        //[InlineData(@"func")]
        //[InlineData(@"var")]
        //[InlineData(@"set")]
        //public void KeywordParsing(string expr) {
        //    var lexer = new Lexer(expr);
        //    var result = lexer.Read();
        //    Assert.IsType<TokenKeyword>(result);
        //    Assert.Equal(expr, ((TokenKeyword)result).Value);
        //}

        //[Theory]
        //[InlineData("\nif\n")]
        //[InlineData("\n123\n")]
        //public void Eof(string expr) {
        //    var lexer = new Lexer(expr);
        //    lexer.Read();
        //    Assert.IsType<TokenEof>(lexer.Read());
        //}

        //[Theory]
        //[InlineData(@"test \'" , "test \'")]
        //[InlineData(@"test \""", "test \"")]
        //[InlineData(@"test \\" , "test \\")]
        //[InlineData(@"test \b" , "test \b")]
        //[InlineData(@"test \f" , "test \f")]
        //[InlineData(@"test \n" , "test \n")]
        //[InlineData(@"test \r" , "test \r")]
        //[InlineData(@"test \t" , "test \t")]
        //[InlineData(@"test \v" , "test \v")]
        //public void StringEscape(string expr, string value) {
        //    var lexer = new Lexer(@"""" + expr + @"""");
        //    var result = lexer.Read();
        //    Assert.IsType<TokenString>(result);
        //    Assert.Equal(value, ((TokenString)result).Value);
        //}

    }
}