using AlgorithmsDataStructures2;
using System;
using System.Collections.Generic;

namespace BBST
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedBST bsTree = new BalancedBST();
            bsTree.CreateFromArray(new int[] { 15, 14, 13, 12, 11, 10, 9, 8,
                7, 6, 5, 4, 3, 2, 1} );

            Console.WriteLine("массив в формате BST:");
            foreach (var item in bsTree.BSTArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            bsTree.GenerateTree();
            Console.WriteLine("Узлы сформированного BST:");
            //bsTree.PrintNodes(bsTree.WideAllNodes());
            //bsTree.PrintNodes(bsTree.DeepAllNodes(0));

            Console.WriteLine(bsTree.IsBalanced(bsTree.Root));
            Console.ReadKey();
        }
    }
}
