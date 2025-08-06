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
        if (value < this.Data)
        {
            if (this.Left == null)
            {
                // Insert to the left
                this.Left = new Node(value);
            }

            else
            {
                this.Left.Insert(value);
            }
        }
        else if (value > this.Data)
        {
            if (this.Right == null)
            {
                // Insert to the Right
                this.Right = new Node(value);
            }
            else
            {
                this.Right.Insert(value);
            }
        } 
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == this.Data)
        {
            return true;
        }

        else if (value < this.Data && this.Left != null)
        {
            return this.Left.Contains(value);
        }
        else if (value > this.Data && this.Right != null)
        {
            return this.Right.Contains(value);
        }
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        return 0; // Replace this line with the correct return statement(s)
    }
}