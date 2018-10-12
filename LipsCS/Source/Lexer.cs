using Source.Tokens;
using System.Linq;

namespace Source {

    //TODO: shift operators

    public class Lexer {

        private Reader Reader;
        private Token Current;

        public Lexer(string source) {
            Reader = new Reader(source);
            Current = Next();
        }

        public bool Eof() {
            return Reader.Eof();
        }

        public Token Peek() {
            return Current;
        }

        public Token Read() {
            var ret = Current;
            Current = Next();
            return ret;
        }

        private Token Next() {

            // whitespace
            if (char.IsWhiteSpace(Reader.Peek())) {
                Reader.Read();
                while (char.IsWhiteSpace(Reader.Peek())) {
                    Reader.Read();
                }
            }

            //comment
            if (Reader.Peek() == ';') {
                Reader.Read();
                var value = "";
                if(Reader.Peek() == '*'){
                    Reader.Read();
                    while(!Reader.Eof()){
                        var buff = Reader.Read();
                        if(buff == '*' && Reader.Peek() == ';'){
                            return new TokenMultilineComment(value);
                        }
                        else{
                            value += buff;
                        }
                    }
                    return new TokenError("Open end of multiline comment.", Reader.Row, Reader.Col);
                }
                else{
                    while (!Reader.Eof() && Reader.Peek() != '\n') {
                        value += Reader.Read();
                    }
                    return new TokenComment(value);
                }
            }

            // number
            else if (char.IsDigit(Reader.Peek())) {
                var value = Reader.Read().ToString();
                while (char.IsDigit(Reader.Peek())) {
                    value += Reader.Read();
                }
                if (Reader.Peek() == '.') {
                    value += Reader.Read();
                    if (char.IsDigit(Reader.Peek())) {
                        value += Reader.Read();
                        while (char.IsDigit(Reader.Peek())) {
                            value += Reader.Read();
                        }
                    }
                    else {
                        return new TokenError($"Expected digit but found '{Reader.Peek()}'.", Reader.Row, Reader.Col);
                    }
                    if (Reader.Peek() == 'e' || Reader.Peek() == 'E') {
                        value += Reader.Read();
                        if (Reader.Peek() == '+' || Reader.Peek() == '-') {
                            value += Reader.Read();
                        }
                        if (char.IsDigit(Reader.Peek())) {
                            value += Reader.Read();
                            while (char.IsDigit(Reader.Peek())) {
                                value += Reader.Read();
                            }
                        }
                        else {
                            return new TokenError("Invalid exponential expression.", Reader.Row, Reader.Col);
                        }
                    }
                }
                return new TokenNumber(double.Parse(value));
            }

            //string
            else if (Reader.Peek() == '"') {
                Reader.Read();
                var value = "";
                while (!Reader.Eof() && Reader.Peek() != '"') {
                    if (Reader.Peek() == '\\') {
                        Reader.Read();
                        if (Reader.Peek() == 'b') {
                            value += '\b';
                        }
                        else if (Reader.Peek() == 'f') {
                            value += '\f';
                        }
                        else if (Reader.Peek() == 'n') {
                            value += '\n';
                        }
                        else if (Reader.Peek() == 'r') {
                            value += '\r';
                        }
                        else if (Reader.Peek() == 't') {
                            value += '\t';
                        }
                        else if (Reader.Peek() == 'v') {
                            value += '\v';
                        }
                        else if (Reader.Peek() == '\'') {
                            value += '\'';
                        }
                        else if (Reader.Peek() == '\"') {
                            value += '\"';
                        }
                        else if (Reader.Peek() == '\\') {
                            value += '\\';
                        }
                        else {
                            return new TokenError("Unrecognized escape sequence", Reader.Row, Reader.Col);
                        }
                    }
                    else {
                        value += Reader.Peek();
                    }
                    Reader.Read();
                }
                if (Reader.Peek() != '"') {
                    return new TokenError("Expected '\"'", Reader.Row, Reader.Col);
                }
                Reader.Read();
                return new TokenString(value);
            }

            //symbol
            else if ("<>!+-=|&*/%^()".Contains(Reader.Peek().ToString())) {
                var value = Reader.Read().ToString();
                if ("<>!".Contains(value)) {
                    if (Reader.Peek() == '=') {
                        value += Reader.Read();
                    }
                }
                else if ("+-=|&".Contains(value)) {
                    if (value == Reader.Peek().ToString()) {
                        value += Reader.Read();
                    }
                }
                return new TokenSymbol(value);
            }

            //identy
            else if (Reader.Peek() == '_' || char.IsLetter(Reader.Peek())) {
                var value = Reader.Read().ToString();
                while (Reader.Peek() == '_' || char.IsLetterOrDigit(Reader.Peek())) {
                    value += Reader.Read();
                }

                if (value == "true") {
                    return new TokenBool(true);
                }

                else if (value == "false") {
                    return new TokenBool(false);
                }

                else if (new[] { "if", "for", "while", "func", "var", "set" }.Contains(value)) {
                    return new TokenKeyword(value);
                }

                else {
                    return new TokenIdent(value);
                }

            }

            //dosya bitti
            else if (Reader.Eof()) {
                return new TokenEof();
            }

            //sen kim köpek
            return new TokenError($"Unexpected token '{Reader.Peek()}'", Reader.Row, Reader.Col);

        }

    }

}