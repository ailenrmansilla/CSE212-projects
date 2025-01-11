public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // We need an array called multiples with length = int length
        // We could use a list, but a fixed length array represents a better memory use
        // this is an array of elements with type <double> because this is the type of the number we receive 
        double[] multiples = new double[length];
        // Then we need to run a loop to multiply "number" "length" times
        for (int i=0; i< length; i++){
            // we run through each position in the fixed array multiples[] using i
            // we multiply number by i+1 because i starts at 0, when we really need to start multiplying number by 1
            multiples[i] = number * (i+1);
        }
        return multiples; 
        // we return the complete array
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    
        //  We need an empty List<int> element for the rotated list
        List<int> rotated = new List<int>();
        // We split the data list in two using amount and we store them in two temporal lists
        List<int> firstElements = data.GetRange(0, amount);
        List<int> lastElements = data.GetRange(amount, data.Count - amount);
        // We put them together in the new list rotated
        rotated.AddRange(lastElements); 
        // Add lastElements first
        rotated.AddRange(firstElements); 
        // Add firstElements last
        
    
    
    }
}
