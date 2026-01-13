public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Creating array of size length
        double[] result = new double[length];

        // Step 2: Filling the array with multiples of number
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); 
        }

        // Step 3: Returning the filled array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Normalizing amount in case it's larger than the list length
        amount %= data.Count;

        if (amount == 0) return; // nothing to rotate

        // Step 2: Taking the last amount elements
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Step 3: Removing the last amount elements from the original list
        data.RemoveRange(data.Count - amount, amount);

        // Step 4: Insert the tail at the start of the list
        data.InsertRange(0, tail);
    }
}
