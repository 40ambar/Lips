using System;

namespace Source.Asts {

    public class AstFunction : Ast {

        private string[] Variables;
        private Ast Body;

        public AstFunction(string[] variables, Ast body) {
            Variables = variables;
            Body = body;
        }

        public override object Eval(Context context) {
            return new Func<object[], object>((arguments) => {

                if (Variables.Length != arguments.Length) {
                    throw new Exception("Invalid parameter");
                }

                context = context.Extend();
                for (int i = 0; i < arguments.Length; i++) {
                    context.Define(Variables[i], arguments[i]);
                }
                return Body.Eval(context);

            });
        }

    }

}