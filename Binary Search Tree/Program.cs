
BinarySearchTree tree = new BinarySearchTree();

tree.Insert(50);
tree.Insert(30);
tree.Insert(20);
tree.Insert(40);
tree.Insert(70);
tree.Insert(60);
tree.Insert(80);

Console.WriteLine("Inorder traversal:");
tree.InOrderTraversal();
Console.WriteLine();

int searchKey = 40;
Console.WriteLine($"Search for key {searchKey}: {tree.Search(searchKey)}");



public class Node
{
    public int Key;
    public Node Left, Right;

    public Node(int item)
    {
        Key = item;
        Left = Right = null;
    }
}

public class BinarySearchTree
{
    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(int key)
    {
        root = InsertRec(root, key);
    }

    private Node InsertRec(Node root, int key)
    {
        if (root == null)
        {
            root = new Node(key);
            return root;
        }

        if (key < root.Key)
        {
            root.Left = InsertRec(root.Left, key);
        }
        else if (key > root.Key)
        {
            root.Right = InsertRec(root.Right, key);
        }

        return root;
    }

    public bool Search(int key)
    {
        return SearchRec(root, key);
    }

    private bool SearchRec(Node root, int key)
    {
        if (root == null || root.Key == key)
        {
            return root != null;
        }

        if (key < root.Key)
        {
            return SearchRec(root.Left, key);
        }

        return SearchRec(root.Right, key);
    }

    public void InOrderTraversal()
    {
        InOrderTraversal(root);
    }

    private void InOrderTraversal(Node root)
    {
        if (root != null)
        {
            InOrderTraversal(root.Left);
            Console.Write(root.Key + " ");
            InOrderTraversal(root.Right);
        }
    }
}





