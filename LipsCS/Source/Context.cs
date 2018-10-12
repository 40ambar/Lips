using System;
using System.Collections.Generic;

namespace Source{

    public class Context {

        private Context parent = null;
        private Dictionary<string, object> variables = new Dictionary<string, object>();

        public Context Extend() {
            return new Context() {
                parent = this
            };
        }

        public Context Lookup(string name) {
            var context = this;
            while (context != null && !context.variables.ContainsKey(name)) {
                context = context.parent;
            }
            return context;
        }

        public object Define(string name, object value) {
            var context = Lookup(name);
            if (context != null) {
                throw new Exception($"Variable already defined '{name}'.");
            }
            return variables[name] = value;
        }

        public object Get(string name) {
            var context = Lookup(name);
            if (context == null) {
                throw new Exception($"Undefined variable '{name}'.");
            }
            return context.variables[name];
        }

        public object Set(string name, object value) {
            var context = Lookup(name);
            if (context == null) {
                throw new Exception($"Undefined variable '{name}'.");
            }
            return context.variables[name] = value;
        }

    }

}