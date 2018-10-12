using System;
using System.Collections.Generic;

namespace Source{

    public class Context {

        private Context parent = null;
        private Dictionary<string, Value> variables = new Dictionary<string, Value>();

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

        public Value Define(string name, Value value) {
            var context = Lookup(name);
            if (context != null) {
                throw new Exception($"Variable already defined '{name}'.");
            }
            return variables[name] = value;
        }

        public Value Get(string name) {
            var context = Lookup(name);
            if (context == null) {
                throw new Exception($"Undefined variable '{name}'.");
            }
            return context.variables[name];
        }

        public Value Set(string name, Value value) {
            var context = Lookup(name);
            if (context == null) {
                throw new Exception($"Undefined variable '{name}'.");
            }
            return context.variables[name] = value;
        }

    }

}