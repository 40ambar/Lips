//using Source.Tokens;
//using System;
//using System.Diagnostics;
//using System.Linq;

//namespace Source{

//    public class Lips {

//        private string[] reserved = new[] { "true", "false", "if", "for", "while", "func", "var", "set" };
//        private string Input;
//        private int Index;
//        private int Row;
//        private int Col;

//        private bool Eof() {
//            return Index >= Input.Length;
//        }

//        private char Peek() {
//            if (Eof()) {
//                return default(char);
//            }
//            return Input[Index];
//        }

//        private char Read(){
//            if(Eof()) {
//                return default(char);
//            }
//            var chr = this.Input[Index++];
//            if(chr == '\n') { 
//                Row++;
//                Col = 0;
//            }
//            else{
//                Col++;
//            }
//            return chr;
//        }

//        //TODO: character escape
//        //TODO: multiline comment
//        private Token Token(){

//            // whitespace
//            if(char.IsWhiteSpace(Peek())){
//                Read();
//                while(char.IsWhiteSpace(Peek())) { 
//                    Read();
//                }
//            }

//            //comment
//            if (Peek() == ';') {
//                Read();
//                var value = "";
//                while (!Eof() && Peek() != '\n') {
//                    value += Read();
//                }
//                return new TokenComment(value);
//            }

//            // number
//            else if (char.IsDigit(Peek())) {
//                var value = Read().ToString();
//                while (char.IsDigit(Peek())) {
//                    value += Read();
//                }
//                if (Peek() == '.') {
//                    value += Read();
//                    if (char.IsDigit(Peek())) {
//                        value += Read();
//                        while (char.IsDigit(Peek())) {
//                            value += Read();
//                        }
//                    }
//                    else {
//                        return new TokenError($"Expected digit but found '{Peek()}'.", Row, Col);
//                    }
//                    if (Peek() == 'e' || Peek() == 'E') {
//                        value += Read();
//                        if (Peek() == '+' || Peek() == '-') {
//                            value += Read();
//                        }
//                        if (char.IsDigit(Peek())) {
//                            value += Read();
//                            while (char.IsDigit(Peek())) {
//                                value += Read();
//                            }
//                        }
//                        else {
//                            return new TokenError("Invalid exponential expression.", Row, Col);
//                        }
//                    }
//                }
//                return new TokenNumber(double.Parse(value));
//            }
              
//            //string
//            else if (Peek() == '"') {
//                Read();
//                var value = "";
//                while (!Eof() && Peek() != '"') {
//                    if (Peek() == '\\') {
//                        Read();
//                        if (Peek() == 'b') {
//                            value += '\b';
//                        }
//                        else if (Peek() == 'f') {
//                            value += '\f';
//                        }
//                        else if (Peek() == 'n') {
//                            value += '\n';
//                        }
//                        else if (Peek() == 'r') {
//                            value += '\r';
//                        }
//                        else if (Peek() == 't') {
//                            value += '\t';
//                        }
//                        else if (Peek() == 'v') {
//                            value += '\v';
//                        }
//                        else if (Peek() == '\'') {
//                            value += '\'';
//                        }
//                        else if (Peek() == '\"') {
//                            value += '\"';
//                        }
//                        else if (Peek() == '\\') {
//                            value += '\\';
//                        }
//                        else {
//                            return new TokenError("Unrecognized escape sequence", Row, Col);
//                        }
//                    }
//                    else {
//                        value += Peek();
//                    }
//                    Read();
//                }
//                if (Peek() != '"') {
//                    return new TokenError("Expected '\"'", Row, Col);
//                }
//                Read();
//                return new TokenString(value);
//            }

//            //symbol
//            else if ("<>!+-=|&*/%^()".Contains(Peek().ToString())) {
//                var value = Read().ToString();
//                if ("<>!".Contains(value)) {
//                    if (Peek() == '=') {
//                        value += Read();
//                    }
//                }
//                else if ("+-=|&".Contains(value)) {
//                    if (value == Peek().ToString()) {
//                        value += Read();
//                    }
//                }
//                return new TokenSymbol(value);
//            }

//            //identy
//            else if (Peek() == '_' || char.IsLetter(Peek())) {
//                var value = Read().ToString();
//                while (Peek() == '_' || char.IsLetterOrDigit(Peek())) {
//                    value += Read();
//                }
//                if (reserved.Contains(value)) {
//                    return new TokenKeyword(value);
//                }
//                else {
//                    return new TokenIdent(value);
//                }
//            }

//            //dosya bitti
//            else if (Eof()) {
//                return new TokenEof();
//            }

//            //sen kim köpek
//            return new TokenError("Unexpected token '\"'", Row, Col);

//        }

//        public Token Eval(string input) {
//            Input = input;
//            return Token();
//        }

//    }
//}