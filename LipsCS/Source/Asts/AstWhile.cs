using System.Collections.Generic;

namespace Source.Asts {

    public class AstWhile : Ast {

        private Ast Condition;
        private Ast Body;

        public AstWhile(Ast condition, Ast body) {
            Condition = condition;
            Body = body;
        }

        public override object Eval(Context context) {
            var ret = new List<object>();
            context = context.Extend();
            while ((bool)Condition.Eval(context)) {
                ret.Add(Body.Eval(context));
            }
            return ret;
        }

    }

}