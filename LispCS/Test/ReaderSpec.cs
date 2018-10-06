using System;
using Xunit;
using Source;

namespace Test {

    public class ReaderSpec {

        [Fact]
        public void Should_parse_number_integer() {
            var lips = new Lips();
            Assert.Equal(lips.Eval("234"), 234);
        }

    }

}