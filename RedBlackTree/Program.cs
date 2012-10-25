using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedBlackTree {
    class Program {
        static void Main(string[] args) {
            //int[] nums = { 21, 16, 22, 7, 5, 1, 12, 18, 2, 10, 0, 4, 23, 24, 8, 15, 19, 20, 6, 3, 13, 14, 9, 11, 17 };
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            //int[] nums = { 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            //int[] nums = { 4, 6, 7, 15, 1, 8, 2, 18, 11, 20, 19, 3, 16, 14, 5, 9, 10, 13, 17, 12 };
            var tree = new RedBlackTree<int>();

            Console.Write("Wild list:\n    ");
            foreach (var n in nums) {
                tree.Add(n);
                Console.Write(n + " ");
            }

            Console.Write("\n\nInOrder:\n   ");
            foreach (var i in tree)
                Console.Write(" {0}", i);

            Console.Write("\n\nWrite tree:\n{0}", tree.ToText());

            Console.ReadKey();
        }
    }
}
