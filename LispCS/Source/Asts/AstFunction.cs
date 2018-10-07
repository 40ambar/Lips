using System;

namespace Source.Asts {

    public class AstFunction : Ast {

        public string[] variables;
        public Ast body;

        public AstFunction(string[] variables, Ast body) {
            this.variables = variables;
            this.body = body;
        }

        public override object Eval(Context context) {
            return new Func<object[], object>((arguments) => {

                if (variables.Length != arguments.Length) {
                    throw new Exception("Invalid parameter");
                }

                context = context.Extend();
                for (int i = 0; i < arguments.Length; i++) {
                    context.Define(variables[i], arguments[i]);
                }
                return body.Eval(context);

            });
        }

    }

}