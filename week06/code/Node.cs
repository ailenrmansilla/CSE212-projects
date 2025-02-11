public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == Data){
            return; // we do nothing if that value is already in the tree
        }
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data){
            // if current value matches, return true
            return true;
        }
        if (value < Data){
            if (Left is null){
                return false;
            } else {
               return Left.Contains(value);
            }
        }
        if (value > Data){
            if (Right is null){
                return false;
            } else {
                return Right.Contains(value);
            }
        }
        return false;
    }

    public int GetHeight(Node? node)
    {
        // TODO Start Problem 4
        if (node == null){
            return 0;
        }
        int leftHeight = GetHeight(node.Left); // recursive call
        int rightHeight = GetHeight(node.Right);
        return 1 + Math.Max(leftHeight, rightHeight); // returns 1 plus the highest value from right or left
    }
}