using Source.Tokens;
using System.Linq;

namespace Source {

    public class Lexer {

        private Reader Reader;
        private string[] Reserved = new[] { "true", "false", "if", "for", "while", "func", "var", "set" };

        public Lexer(string source) {
            Reader = new Reader(source);
        }

        public Token Read() {

            // whitespace
            if (char.IsWhiteSpace(Reader.Peek())) {
                Read();
                while (char.IsWhiteSpace(Reader.Peek())) {
                    Read();
                }
            }

            //comment
            if (Reader.Peek() == ';') {
                Reader.Read();
                var value = "";
                while (!Reader.Eof() && Reader.Peek() != '\n') {
                    value += Read();
                }
                return new TokenComment(value);
            }

            // number
            else if (char.IsDigit(Reader.Peek())) {
                var value = Read().ToString();
                while (char.IsDigit(Reader.Peek())) {
                    value += Read();
                }
                if (Reader.Peek() == '.') {
                    value += Read();
                    if (char.IsDigit(Reader.Peek())) {
                        value += Read();
                        while (char.IsDigit(Reader.Peek())) {
                            value += Read();
                        }
                    }
                    else {
                        return new TokenError($"Expected digit but found '{Reader.Peek()}'.", Reader.Row, Reader.Col);
                    }
                    if (Reader.Peek() == 'e' || Reader.Peek() == 'E') {
                        value += Read();
                        if (Reader.Peek() == '+' || Reader.Peek() == '-') {
                            value += Read();
                        }
                        if (char.IsDigit(Reader.Peek())) {
                            value += Read();
                            while (char.IsDigit(Reader.Peek())) {
                                value += Read();
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
                Read();
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
                    Read();
                }
                if (Reader.Peek() != '"') {
                    return new TokenError("Expected '\"'", Reader.Row, Reader.Col);
                }
                Read();
                return new TokenString(value);
            }

            //symbol
            else if ("<>!+-=|&*/%^()".Contains(Reader.Peek().ToString())) {
                var value = Read().ToString();
                if ("<>!".Contains(value)) {
                    if (Reader.Peek() == '=') {
                        value += Read();
                    }
                }
                else if ("+-=|&".Contains(value)) {
                    if (value == Reader.Peek().ToString()) {
                        value += Read();
                    }
                }
                return new TokenSymbol(value);
            }

            //identy
            else if (Reader.Peek() == '_' || char.IsLetter(Reader.Peek())) {
                var value = Read().ToString();
                while (Reader.Peek() == '_' || char.IsLetterOrDigit(Reader.Peek())) {
                    value += Read();
                }
                if (Reserved.Contains(value)) {
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
            return new TokenError("Unexpected token '\"'", Reader.Row, Reader.Col);

        }

    }

}