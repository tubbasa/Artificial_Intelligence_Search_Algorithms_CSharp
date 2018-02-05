using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = createTree();
            var root = getRootChild(list);
            var left = getLeftChild(list);
            var right = getRightChild(list);
            var level = countLevel(list,2);
            var bfs=BFS(list, "11");
        }

        static Tree createTree()
        {
            Tree myTreeroot = new Tree();
            myTreeroot.name = "53";
            myTreeroot.nodes = new List<Tree>();
            myTreeroot.nodes.Add(new Tree { name = "23", nodes = new List<Tree>() });
            myTreeroot.nodes.Add(new Tree { name = "17", nodes = new List<Tree>() });
            myTreeroot.nodes.First().nodes.Add(new Tree { name = "11", nodes = new List<Tree>() });
            myTreeroot.nodes.First().nodes.Add(new Tree { name = "4", nodes = new List<Tree>() });
            return myTreeroot;
        }

        static Tree getRootChild(Tree tree)
        {
            var nod = tree;
            return nod;
        }

        static Tree getLeftChild(Tree tree)
        {
            if (tree.nodes != null)
            {
                var left = tree.nodes.FirstOrDefault();
                return left;
            }
            else
            {
                return new Tree();

            }
        }

        static Tree getRightChild(Tree tree)
        {
            if (tree.nodes != null)
            {
                var left = tree.nodes.LastOrDefault();
                return left;
            }
            else
            {
                return new Tree();

            }
        }

        static int count(Tree atree)
        {
            var sayilan = 0;
            if (atree == null) //burada sonsuz döngüye giriyor 
            {
                sayilan = 0;
                return sayilan;

            }
            else
            {
                int left = 0;
                int right = 0;
                if (atree != null)
                {
                    left += count(getLeftChild(atree));
                }
                else
                {
                    left += 0;
                }

                if (atree != null)
                {
                    right += count(getRightChild(atree));
                }
                else
                {
                    right += 0;
                }

                return (1 + left + right);
            }





        }

        static int countLevel(Tree tree, int limit)
        {
            if (tree == null) //burada sonsuz döngüye giriyor 
            {
             
                return 0;

            }

            if (limit==0)
            {
                return 0;
            }
            else
            {
                var sayim = 1 + (countLevel(getRightChild(tree), (limit - 1))+(countLevel(getLeftChild(tree),(limit-1))));
                return sayim;
            }
        }

        static int level(Tree tree, string nodeName)
        {
            if (tree==null)
            {
                return 0;
            }

            if (getRootChild(tree).name==nodeName)
            {
                return 1;
            }
            else
            {
                var sayim = level(getLeftChild(tree), nodeName) + level(getRightChild(tree), nodeName);
                if (sayim>0)
                {
                    return sayim+1;
                }
                else
                {
                    return 0;
                }
            }

        }

        static object BFS(Tree tree, string nodeName)
        {
           return countLevel(tree, (level(tree, nodeName)));
        }
    }
    class Tree
    {
        public string name { get; set; }
        public List<Tree> nodes { get; set; }
    }
}
