// See https://aka.ms/new-console-template for more information

using Queue;

var queue = new QueueWithStack();

queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);
queue.Enqueue(5);


Console.WriteLine(queue.Dequeue());

return 1;