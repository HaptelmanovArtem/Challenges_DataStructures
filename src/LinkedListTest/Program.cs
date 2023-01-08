// See https://aka.ms/new-console-template for more information

using SingleLinkedList;

/*var linkedList = new LinkedList();
linkedList.InsertAtTail(new Node
{
    Value = 10
});

linkedList.InsertAtTail(new Node
{
    Value = 20
});

linkedList.Traverse((node, text) =>
{
    Console.Write($"{node?.Value}{text}");
});

Console.WriteLine();

Console.WriteLine(linkedList.Search(20));

return 1;*/


var doubleLinkedList = new DoubleLinkedList();

doubleLinkedList.InsertAtTail(1);
doubleLinkedList.InsertAtTail(2);
doubleLinkedList.InsertAtTail(3);
doubleLinkedList.InsertAtTail(4);
doubleLinkedList.InsertAtTail(5);

var temp = doubleLinkedList.Tail;
while (temp != null)
{
    Console.Write(temp.Value + "->");
    temp = temp.PreviousNode;
}

return 1;