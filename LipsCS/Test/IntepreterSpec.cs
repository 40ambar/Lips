using Xunit;
using Source;
using System;

namespace Test {

    public class IntepreterSpec {

        private Value Eval(IAst ast) {
            return ast.Eval(new Context());
        }

        [Fact]
        public void NumberTest(){
            Assert.Equal(
                Assert.IsType<Number>(Eval(new Number(4.5))).Value,
                4.5
            );
        } 
    }
}