// See https://aka.ms/new-console-template for more information

var queue = new Queue.Queue();

queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);
queue.Enqueue(5);

queue.Reverse(3);

return 1;