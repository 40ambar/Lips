namespace Source.Tokens {

    public class TokenError : Token {
        public string Message;
        public int Row;
        public int Col;
        public TokenError(string msg, int row, int col) {
            Message = msg;
            Row = row;
            Col = col;
        }
    }

}