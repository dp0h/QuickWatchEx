using System.Collections.Generic;
using QuickWatchEx.QuickWatch;
using QuickWatchEx.QuickWatch.Interfaces;

namespace QuickWatchEx.TestUI {
    class DebuggerExpressionMock : IDebugExpression {
        public DebuggerExpressionMock(string name, string type, string value) {
            _name = name;
            _type = type;
            _value = value;
            _children = new List<IDebugExpression>();
        }

        public IEnumerable<IDebugExpression> DataMembers {
            get {
                return _children;
            }
        }

        public bool IsValidValue { get { return true; } }

        public string Name { get { return _name; } }

        public string Type { get { return _type; } }
        
        public string Value { get { return _value; }  }

        public void AddChild(IDebugExpression child) {
            _children.Add(child);
        }

        readonly string _name;
        readonly string _type;
        readonly string _value;
        readonly List<IDebugExpression> _children;
    }
}
