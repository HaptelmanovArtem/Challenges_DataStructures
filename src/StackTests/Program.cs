// See https://aka.ms/new-console-template for more information

using Stack;

var twoStack = new TwoStacks(5);

twoStack.Push1(6);
twoStack.Push1(3);
twoStack.Push1(2);

twoStack.Push2(4);
twoStack.Push2(5);

twoStack.Pop1();
twoStack.Pop1();
twoStack.Pop1();
twoStack.Pop1();

return 1;