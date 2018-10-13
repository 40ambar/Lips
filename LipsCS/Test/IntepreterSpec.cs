using Xunit;
using Source;
using System;

namespace Test {

    public class IntepreterSpec {

        private object Eval(Ast ast) {
            return ast.Eval(new Context());
        }

        [Fact]
        public void LiteralTest(){
            Assert.Equal(
                4.5,
                Eval(new Literal(4.5))
            );
            Assert.Equal(
                "40 ambar",
                Eval(
                    new Literal("40 ambar")
                )
            );
            Assert.True(
                (bool)Eval(
                    new Literal(true)
                )
            );
        }

        [Fact]
        public void IfTest() {
            Assert.Equal(
                "dogru",
                Eval(
                    new If(
                        new Literal(true), 
                        new Literal("dogru"), 
                        new Literal("yanlis")
                    )
                )
            );
            Assert.Equal(
                "yanlis",
                Eval(
                    new If(
                        new Literal(false), 
                        new Literal("dogru"), 
                        new Literal("yanlis")
                    )
                )
            );
        }

        [Fact]
        public void ForTest() {
            Assert.Collection(
                Assert.IsType<object[]>(
                    Eval(
                        new For(
                            "i",
                            new Literal(0.0),
                            new Literal(10.0),
                            new Literal(2.0),
                            new Get("i")
                        )
                    )
                ),
                i => Assert.Equal(0.0, i),
                i => Assert.Equal(2.0, i),
                i => Assert.Equal(4.0, i),
                i => Assert.Equal(6.0, i),
                i => Assert.Equal(8.0, i),
                i => Assert.Equal(10.0, i)
            );
        }

        [Fact]
        public void WhileTest() {
            Assert.Collection(
                Assert.IsType<object[]>(
                    Eval(
                        new List(
                            new Def("i", new Literal(0.0)),
                            new While(
                                new Operator("<",
                                    new Get("i"),
                                    new Literal(3.0)
                                ),
                                new Operator("++",
                                    new Get("i")
                                )
                            )
                        )
                    )
                ),
                j => Assert.Equal(0.0, j),
                j => Assert.Collection(
                    Assert.IsType<object[]>(j),
                    i => Assert.Equal(0.0, i),
                    i => Assert.Equal(1.0, i),
                    i => Assert.Equal(2.0, i)
                )
            );
        }

        [Fact]
        public void LambdaTest() {
            Assert.Equal(
                "guzel",
                Eval(
                    new Call(
                        new Lambda(
                            new[]{ "x", "y" }, 
                            new Literal("guzel")
                        ),
                        new Literal("x degeri"), 
                        new Literal("y degeri")
                    )
                ) 
            );
            Assert.Equal(
                3.0,
                Eval(
                    new Call(
                        new Lambda(
                            new[]{ "x", "y" }, 
                            new Operator("+", 
                                new Get("x") , 
                                new Get("y")
                            )
                        ),
                        new Literal(1.0), 
                        new Literal(2.0)
                    )
                )
            );
        }

        [Fact]
        public void VariableTest(){
            Assert.Collection(
                Assert.IsType<object[]>(
                    Eval(
                        new List(
                            new Def("x", new Literal(1.0)),
                            new Set("x", new Literal(2.0)),
                            new Def("y", new Literal(3.0)),
                            new Get("x"),
                            new Get("y")
                        )
                    )
                ),
                j => Assert.Equal(1.0, j),
                j => Assert.Equal(2.0, j),
                j => Assert.Equal(3.0, j),
                j => Assert.Equal(2.0, j),
                j => Assert.Equal(3.0, j)
            );
        }

    }
}