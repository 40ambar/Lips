using Source.Tokens;

namespace Source {

    public class Parser {

        private Lexer Lexer;

        public Parser(string source) {
            Lexer = new Lexer(source);
        }

        public Ast Read() {
            if(Lexer.Peek() is TokenComment || Lexer.Peek() is TokenMultilineComment){
                Lexer.Read();
            }

            if(Lexer.Peek() is TokenNumber) {
                var numberToken = (TokenNumber)Lexer.Read();
                return new Literal(numberToken.Value);
            }

            if(Lexer.Peek() is TokenBool){
                var boolToken = (TokenBool)Lexer.Read();
                return new Literal(boolToken.Value);
            }

            if(Lexer.Peek() is TokenString){
                var stringToken = (TokenString)Lexer.Read();
                return new Literal(stringToken.Value);
            }

            return null;
        }

    }

}