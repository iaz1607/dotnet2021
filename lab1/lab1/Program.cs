using System;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;

namespace lab1
{
    class Node
    {
        public Node(int value)
        {
            this.value = value;
        }
        public void SetNext(Node n)
        {
            next = n;
        }

        public void SetPrev(Node n)
        {
            prev = n;
        }

        public int GetValue()
        {
            return value;
        }

        public Node GetNext()
        {
            return next;
        }

        public Node GetPrev()
        {
            return prev;
        }
        private int value;
        private Node next;
        private Node prev;
    }
    class MyList
    {
        public void Add(int value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.SetNext(newNode);
                newNode.SetPrev(Tail);
                Tail = newNode;
            }
        }

        public void RemoveNode(Node n)
        {
            if (n == Head && n == Tail)
            {
                Head = null;
                Tail = null;
            }
            else if (n == Head)
            {
                Head = Head.GetNext();
                Head.SetPrev(null);
            }
            else if (n == Tail)
            {
                Tail = Tail.GetPrev();
                Tail.SetNext(null);
            }
            else
            {
                n.GetNext().SetPrev(n.GetPrev());
                n.GetPrev().SetNext(n.GetNext());
            }
        }

        public Node GetHead()
        {
            return Head;
        }

        public Node GetTail()
        {
            return Tail;
        }
        public void PrintList()
        {
            if (GetHead() == null)
            {
                Console.WriteLine("List is empty!!!");
            }
            for (Node curNode = GetHead(); curNode != null; curNode = curNode.GetNext())
            {
                Console.Write(curNode.GetValue());
                if (curNode.GetNext() != null)
                {
                    Console.Write(" -> ");
                }
            }
            Console.Write("\n");
        }

        public void ReverseList()
        {
            Node curNode = GetHead();
            while (curNode != null)
            {
                Node next = curNode.GetNext();
                curNode.SetNext(curNode.GetPrev());
                curNode.SetPrev(next);
                curNode = curNode.GetPrev();
            }

            Node tmp = Tail;
            Tail = Head;
            Head = tmp;
        }
        private Node Head = null;
        private Node Tail = null;
    }

    class TreeNode
    {
        public TreeNode()
        {
            value = 0;
            left = null;
            right = null;
            parent = null;
        }
        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
            parent = null;
        }
        public void SetLeft(TreeNode n)
        {
            left = n;
        }
        public void SetRight(TreeNode n)
        {
            right = n;
        }
        public void SetParent(TreeNode n)
        {
            parent = n;
        }

        public int GetValue()
        {
            return value;
        }

        public TreeNode GetLeft()
        {
            return left;
        }

        public TreeNode GetRight()
        {
            return right;
        }
        public TreeNode GetParent()
        {
            return parent;
        }

        private int value;
        private TreeNode left;
        private TreeNode right;
        private TreeNode parent;
    }
    class BinaryTree
    {
        public BinaryTree()
        {
            head = null;
        }
        public void Insert(int val)
        {
            TreeNode newNode = new TreeNode(val);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                TreeNode curNode = head;
                while (true)
                {
                    if (curNode.GetValue() < newNode.GetValue())
                    {
                        if (curNode.GetRight() != null)
                        {
                            curNode = curNode.GetRight();
                        }
                        else
                        {
                            curNode.SetRight(newNode);
                            newNode.SetParent(curNode);
                            break;
                        }
                    }
                    else
                    {
                        if (curNode.GetLeft() != null)
                        {
                            curNode = curNode.GetLeft();
                        }
                        else
                        {
                            curNode.SetLeft(newNode);
                            newNode.SetParent(curNode);
                            break;
                        }
                    }
                }
            }
        }

        public TreeNode Search(int val)
        {
            if (head == null)
            {
                return null;
            }

            TreeNode curNode = head;
            while (curNode != null)
            {
                if (curNode.GetValue() == val)
                {
                    return curNode;
                }
                if (curNode.GetValue() < val)
                {
                    curNode = curNode.GetRight();
                }
                else
                {
                    curNode = curNode.GetLeft();
                }
            }

            return null;
        }
        public void Remove(int val)
        {
            TreeNode nodeForRemove = Search(val);
            if (nodeForRemove == null)
            {
                return;
            }

            if (nodeForRemove.GetRight() != null)
            {
                TreeNode curNode = nodeForRemove.GetRight();
                while (curNode.GetLeft() != null)
                {
                    curNode = curNode.GetLeft();
                }
                curNode.SetLeft(nodeForRemove.GetLeft());
                if (nodeForRemove != head)
                {
                    if (nodeForRemove.GetParent().GetRight() == nodeForRemove)
                    {
                        nodeForRemove.GetParent().SetRight(nodeForRemove.GetRight());
                    }
                    else
                    {
                        nodeForRemove.GetParent().SetLeft(nodeForRemove.GetRight());
                    }
                }
                else
                {
                    head = nodeForRemove.GetRight();
                }
                nodeForRemove.GetRight().SetParent(nodeForRemove.GetParent());
                if (nodeForRemove.GetLeft() != null)
                {
                    nodeForRemove.GetLeft().SetParent(curNode);
                }
            }
            else if (nodeForRemove.GetLeft() != null)
            {
                TreeNode curNode = nodeForRemove.GetLeft();
                while (curNode.GetRight() != null)
                {
                    curNode = curNode.GetRight();
                }
                curNode.SetRight(nodeForRemove.GetRight());
                if (nodeForRemove != head)
                {
                    if (nodeForRemove.GetParent().GetRight() == nodeForRemove)
                    {
                        nodeForRemove.GetParent().SetRight(nodeForRemove.GetLeft());
                    }
                    else
                    {
                        nodeForRemove.GetParent().SetLeft(nodeForRemove.GetLeft());
                    }
                }
                else
                {
                    head = nodeForRemove.GetLeft();
                }
                nodeForRemove.GetLeft().SetParent(nodeForRemove.GetParent());
                if (nodeForRemove.GetRight() != null)
                {
                    nodeForRemove.GetRight().SetParent(curNode);
                }
            }
            else // node has no childs
            {
                if (head == nodeForRemove)
                {
                    head = null;
                }
                else if (nodeForRemove.GetParent().GetLeft() == nodeForRemove)
                {
                    nodeForRemove.GetParent().SetLeft(null);
                }
                else
                {
                    nodeForRemove.GetParent().SetRight(null);
                }
            }
        }

        private void PrintBFS(TreeNode n)
        {
            if (n == null)
            {
                return;
            }

            Console.Write("{0} ", n.GetValue());
            PrintBFS(n.GetLeft());
            PrintBFS(n.GetRight());
        }

        public void PrintTree()
        {
            PrintBFS(head);
            Console.Write("\n");
        }
        private TreeNode head;
    }


    class Program
    {

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i += 1)
            {
                int tmp = array[i];
                for (int j = i - 1; j >= 0 && tmp < array[j]; --j)
                {
                    array[j + 1] = array[j];
                    array[j] = tmp;
                }
            }
        }

        public static void PrintArray(int[] array)
        {
            Console.Write("Your array: ");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.Write("\n");
        }
        static void Main(string[] args)
        {
            // Пример работы класса myList
            MyList myList = new MyList();
            myList.Add(1);
            myList.PrintList();

            myList.Add(2);
            myList.PrintList();

            myList.Add(3);
            myList.PrintList();

            myList.Add(4);
            myList.PrintList();

            myList.ReverseList(); // перевернули список
            myList.PrintList();

            myList.RemoveNode(myList.GetHead().GetNext().GetNext()); // удаляем один из узлов внутри списка
            myList.PrintList();

            myList.RemoveNode(myList.GetTail()); // удаляем последний узел
            myList.PrintList();

            myList.RemoveNode(myList.GetHead()); // удаляем первый узел
            myList.PrintList();

            myList.RemoveNode(myList.GetHead()); // удаляем единственный оставшийся узел.
            myList.PrintList();

            // Пример работы сортировки
            int[] myArray = { }; // empty array
            InsertionSort(myArray);
            PrintArray(myArray);

            int[] oneElem = { 1 }; // one elem
            InsertionSort(oneElem);
            PrintArray(oneElem);

            int[] fewElems = { 5, 2, 7, 3, 8, 9, 1, 4, 6 }; // few elems
            InsertionSort(fewElems);
            PrintArray(fewElems);

            int[] alreadySorted = { 1, 2, 3, 4, 5, 6, 7 };
            InsertionSort(alreadySorted);
            PrintArray(alreadySorted);

            // Пример работы двоичного дерева

            BinaryTree bt = new BinaryTree();
            bt.Insert(10);
            bt.Insert(5);
            bt.Insert(15);
            bt.Insert(1);
            bt.Insert(6);
            bt.Insert(11);
            bt.Insert(20);
            bt.PrintTree();
            bt.Remove(10);
            bt.PrintTree();
            bt.Remove(20);
            bt.PrintTree();
            bt.Remove(5);
            bt.PrintTree();
            bt.Remove(15);
            bt.PrintTree();
        }
    }
}
