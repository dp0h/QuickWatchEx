using System.Collections.Generic;
using QuickWatchEx.QuickWatch.Interfaces;

namespace QuickWatchEx.QuickWatch {
    /// <summary>
    /// DelayedExpression
    /// </summary>
    class DelayedExpression : Expression {
        public DelayedExpression(IExpressionParameters parameters, IDebugExpression expr, string parentPath)
            : base(parameters) 
        {
            _expr = expr;
            _parentPath = parentPath;
        }

        private void Load() {
            if (!Loaded) {
                _name = _expr.Name;
                _type = _expr.Type;
                _value = _expr.Value;
                _path = string.Format("{0}.{1}", _parentPath, _name); 

                foreach (IDebugExpression e in _expr.DataMembers) {
                    if (e != null && e.IsValidValue) {
                        AddChild(new DelayedExpression(_parameters, e, _path));
                    }
                }
                _expr = null; // This is how we distinguish if the object is loaded
            }
        }

        protected override bool Loaded {
            get {
                return _expr == null;
            }
        }

        public override string Name {
            get {
                Load();
                return base.Name;
            }
        }

        public override string Value { 
            get {
                Load();
                return base.Value;
            } 
        }

        public override string Type { 
            get {
                Load();
                return base.Type;
            }
        }

        public override string Path { 
            get { 
                Load();
                return base.Path;
            } 
        }

        public override bool HasChildren() {
            Load();
            return base.HasChildren();
        }

        public override IEnumerable<Expression> GetChildren() {
            Load();
            return base.GetChildren();
        }

        private readonly string _parentPath;
    }
}
