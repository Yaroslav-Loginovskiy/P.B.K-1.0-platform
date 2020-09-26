using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizPrototype.Data.Models
{

  public  class TreeStructureTopics
    {
        static int counter = 0;
        static int totalSum = 0;
        static bool startPrinting = false;

      public Topic GetTopicName(string topicName)
        {
            Tree<Topic> tree = new Tree<Topic>(new Topic() { Name = "General" });
            tree.Root.AddRangeOfChilds(new List<TreeNode<Topic>>()
            {
                new TreeNode<Topic>(new Topic() { Name = "Animals" }),
                new TreeNode<Topic>(new Topic() { Name = "Science"}),
                new TreeNode<Topic>(new Topic() { Name = "Architecture"})
            });

            tree.Root.GetChild(0).AddChild(new TreeNode<Topic>(new Topic() { Name = "Mammals" }));
            tree.Root.GetChild(0).GetChild(0).AddChild(new TreeNode<Topic>(new Topic() { Name = "Marsupials" }));
            tree.Root.GetChild(1).AddChild(new TreeNode<Topic>(new Topic() { Name = "Mathematics" }));
            tree.Root.GetChild(1).GetChild(0).AddChild(new TreeNode<Topic>(new Topic() { Name = "Algebra" }));
            tree.Root.GetChild(2).AddChild(new TreeNode<Topic>(new Topic() { Name = "Volumetric" }));
            tree.Root.GetChild(2).GetChild(0).AddChild(new TreeNode<Topic>(new Topic() { Name = "Residential" }));
            var topic = tree.FindTopicByName(null, new Topic { Name = topicName });
            return topic;
        }

        public void GetTreeTopic()
        {
           
            Tree<Topic> tree = new Tree<Topic>(new Topic() { Name = "General" });
            tree.Root.AddRangeOfChilds(new List<TreeNode<Topic>>()
            {
                new TreeNode<Topic>(new Topic() { Name = "Animals" }),
                new TreeNode<Topic>(new Topic() { Name = "Science"}),
                new TreeNode<Topic>(new Topic() { Name = "Architecture"})
            });

            tree.Root.GetChild(0).AddChild(new TreeNode<Topic>(new Topic() { Name = "Mammals" }));
            tree.Root.GetChild(0).GetChild(0).AddChild(new TreeNode<Topic>(new Topic() { Name = "Marsupials" }));
            tree.Root.GetChild(1).AddChild(new TreeNode<Topic>(new Topic() { Name = "Mathematics" }));
            tree.Root.GetChild(1).GetChild(0).AddChild(new TreeNode<Topic>(new Topic() { Name = "Algebra" }));
            tree.Root.GetChild(2).AddChild(new TreeNode<Topic>(new Topic() { Name = "Volumetric" }));
            tree.Root.GetChild(2).GetChild(0).AddChild(new TreeNode<Topic>(new Topic() { Name = "Residential" }));
            tree.TraverseDFS();

          
        }

        public class TreeNode<T> where T : Topic
        {
            private T value;
            private bool hasParent;
            private List<TreeNode<T>> children;

            public TreeNode(T value)
            {
                if (value == null)
                    throw new ArgumentNullException();

                this.value = value;
                this.children = new List<TreeNode<T>>();
            }

            public T Value
            {
                get
                {
                    return this.value;

                }
                set
                {

                    this.value = value;
                }

            }

            public int ChildrenCount
            {
                get
                {

                    return this.children.Count;

                }
            }

            public void AddChild(TreeNode<T> child)
            {
                if (child == null)
                    throw new ArgumentNullException();
                if (child.hasParent == true)
                    throw new ArgumentException("This node already has a parent");

                child.hasParent = true;
                this.children.Add(child);
            }

            public void AddRangeOfChilds(List<TreeNode<T>> childs)
            {
                if (childs == null || childs.Count == 0)
                {
                    throw new ArgumentNullException();
                }
                if (childs.Where(s => s.hasParent == true).Any())
                {
                    throw new ArgumentException("This node already has a parent");
                }

                childs.ForEach(c => { c.hasParent = true; this.children.Add(c); });

            }

            public TreeNode<T> GetChild(int index)
            {
                return this.children[index];
            }

            public List<TreeNode<T>> GetChildren()
            {
                return this.children;
            }


        }

        public class Tree<T> where T : Topic, new()
        {
            private TreeNode<T> root;

            public Tree(T value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot insert null");
                }

                this.root = new TreeNode<T>(value);
            }

            public Tree(T value, params Tree<T>[] children) :
                this(value)
            {
                foreach (Tree<T> child in children)
                {
                    this.root.AddChild(child.root);
                }
            }

            public TreeNode<T> Root
            {
                get { return this.root; }
            }

            private T foundValue;

            public T FindTopicByName(TreeNode<T> node, T value)
            {

                TreeNode<T> currentNode = node;

                if (currentNode == null)
                {
                    currentNode = root;
                }
                if (currentNode.Value.Name == value.Name)
                {
                    foundValue = currentNode.Value;
                }
                int childrenCount = currentNode.ChildrenCount;

                for (int i = 0; i < childrenCount; i++)
                {
                    FindTopicByName(currentNode.GetChild(i), value);
                }

                return foundValue;
            }

            private void PrintDFS(TreeNode<T> root, string spaces)
            {

                if (this.root == null)
                {
                    return;
                }
                Console.WriteLine(spaces + root.Value.Name);
                Console.WriteLine();
                TreeNode<T> child = null;
                for (int i = 0; i < root.ChildrenCount; i++)
                {
                   
                    child = root.GetChild(i);
                    PrintDFS(child, spaces + " --- ");
                }
            }


           


            TreeNode<T> currentNode;

            public void PopulateTree(TreeNode<T> value = default)
            {

                if (value == default)
                {
                    Console.WriteLine("Insert your topic");
                    string topicName = Console.ReadLine();
                    T topic = new T() { Name = topicName };

                    currentNode = root;
                    currentNode.AddChild(new TreeNode<T>(topic));

                }

                else
                {
                    currentNode = value;
                    Console.WriteLine("Insert Topic Name");
                    string topicName = Console.ReadLine();
                    T topic = new T() { Name = topicName };
                    currentNode.AddChild(new TreeNode<T>(topic));
                }


                Console.WriteLine(@"m - more topics?
                    s - select subtopic 
                    e - exit");
                string userRespone = Console.ReadLine();

                if (userRespone == "m")
                {
                    PopulateTree(currentNode);
                }
                else
                {

                    if (userRespone == "e")
                    {
                        return;
                    }

                    if (userRespone == "s")
                    {
                        foreach (var children in currentNode.GetChildren())
                        {
                            Console.WriteLine(children.Value.Name);
                        }


                        Console.WriteLine("Select subtopic name");
                        string selectedTopic = Console.ReadLine();
                        currentNode = currentNode.GetChildren()
                            .Where(t => t.Value.Name == selectedTopic)
                            .FirstOrDefault();

                        PopulateTree(currentNode);
                    }

                }



            }
          public void FindNumber(TreeNode<T> node, T value)
            {

                TreeNode<T> currentNode = node;

                if (currentNode == null)
                {
                    currentNode = root;
                    totalSum += Convert.ToInt32(root.Value);
                }
                if (currentNode.Value.Equals(value))
                {
                    counter++;
                }
                int childrenCount = currentNode.ChildrenCount;

                for (int i = 0; i < childrenCount; i++)
                {
                    FindNumber(currentNode.GetChild(i), value);
                }
            }



            public void SumAllNodes(TreeNode<T> node, int n)
            {
                TreeNode<T> currentNode = node;

                if (currentNode == null)
                {
                    currentNode = root;
                }

                Type paramType = typeof(T);
                if (Type.GetTypeCode(paramType) == TypeCode.Int32)
                {
                    Console.WriteLine($"{currentNode.Value} is integer ");
                }

                int levelSum = 0;

                int childrenCount = currentNode.ChildrenCount;

                for (int i = 0; i < childrenCount; i++)
                {
                    int valueOfCurrentNode = Convert.ToInt32(currentNode.GetChild(i).Value);
                    levelSum += valueOfCurrentNode; // счетаем для каждого уровня
                    SumAllNodes(currentNode.GetChild(i), n);
                }
                totalSum += levelSum;
            }

            public bool PrintWithLeafsOnly(TreeNode<T> node)
            {
                TreeNode<T> currentNode = node;

                if (currentNode == null)
                {
                    currentNode = root;
                }

                int childrenCount = currentNode.ChildrenCount;

                bool[] leafs = new bool[childrenCount];

                if (childrenCount == 0)
                    return true;

                for (int i = 0; i < childrenCount; i++)
                {
                    leafs[i] = PrintWithLeafsOnly(currentNode.GetChild(i));
                }

                if (!leafs.Contains(false) && childrenCount > 0)
                    Console.WriteLine($"{currentNode.Value} contains only leafs");

                return true;
            }

            public void TraverseDFS()
            {
                this.PrintDFS(this.root, string.Empty);
            }
        }


    }
}
