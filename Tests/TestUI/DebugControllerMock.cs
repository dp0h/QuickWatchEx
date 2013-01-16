using System;
using QuickWatchEx.QuickWatch;

namespace QuickWatchEx.TestUI {
    public class DebugControllerMock : DebugControllerBase {
        public DebugControllerMock () : base("Expression", new QuickWatchConfig()) {
            var root = new DebuggerExpressionMock("root", "root type", "root value");
            var c1 = new DebuggerExpressionMock("c1", "c1 type", "c1 value");
            var c2 = new DebuggerExpressionMock("c2", "c2 type", "c2 value");

            root.AddChild(c1);
            root.AddChild(c2);

            var c11 = new DebuggerExpressionMock("SomeText", "c11 type", "c1 value");
            var c12 = new DebuggerExpressionMock("Sometext", "c12 type", "c1 value");
            c1.AddChild(c11);
            c1.AddChild(c12);

            var c21 = new DebuggerExpressionMock("c21", "XXX", "??");
            var c22 = new DebuggerExpressionMock("c22", "??", "??");
            c2.AddChild(c21);
            c2.AddChild(c22);

            _root = new Expression(this, root, 0, DateTime.Now);
            _root.UpdateVisibility();

            _model = new TreeModel(_root);
        }

        public override string Expression {
            set { }
        }
    }
}
