namespace Source.Asts {

    public class AstAdd : Ast {

        public Ast[] values;

        public AstAdd(Ast[] values) {
            this.values = values;
        }

        public override object Eval(Context context) {
            var ret = (double)values[0].Eval(context);
            for (var i = 1; i < values.Length; i++) {
                ret += (double)values[i].Eval(context);
            }
            return ret;
        }

    }

}