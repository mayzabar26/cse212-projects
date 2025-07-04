public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// 

    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //My implementation plan
        //Step 1: Create an Array with the same size of numberOfMultiples    
        //Step 2: Create a for loop to repeat numberOfMultiples 
        //Step 3: For each repeatition, calculate the current multiple (startNumber * (position + 1))
        //Step 4: Store this value in the array at the corresponding position
        //Step 5: After the loop, return the filled array

        //Step 1
        double[] multiples = new double[length];

        //Step 2
        for (int i = 0; i < length; i++)
        {
            //Step 3
            double currentMultiple = number * (i + 1);

            //Step 4
            multiples[i] = currentMultiple;
        }

        //Step 5
        return multiples; // replace this return statement with your own
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

        //My implementation plan
        //Step 1: Get the last "amount" elements from the list using GetRange   
        //Step 2: Remove these elements from the original list using RemoveRange 
        //Step 3: Insert elements at the beginning of the list using InsertRange
        //Step 4: The list will be rotated to the right by the "amount"

        //Step 1
        List<int> LastElements = data.GetRange(data.Count - amount, amount);

        //Step 2
        data.RemoveRange(data.Count - amount, amount);

        //Step 3
        data.InsertRange(0, LastElements);
    }
}
