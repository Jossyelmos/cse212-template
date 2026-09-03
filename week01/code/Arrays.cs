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

        // Create an array with the requested length
        var multiples = new double[length];

        // Loop through each position in the array
        for (var i = 0; i < length; i++) {

            // Calculate the multiple by multiplying the number by the position plus one.
            multiples[i] = number * (i + 1);
        }

        // Return the completed array
        return multiples;
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

        // Determine where the last 'amount' elements begins
        var startIndex = data.Count - amount;

        // Copy the last 'amount' elements in a temporary list
        var itemsToRemove = data.GetRange(startIndex, amount);

        // Remove the last 'amount' elements completely from the original list
        data.RemoveRange(startIndex, amount);

        // Insert the saved 'amount' elements at the beginning of the original list.
        data.InsertRange(0, itemsToRemove);
    }
}
