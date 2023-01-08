// See https://aka.ms/new-console-template for more information

using Stack;

var stack = new Stack<int>();

stack.Push(2);
stack.Push(97);
stack.Push(4);
stack.Push(42);
stack.Push(12);
stack.Push(60);
stack.Push(23);

StackExtensions.EvaluatePostFix("921*-8-4+");

while (stack.TryPop(out var i))
{
    Console.WriteLine(i);
}

return 1;