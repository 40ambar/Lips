namespace Source {

    public class Reader {

        public string Source { get; private set; }
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
            return Eof() ? default(char) : Source[Index];
        }

        public char Read() {
            if (Eof()) {
                return default(char);
            }
            else {
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

}