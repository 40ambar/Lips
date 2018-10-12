namespace Source.Tokens {

    public class TokenMultilineComment : Token {
        public string Value;
        public TokenMultilineComment(string value) {
            Value = value;
        }
    }

}