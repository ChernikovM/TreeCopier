using System;
using System.Collections.Generic;

namespace TreeCopier
{
    public static class TreeCopier
    {
        public static BinaryTree CopyTreeByNode(BinaryTree inputNode)
        {
            var result = new BinaryTree();

            while (inputNode.Parrent != null)
            {
                inputNode = inputNode.Parrent;
            }

            var copyQueue = new Queue<(BinaryTree, BinaryTree)>();

            copyQueue.Enqueue((result, inputNode));

            while(copyQueue.TryDequeue(out var currentPair))
            {
                currentPair.Item1.Payload = currentPair.Item2.Payload;
                //currentPair.Item1.Parrent = currentPair.Item2.Parrent;

                if(currentPair.Item2.LeftChild is not null)
                {
                    currentPair.Item1.LeftChild = new BinaryTree() { Parrent = currentPair.Item1};

                    copyQueue.Enqueue((currentPair.Item1.LeftChild, currentPair.Item2.LeftChild));
                }

                if (currentPair.Item2.RightChild is not null)
                {
                    currentPair.Item1.RightChild = new BinaryTree() { Parrent = currentPair.Item1 };

                    copyQueue.Enqueue((currentPair.Item1.RightChild, currentPair.Item2.RightChild));
                }
            }

            return result;
        }

        public static BinaryTree GetRandomNode(BinaryTree root, int treeSize)
        {
            var currentNode = root;
            var rnd = new Random(DateTime.Now.Millisecond);
            int maxDeepth = rnd.Next(1, treeSize / 4);

            while(maxDeepth > 0)
            {
                maxDeepth--;
                int direction = rnd.Next(0, 2);
                if(direction == 0)
                {
                    if(currentNode.LeftChild is not null)
                    {
                        currentNode = currentNode.LeftChild;
                        continue;
                    }
                    if (currentNode.RightChild is not null)
                    {
                        currentNode = currentNode.RightChild;
                        continue;
                    }
                    continue;
                }
                if (direction == 1)
                {
                    if (currentNode.RightChild is not null)
                    {
                        currentNode = currentNode.RightChild;
                        continue;
                    }
                    if (currentNode.LeftChild is not null)
                    {
                        currentNode = currentNode.LeftChild;
                        continue;
                    }
                    continue;
                }
            }

            return currentNode;

        }
    }
}
