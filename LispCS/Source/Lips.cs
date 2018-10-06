using System;
using System.Diagnostics;

namespace Source
{
    public abstract class Token { }

    public class TokenError : Token {
        public string Message;
        public int Row;
        public int Col;

        public TokenError(string msg, int row, int col) {
            Message = msg;
            Row = row;
            Col = col;
            // throw new Exception(msg);
        }
    }

    public class TokenNumber: Token {
        public double Value;
        public TokenNumber(double value){
            Value = value;
        }
    }

    public class Lips {
        private string Input;
        private int Index;
        private int Row;
        private int Col;
        
        private char Read(){
            if(Index >= Input.Length){
                return default(char);
            }
            var chr = this.Input[Index++];
            if(chr == '\n') { 
                Row++;
                Col = 0;
            }
            else{
                Col++;
            }
            return chr;
        }

        public char Peak(){
            if(Index >= Input.Length){
                return default(char);
            }
            return Input[Index];
        }

        public Token GetToken(){
            // (print concat("hede " (+ 1 2))) -----> hede 3
            while(true){

                // eat whitespace
                if(char.IsWhiteSpace(Peak())){
                    Read();
                    while(char.IsWhiteSpace(Peak())) { 
                        Read();
                    }
                }
                // number token 123.456E+789
                if(char.IsDigit(Peak())){
                    string val_stack = Read().ToString();
                    while(char.IsDigit(Peak())) { 
                        val_stack += Read();
                    }
                    if(Peak() == '.'){
                        val_stack += Read();
                        if(char.IsDigit(Peak())){
                            val_stack += Read();
                            while(char.IsDigit(Peak())) { 
                                val_stack += Read();
                            }
                        }
                        else{
                            return new TokenError($"Expected digit but found {Peak()}. Kiss you.", Row, Col);
                        }
                        if(Peak() == 'e' || Peak() == 'E'){
                            val_stack += Read();
                            if(Peak() == '+' || Peak() == '-'){
                                val_stack += Read();
                            }
                            if(char.IsDigit(Peak())){
                                val_stack += Read();
                                while(char.IsDigit(Peak())) { 
                                    val_stack += Read();
                                }
                            }
                            else{
                                return new TokenError("Invalid exponential expression. Kiss you.", Row, Col);
                            }
                        }
                    }
                    return new TokenNumber(double.Parse(val_stack));
                }
            }
        }

        public Token Eval(string str){
            this.Input = str;
            return GetToken();
        }
    }
}
