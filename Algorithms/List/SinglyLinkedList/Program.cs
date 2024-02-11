var singlyList = new SinglyLinkedList(new Node(1));
singlyList.Add(2);
singlyList.Add(3);
singlyList.Add(4);

Console.ReadKey();


class SinglyLinkedList {
    public Node Head { get; set; }
    public int Count { get; set; }
    
    public SinglyLinkedList(Node head)
    {
        Head = head;
        Count++;
    }

    public void Add(int value)
    {
        var next = Head;
        while (next.Next != null)
        {
            next = next.Next;
        }
        
        next.Next = new Node(value);
        Count++;
    }
}

public class Node
{
    public int Value { get; private set; }
    public Node? Next { get; set; }

    public Node(int value)
    {
        Value = value;
    }
}
