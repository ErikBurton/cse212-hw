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
        if (value == Data)
            return; // Duplicate found; do not insert.

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
        if (value == Data)
            return true;
        
        if (value < Data)
            return Left != null && Left.Contains(value); // Search left subtree

        return Right != null && Right.Contains(value); // Search right subtree
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = Left?.GetHeight() ?? 0; // Recursively get height of the left subtree, or 0 if no left child.
        int rightHeight = Right?.GetHeight() ?? 0; // Recursively get height of the right subtree, or 0 if no right child.
        return 1 + Math.Max(leftHeight, rightHeight); // The height of this node is 1 (for this node) plus the taller of the two subtress.
    }
}