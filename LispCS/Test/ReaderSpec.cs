using Source;
using Xunit;

namespace Test {

    public class ReaderSpec {

        [Fact]
        public void RowColTest() {
            var reader = new Reader("ab\ncd");

            //a
            Assert.Equal(0, reader.Col);
            Assert.Equal(0, reader.Row);

            //b
            reader.Read();
            Assert.Equal(1, reader.Col);
            Assert.Equal(0, reader.Row);

            //new line
            reader.Read();
            Assert.Equal(2, reader.Col);
            Assert.Equal(0, reader.Row);

            //c
            reader.Read();
            Assert.Equal(0, reader.Col);
            Assert.Equal(1, reader.Row);

            //d
            reader.Read();
            Assert.Equal(1, reader.Col);
            Assert.Equal(1, reader.Row);

        }

        [Fact]
        public void EofTest() {
            var reader = new Reader("abc\ndef");

            //read 6 char
            for (var i = 0; i < 6; i++) {
                reader.Read();
            }

            //not yet
            Assert.False(reader.Eof());

            //last character
            Assert.Equal('f', reader.Read());

            //one more is eof
            Assert.True(reader.Eof());

            //some extra reads
            reader.Read();
            reader.Read();
            reader.Read();
            reader.Read();

            //still eof 
            Assert.True(reader.Eof());

        }

    }

}
