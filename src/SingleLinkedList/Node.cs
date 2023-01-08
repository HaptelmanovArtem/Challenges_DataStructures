namespace SingleLinkedList;

public sealed class Node
{
    public int Value { get; set; }
    public Node? NextNode { get; set; }
}

public sealed class DoubleLinkedListNode
{
    public int Value { get; set; }
    public DoubleLinkedListNode NextNode { get; set; }
    public DoubleLinkedListNode? PreviousNode { get; set; }
}