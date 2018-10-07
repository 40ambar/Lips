using System.Collections.Generic;

namespace Source.Asts {

    public class AstWhile : Ast {

        private Ast condition;
        private Ast body;

        public AstWhile(Ast condition, Ast body) {
            this.condition = condition;
            this.body = body;
        }

        public override object Eval(Context context) {
            var ret = new List<object>();
            context = context.Extend();
            while ((bool)condition.Eval(context)) {
                ret.Add(body.Eval(context));
            }
            return ret;
        }

    }

}