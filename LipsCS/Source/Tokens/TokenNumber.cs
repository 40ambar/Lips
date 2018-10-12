namespace Source.Tokens {

    public class TokenNumber : Token {
        public double Value;
        public TokenNumber(double value) {
            Value = value;
        }
    }

}