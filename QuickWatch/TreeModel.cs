using System;
using System.Collections;
using Aga.Controls.Tree;

namespace QuickWatchEx.QuickWatch {
    /// <summary>
    /// TreeModel 
    /// </summary>
    public class TreeModel : ITreeModel {
        public TreeModel(Expression root) {
            _root = root;
        }

        public IEnumerable GetChildren(TreePath path) {
            if (path.LastNode == null) {
                if (_root != null) {
                    yield return _root;
                }
            } else if (path.LastNode is Expression) {
                var o = (Expression)path.LastNode;

                foreach (var c in o.GetChildren()) {
                    yield return c;
                }
            }
        }

        public bool IsLeaf(TreePath path) {
            if (path.LastNode != null && path.LastNode is Expression) {
                return !((Expression)path.LastNode).HasChildren();
            }
            return true;
        }

        public void Update(Expression root) {
            _root = root;
            if (StructureChanged != null) {
                StructureChanged(this, new TreePathEventArgs());
            }
        }

        public override string ToString() {
            return _root.ToString();
        }

        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;
        public event EventHandler<TreePathEventArgs> StructureChanged;

        Expression _root;
    }
}
