using System;
using System.Collections.Generic;
using System.Text;
using QuickWatchEx.QuickWatch.Interfaces;

namespace QuickWatchEx.QuickWatch {
    /// <summary>
    /// Expression
    /// </summary>
    public class Expression {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="name"></param>
        public Expression(IExpressionParameters parameters, string name = "Invalid Expression") {
            _name = name;
            _parameters = parameters;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="expr"></param>
        /// <param name="parentPath"></param>
        /// <param name="level"></param>
        private Expression(IExpressionParameters config, IDebugExpression expr, string parentPath, int level)
            : this(config) {
            if (expr == null || !expr.IsValidValue) {
                return;
            }

            _expr = expr;
            _name = expr.Name;
            _type = expr.Type;
            _value = expr.Value;
            _path = string.IsNullOrEmpty(parentPath) ? _name : string.Format("{0}.{1}", parentPath, _name); 
            _level = level;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="expr"></param>
        /// <param name="level"></param>
        /// <param name="startTime"></param>
        public Expression(IExpressionParameters parameters, IDebugExpression expr, int level, DateTime startTime) : this(parameters, expr, "", level) {
            LoadChildren(startTime);
        }

        private void LoadChildren(DateTime startTime) {
            bool timeOut = startTime + _parameters.EvaluationTimeout < DateTime.Now;

            foreach (var e in _expr.DataMembers) {
                if (e != null && e.IsValidValue) {
                    if (!timeOut && _level < _parameters.DepthOfSearch && !_parameters.IgnoredNode(e.Name)) {
                        AddChild(new Expression(_parameters, e, _path, _level + 1));
                    } else  {
                        AddChild(new DelayedExpression(_parameters, e, _path));
                    }
                }
            }

            foreach (var c in _children) {
                if (c.Loaded) {
                    c.LoadChildren(startTime);
                }
            }
        }

        /// <summary>
        /// Variable name
        /// </summary>
        public virtual string Name { get { return _name;  } }
        
        /// <summary>
        /// Variable value
        /// </summary>
        public virtual string Value { get { return _value; } }

        /// <summary>
        /// Variable type
        /// </summary>
        public virtual string Type { get { return _type; } }

        /// <summary>
        /// Variable path
        /// </summary>
        public virtual string Path { get { return _path; } }

        /// <summary>
        /// Retrieves children
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Expression> GetChildren() {
            foreach (var c in _children) {
                if (!_parameters.SearchEnabled || c.Visible) {
                    yield return c;
                }
            }
        }

        /// <summary>
        /// Checks if variable has children
        /// </summary>
        /// <returns></returns>
        public virtual bool HasChildren() {
            foreach (var c in _children) {
                if (!_parameters.SearchEnabled || c.Visible) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void UpdateVisibility() { //TODO: this should be separate class, something like visitor or may be something else
            _visible = false;

            if (!Loaded) {
                return; // Skip all non loaded items
            }

            foreach (var c in _children) {
                c.UpdateVisibility();
            }

            _visible = (_parameters.SearchInName && _parameters.Match(Name)) || (_parameters.SearchInValue && _parameters.Match(Value)) || HasChildren();
        }

        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            if (!Visible)
                return "";

            var res = new StringBuilder(string.Format("{0}.({1}) {2} = {3}\n", new string(' ', 4 * _level), _type, _name, _value));

            foreach (var c in _children) {
                if (c.Visible) {
                    res.Append(c.ToString());
                }
            }

            return res.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool Loaded { get { return true; } }

        /// <summary>
        /// 
        /// </summary>
        protected bool Visible { get { return _visible; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        protected void AddChild(Expression child) {
            _children.Add(child);
        }

        protected IDebugExpression _expr;
        protected string _name;
        protected string _value;
        protected string _type;
        protected List<Expression> _children = new List<Expression>();
        protected string _path;
        protected int _level;
        protected bool _visible;
        protected IExpressionParameters _parameters;
    }
}
