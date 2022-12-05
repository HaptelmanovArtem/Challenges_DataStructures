namespace SingleLinkedList;

public class LinkedList
{
    public Node? Head { get; private set; }

    public LinkedList()
    {
    }

    public LinkedList(Node head)
    {
        Head = head;
    }
    
    public void InsertAtHead(Node node)
    {
        if (Head is null)
        {
            Head = node;
            return;
        }

        node.NextNode = Head;
        Head = node;
    }

    public void Traverse(Action<Node?, string> output)
    {
        if (IsEmpty())
        {
            output(Head, "Linked list is empty");
            return;
        }
        
        var temp = Head;
        while (temp is not null)
        {
            output(temp, "->");
            temp = temp.NextNode;
        }
    }
    
    public IEnumerable<Node> Traverse()
    {
        if (IsEmpty())
        {
            yield break;
        }
        
        var temp = Head;
        while (temp is not null)
        {
            yield return temp;
            temp = temp.NextNode;
        }
    }
    
    public bool IsEmpty()
    {
        return Head is null;
    }

    public void InsertAtTail(Node node)
    {
        var tail = Traverse().FirstOrDefault(i => i.NextNode is null);

        if (tail is null)
        {
            InsertAtHead(node);
            return;
        }
        
        tail.NextNode = node;
    }
    
    public void InsertAtTail(int value)
    {
        InsertAtTail(new Node
        {
            Value = value
        });
    }

    public bool Search(int value)
    {
        return !IsEmpty() && Traverse().Any(node => node.Value == value);
    }

    public bool DeleteAtHead()
    {
        if (IsEmpty())
            return false;

        Head = Head.NextNode;
        return true;
    }

    public bool DeleteByValue(int value)
    {
        if (Head?.Value == value)
            return DeleteAtHead();
        
        var temp = Head?.NextNode;
        var previousNode = Head;
        while (temp is not null)
        {
            if (temp.Value == value)
            {
                previousNode.NextNode = temp.NextNode;
                return true;
            }
            
            previousNode = temp;
            temp = temp.NextNode;
        }

        return false;
    }

    public void Reverse()
    {
        var previous = default(Node);
        var current = Head;

        while (current != null)
        {
            var next = current.NextNode;
            current.NextNode = previous;
            previous = current;
            current = next;
        }

        Head = previous;
    }
}