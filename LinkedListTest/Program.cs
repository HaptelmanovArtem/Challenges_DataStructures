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


var linkedList = new LinkedList();
linkedList.InsertAtTail(1);
linkedList.InsertAtTail(2);
linkedList.InsertAtTail(3);
linkedList.InsertAtTail(4);
linkedList.InsertAtTail(5);

foreach (var item in linkedList.Traverse())
{
    Console.WriteLine(item.Value);
}


linkedList.Reverse();