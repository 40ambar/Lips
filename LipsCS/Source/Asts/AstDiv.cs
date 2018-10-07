namespace Source.Asts {

    public class AstDiv : Ast {

        private Ast[] Values;

        public AstDiv(Ast[] values) {
            Values = values;
        }

        public override object Eval(Context context) {
            var ret = (double)Values[0].Eval(context);
            for (var i = 1; i < Values.Length; i++) {
                ret /= (double)Values[i].Eval(context);
            }
            return ret;
        }

    }

}