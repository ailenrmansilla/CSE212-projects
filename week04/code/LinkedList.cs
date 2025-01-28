using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        // Create new node
        Node newNode = new(value);
        // if the list is empty, we point tail and head to the new node (only node)
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        } else {
            newNode.Prev = _tail; // Connect new node to the tail
            _tail.Next = newNode; // Connect the previous tail to the new next node
            _tail = newNode; // Update the tail node to point to the new node
        }

    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        
        // if there is only one element, set head and tail to null
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null && _tail.Prev != null) {
            // if tail is not null and there is more than one element, we set the second to the last node's next to null (because we'll erase that element)
            _tail.Prev.Next = null;
            // now the new tail is that second to the last element
            _tail = _tail.Prev;
        }


    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3

        // Start at the beginning (the head)
        var current = _head;
        // Loop until we have reached the value that matches node's data
        while (current != null){
            if (current.Data == value){
                if (current == _head){ // if removing the head
                    _head = current.Next; // new head, the second element
                    if (_head != null){ // if it exists, its previous element is null because it was erased
                        _head.Prev = null;
                    }
                    else{
                        _tail = null; // if the list becomes empty because there wasnt a second element
                    }
                }
                else if (current == _tail){ // if removing the tail
                    _tail = current.Prev;   // new tail, the second to the last element, assuming there is one (can be null)
                    _tail!.Next = null;     // we get sure the previous tail is null (removed)
                }
                // If removing a middle node
                else
                {
                    current.Next!.Prev = current.Prev;
                    current.Prev!.Next = current.Next;
                }
                // Remove references to fully detach the node, make it null
                current.Next = null;
                current.Prev = null;
               
                break; // we stop searching when we find the value
            }
            current = current.Next; // If value not found, point to the next node
            
        }

    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4

        // Start at the beginning (the head)
        var current = _head;
        // Loop through the list and replace all occurrences of oldValue with newValue
        while (current != null)
        {
            if (current.Data == oldValue){
                current.Data = newValue;
            }
            current = current.Next; // always move to the next node
        }


    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provides (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        var curr = _tail; // starts at the tail and iterates backwards
        
        while (curr is not null){
            yield return curr.Data; // yield current node data
            curr = curr.Prev;   // move backwards
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}