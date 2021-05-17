using Newtonsoft.Json;
using System;

namespace TreeCopier
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialize Tree
            int treeSize = 1000;
            var tree = new BinaryTree();
            var rnd = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < treeSize; ++i)
            {
                tree.Add(rnd.Next(0, 1000));
            }
            #endregion

            var testNode = TreeCopier.GetRandomNode(tree, treeSize);

            var copy = TreeCopier.CopyTreeByNode(testNode);

            CheckResult(copy, tree);
        }

        public static void CheckResult(BinaryTree copy, BinaryTree input)
        {
            var copyJson = JsonConvert.SerializeObject(copy,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, MaxDepth = 2 });
            var treeJson = JsonConvert.SerializeObject(input,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, MaxDepth = 2 });

            if (copyJson != treeJson)
            {
                throw new Exception("Copy != Input.");
            }

            Console.WriteLine("Success");
        }
    }
}
