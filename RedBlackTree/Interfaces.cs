using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedBlackTree {
    interface IRedBlackNode<T>: 
        IEnumerable<IRedBlackNode<T>>, 
        IComparable<IRedBlackNode<T>> 
           where T: IComparable<T>
    {
        //Data and properties
        T Value { get; set; }
        bool Red { get; set; }
        int Count { get; }

        //Links
        IRedBlackNode<T> Left { get; set; }
        IRedBlackNode<T> Right { set; get; }

        //Methods
        IRedBlackNode<T> Add(IRedBlackNode<T> node);
        bool Includes(T value);
        void ToText(StringBuilder text, int column = 0);
    }
}
