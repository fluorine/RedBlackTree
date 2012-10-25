using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedBlackTree {
    class TreeNode<T>: IRedBlackNode<T> where T: IComparable<T> {
        public T    Value { get; set; }
        public bool Red { get; set; }
        public int  Count { get; private set; }

        //Links
        private IRedBlackNode<T> left = new NullTreeNode<T>();
        public IRedBlackNode<T> Left {
            get { return left; }
            set {
                Count = 1 + Left.Count + Right.Count;
                left = value;
            }
        }

        private IRedBlackNode<T> right = new NullTreeNode<T>();
        public IRedBlackNode<T> Right {
            get { return right; }
            set {
                Count = 1 + Left.Count + Right.Count;
                right = value;
            }
        }

        //Constructor
        public TreeNode(T value) {
            if (value == null)
                throw new ArgumentNullException();

            Value = value;
            Count = 1;
            Red = true;
        }

        //Methods
        public IRedBlackNode<T> Add(IRedBlackNode<T> node) {
            switch (this.CompareTo(node)) {
                case 1:
                    Left = Left.Add(node);
                    break;
                case -1:
                    Right = Right.Add(node);
                    break;
                default:
                    Value = node.Value;
                    return this;
            }

            //Balance action
            //return this;
            return GetBalanced(this);
        }

        public bool Includes(T value) {
            switch (Value.CompareTo(value)) {
                case 1:
                    return Left.Includes(value);
                case -1:
                    return Right.Includes(value);
                default:
                    return true;
            }
        }

        public void ToText(StringBuilder text, int column = 1) {

            Left.ToText(text, column + 2);

            text.Append(' ', column);
            text.Append(Value);

            if (Red == true)
                text.Append('+');

            text.Append('\n');

            Right.ToText(text, column + 2);
        }

        //Balance
        private static IRedBlackNode<T> GetBalanced(IRedBlackNode<T> node) {
            if (node.Right.Red)
                node = rotateLeft(node);

            if (node.Left.Red && node.Left.Left.Red)
                node = rotateRight(node);

            if (node.Left.Red && node.Right.Red)
                split(node);

            return node;
        }

        private static IRedBlackNode<T> rotateRight(IRedBlackNode<T> node) {
            if (node.Left is TreeNode<T>) {
                var basis = node.Left;
                node.Left = basis.Right;
                basis.Right = node;

                bool color = node.Red;
                node.Red = basis.Red;
                basis.Red = color;

                return basis;
            }

            return node;
        }

        private static IRedBlackNode<T> rotateLeft(IRedBlackNode<T> node) {
            if (node.Right is TreeNode<T>) {
                var basis = node.Right;
                node.Right = basis.Left;
                basis.Left = node;

                bool color = node.Red;
                node.Red = basis.Red;
                basis.Red = color;

                return basis;
            }

            return node;
        }

        private static void split(IRedBlackNode<T> node) {
            node.Red = true;
            node.Left.Red = false;
            node.Right.Red = false;
        }

        //Enumerable
        public IEnumerator<IRedBlackNode<T>> GetEnumerator() {
            foreach (var i in Left)
                yield return i;

            yield return this;

            foreach (var i in Right)
                yield return i;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        //Comparer
        public int CompareTo(IRedBlackNode<T> other) {
            return Value.CompareTo(other.Value);
        }
    }

    //Null node
    class NullTreeNode<T> : IRedBlackNode<T> where T : IComparable<T> {
        public T Value {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public bool Red {
            get { return false; }
            set { }
        }

        public int Count {
            get { return 0; }
        }

        //Null links
        public IRedBlackNode<T> Left {
            get { return new NullTreeNode<T>(); }
            set { }
        }

        public IRedBlackNode<T> Right {
            get { return new NullTreeNode<T>(); }
            set { }
        }

        //Methods
        public IRedBlackNode<T> Add(IRedBlackNode<T> node) {
            return node;
        }

        public bool Includes(T value) {
            return false;
        }

        public void ToText(StringBuilder text, int column = 0) { }

        //Enumerator and comparer
        public IEnumerator<IRedBlackNode<T>> GetEnumerator() {
            if (this is TreeNode<T>)
                yield return this;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int CompareTo(IRedBlackNode<T> other) {
            throw new NotSupportedException();
        }
    }
}
