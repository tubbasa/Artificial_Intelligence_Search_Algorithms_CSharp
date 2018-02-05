using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{

    class Program
    {
        static void Main(string[] args)
        {
            var list=createTree();
            var root = getRootChild(list);
            var left = getLeftChild(list);
            var right = getRightChild(list);
            Console.WriteLine("Root Ağacındaki node sayısı:"+count(list));
            Console.WriteLine("Sağ ağaçtaki node sayısı:"+count(right));
            Console.WriteLine("Sol ağaçtaki node sayısı:" + count(left));
            var d = DFS(list, "11");
            while (true)
            {
                Console.WriteLine("Girdiğiniz sayının ağaçta olup olmadığı/ var ise de kaç node'u olduğu araştırılacaktır. Lütfen bir sayı girin:");
                var number = Console.ReadLine();
                var dfs = DFS(list, number);
                if (Convert.ToInt32(dfs) == 0)
                {
                    Console.WriteLine("Aradığınız sayı ağaçta yok.");
                }
                else if (Convert.ToInt32(dfs) == 1)
                {
                    Console.WriteLine("Aradığınız sayı ağaçta var fakat alt node'u yok.");
                }
                else
                {
                    Console.WriteLine("Aradığınız sayı ağaçta var.Alt nodelarının sayısı:" + (Convert.ToInt32(dfs) -1));
                }
            }

            Console.Read();
        }

        static Tree createTree()
        {
            Tree myTreeroot= new Tree();
            myTreeroot.name = "53";
            myTreeroot.nodes = new List<Tree>();
            myTreeroot.nodes.Add(new Tree { name = "23", nodes = new List<Tree>() });
            myTreeroot.nodes.Add(new Tree { name = "17", nodes = new List<Tree>() });
            myTreeroot.nodes.First().nodes.Add(new Tree { name = "11",nodes = new List<Tree>()});
            myTreeroot.nodes.First().nodes.Add(new Tree { name = "4" ,nodes = new List<Tree>()});
            return myTreeroot;
        }

        static Tree getRootChild(Tree tree)
        {
            var nod = tree;
            return nod;
        }

        static Tree getLeftChild(Tree tree)
        {
            if (tree.nodes!=null)
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
               sayilan= 0;
                return sayilan;

            }
            else
            {
                int left = 0;
                int right = 0;
                if (atree!=null)
                {
                    left+=count(getLeftChild(atree));
                }
                else
                {
                    left += 0;
                }

                if (atree!=null)
                {
                    right+= count(getRightChild(atree));
                }
                else
                {
                    right += 0;
                }

                return (1 + left + right);
            }
          
            

        
            
        }

        static object DFS(Tree tree, string nodeName)
        {
            if (nodeName == getRootChild(tree).name)
            {
                return count(tree);
            }
            if (tree.nodes.Count==0)
            {
                return 0;
            }

         
            if (Convert.ToInt32(DFS(getLeftChild(tree), nodeName)) !=0)
            {
                return DFS(getLeftChild(tree), nodeName);
            }
            else
            {
                if (Convert.ToInt32(DFS(getRightChild(tree), nodeName)) != 0)
                {
                    return DFS(getRightChild(tree), nodeName);
                }
                else
                {
                    return 0;
                }
                
            }
         





            return 0;

        }
    }

    class Tree
    {
        public string name { get; set; }
        public List<Tree> nodes{ get; set; }
    }
}
