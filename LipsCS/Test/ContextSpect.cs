using Xunit;
using System;
using Source;

namespace Test {

    public class ContextSpect {

        [Fact]
        public void ExistingVariable() {
            var context = new Context();
            context.Define("test", 123);
            var exception = Assert.Throws<Exception>(() => context.Define("test", 456));
            Assert.Equal($"Variable already defined 'test'.", exception.Message);
        }

        [Fact]
        public void UndefinedVariable() {
            var context = new Context();
            var exception = Assert.Throws<Exception>(() => context.Set("test", 123));
            Assert.Equal($"Undefined variable 'test'.", exception.Message);
        }

        [Theory]
        [InlineData("StringVariable", "abc")]
        [InlineData("NumberVariable", 123)]
        public void GetSetTest(string name, object value) {
            var context = new Context();
            context.Define(name, value);
            Assert.Equal(context.Get(name), value);
        }


    }

}