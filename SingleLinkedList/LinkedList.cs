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

    public int Length()
    {
        return Traverse().Count();
    }

    public bool DetectLoop()
    {
        Node slow = Head, fast = Head;

        while (slow != null && fast != null && fast.NextNode != null)
        {
            slow = slow.NextNode;
            fast = fast.NextNode.NextNode;

            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }

    public Node? FindMid()
    {
        if (IsEmpty())
            return null;

        var length = Length();
        var currentCount = 1;
        var stopCount = length % 2 == 0 ? length / 2 : (length / 2) + 1;
        var currentNode = Head;

        while (currentNode is not null)
        {
            if (currentCount == stopCount)
                return currentNode;

            currentNode = currentNode.NextNode;
            currentCount++;
        }

        return null;
    }

    public Node? FindMidV2()
    {
        var oneStepNode = Head;
        var twoStepNode = Head;

        while (oneStepNode is not null && twoStepNode is not null && twoStepNode.NextNode is not null)
        {
            oneStepNode = oneStepNode.NextNode;
            twoStepNode = twoStepNode.NextNode.NextNode;
        }

        return oneStepNode;
    }

    public void RemoveDuplicates()
    {
        Node? currentNode = null;
        Node? currentHead = null;

        foreach (var node in Traverse())
        {
            if (currentNode is null)
            {
                currentHead = new Node
                {
                    Value = node.Value,
                };
                currentNode = currentHead;
                
                continue;
            }

            var tempNode = node.NextNode;
            var isDuplicateDetected = false;
            while (tempNode is not null)
            {
                if (tempNode.Value == node.Value)
                {
                    isDuplicateDetected = true;
                    break;
                }
                
                tempNode = tempNode.NextNode;
            }

            if (!isDuplicateDetected)
            {
                currentNode.NextNode = node;
                currentNode = node;
            }
        }

        Head = currentHead;
    }

    public void Union(LinkedList list)
    {
        if (IsEmpty())
        {
            Head = list.Head;
            return;
        }
        
        var tail = Head;

        while (tail.NextNode is not null)
        {
            tail = tail.NextNode;
        }

        tail.NextNode = list.Head;
    }
    
    public void Intersect(LinkedList list)
    {
        if (IsEmpty())
        {
            Head = list.Head;
            return;
        }
        
        var currentNode = Head;
        
        var intersectedHead = default(Node?);
        var intersectedCurrent = default(Node?);

        while (currentNode is not null)
        {
            var tempCurrentNode = list.Head;
            while (tempCurrentNode is not null)
            {
                if (tempCurrentNode.Value == currentNode.Value)
                {
                    if (intersectedHead is null)
                    {
                        intersectedHead = new Node { Value = tempCurrentNode.Value };
                        intersectedCurrent = intersectedHead;
                        break;
                    }

                    intersectedCurrent.NextNode = new Node { Value = tempCurrentNode.Value };
                    intersectedCurrent = intersectedCurrent.NextNode;
                }
                
                tempCurrentNode = tempCurrentNode.NextNode;
            }
                
            currentNode = currentNode.NextNode;
        }

        Head = intersectedHead;
    }

    public int FindLastIndexOf(int value)
    {
        var currentCount = 1;
        var valueIndex = int.MinValue;
        
        var temp = Head;
        while (temp is not null)
        {
            if (temp.Value == value)
            {
                valueIndex = currentCount;
            }
            
            temp = temp.NextNode;
            currentCount++;
        }

        if (valueIndex == Int32.MinValue)
            return -1;
        
        return currentCount - valueIndex;
    }
    
    public int FindByIndexFromHead(int index)
    {
        if (IsEmpty())
            return -1;
        
        var currentCount = 1;
        
        var temp = Head;
        while (currentCount < index)
        {
            if (temp is null)
                return -1;
            
            temp = temp.NextNode;
            currentCount++;
        }

        if (temp is null)
            return -1;
        
        return temp.Value;
    }
    
    public int FindByIndexFromTail(int index)
    {
        if (IsEmpty())
            return -1;

        var length = Length();
        var currentCount = 1;
        
        var temp = Head;
        while (currentCount < (length - index + 1))
        {
            if (temp is null)
                return -1;
            
            temp = temp.NextNode;
            currentCount++;
        }

        if (temp is null)
            return -1;
        
        return temp.Value;
    }
}