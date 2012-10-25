using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedBlackTree {
    class RedBlackTree<T>: IEnumerable<T> where T: IComparable<T> {
        private IRedBlackNode<T> root = new NullTreeNode<T>();

        //Properties
        public int Count {
            get { return root.Count; }
        }

        //Methods
        public void Add(T value) {
            root = root.Add(new TreeNode<T>(value));
        }

        //Writer
        public string ToText() {
            var text = new StringBuilder();
            root.ToText(text);
            return text.ToString();
        }

        //Enumerator
        public IEnumerator<T> GetEnumerator() {
            foreach (var i in root)
                yield return i.Value;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
