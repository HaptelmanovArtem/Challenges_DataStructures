namespace SingleLinkedList;

public class DoubleLinkedList
{
    public DoubleLinkedListNode? Head { get; private set; }
    public DoubleLinkedListNode? Tail { get; private set; }

    public DoubleLinkedList()
    {
    }

    public DoubleLinkedList(DoubleLinkedListNode head)
    {
        Head = head;
        Tail = head;
    }

    public void InsertAtHead(int value)
    {
        var newNode = new DoubleLinkedListNode
        {
            Value = value,
        };

        if (IsEmpty())
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        Head.PreviousNode = newNode;
        newNode.NextNode = Head;
        Head = newNode;
    }

    public bool IsEmpty()
    {
        return Head == null;
    }

    public void InsertAtTail(int value)
    {
        var tailNode = new DoubleLinkedListNode
        {
            Value = value
        };

        if (IsEmpty())
        {
            Head = tailNode;
            Tail = tailNode;
            return;
        }

        tailNode.PreviousNode = Tail;
        Tail.NextNode = tailNode;
        Tail = tailNode;
    }

    public void DeleteHead()
    {
        if (IsEmpty())
            return;

        Head = Head.NextNode;

        if (Head is null)
            return;
        
        Head.PreviousNode = null;
    }

    public DoubleLinkedListNode GetHead()
    {
        if (IsEmpty())
            return null;

        return Head;
    }
}