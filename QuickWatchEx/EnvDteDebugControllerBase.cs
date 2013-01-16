using System;
using EnvDTE80;
using QuickWatchEx.QuickWatch;

namespace QuickWatchEx {
    /// <summary>
    /// EnvDteDebugControllerBase
    /// </summary>
    class EnvDteDebugControllerBase : DebugControllerBase {
        public EnvDteDebugControllerBase(DTE2 dte, string expression, QuickWatchConfig config)
            : base(expression, config) {
            _dte = dte;
            Expression = expression;
        }

        public override string Expression {
            set {
                _root = string.IsNullOrWhiteSpace(value) ? new Expression(this) : new Expression(this, new EnvDteDebugExpression(_dte.Debugger.GetExpression(value)), 0, DateTime.Now);
                UpdateTree();
            }
        }

        private readonly DTE2 _dte;
    }
}
