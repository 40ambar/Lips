namespace Source.Asts {

    public class AstMul : Ast {

        private Ast[] Values;

        public AstMul(Ast[] values) {
            Values = values;
        }

        public override object Eval(Context context) {
            var ret = (double)Values[0].Eval(context);
            for (var i = 1; i < Values.Length; i++) {
                ret *= (double)Values[i].Eval(context);
            }
            return ret;
        }

    }

}