namespace Source {

    public class Reader {

        public readonly string Source;
        public int Index { get; private set; }
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Reader(string source) {
            Source = source;
        }

        public bool Eof() {
            return Index >= Source.Length;
        }

        public char Peek() {
            if (Eof()) {
                return default(char);
            }
            return Source[Index];
        }

        public char Read() {
            if (Eof()) {
                return default(char);
            }
            var chr = Source[Index++];
            if (chr == '\n') {
                Row++;
                Col = 0;
            }
            else {
                Col++;
            }
            return chr;
        }

    }

}