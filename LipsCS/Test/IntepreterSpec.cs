using Xunit;
using Source;
using System;

namespace Test {

    public class IntepreterSpec {

        private object Eval(Ast ast) {
            return ast.Eval(new Context());
        }

        [Fact]
        public void NumberTest(){
            Assert.Equal(
                Eval(new Literal(4.5)),
                4.5
            );
        } 

        [Fact]
        public void StringTest() {
            Assert.Equal(
                Eval(new Literal("40 ambar")),
                "40 ambar"
            );
        }

        [Fact]
        public void BooleanTest() {
            Assert.Equal(
                Eval(new Literal(true)),
                true
            );
        }

        // [Fact]

        // public void ExpressionTest() {
        //     Assert.Equal(
        //         Assert.IsType<Boolean>(Eval(new Boolean(true))).Value,
        //         true
        //     );
        // }
    }
}