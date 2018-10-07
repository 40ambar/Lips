using Source.Asts;

namespace Source {

    public class Parser {

        private Lexer Lexer;

        public Parser(string source) {
            Lexer = new Lexer(source);
        }

        public Ast Read() {
            return null;
        }

    }

}