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
        // Plan (step-by-step):
        // 1. Create a new array of doubles of size 'length'.
        // 2. For each index i from 0 to length-1:
        //    - compute the i-th multiple as number * (i + 1) (because the multiples start at number, not 0).
        //    - store that value into array at index i.
        // 3. Return the filled array.
        //
        // Example: number = 3, length = 5
        // - result[0] = 3 * (0+1) = 3
        // - result[1] = 3 * (1+1) = 6
        // -> returns {3, 6, 9, 12, 15}

        if (length <= 0)
        {
            // defensively return an empty array if length is not positive (assignment says length > 0, but this is safe)
            return new double[0];
        }

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result; // replace this return statement with your own
        // TODO Problem 1 End
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
            // Plan (step-by-step):
         // Plan (step-by-step):
        // 1. Validate inputs: if data is null or data.Count == 0 or amount % data.Count == 0, nothing to do.
        // 2. Normalize amount: since amount will be 1..data.Count per assignment, this step is mostly defensive.
        //    But we can do amount = amount % data.Count to be safe.
        // 3. Use list slicing (GetRange) to get the tail (the last 'amount' elements) and the head (the first data.Count - amount elements).
        // 4. Clear the original list.
        // 5. AddRange(tail) followed by AddRange(head) so the last 'amount' elements become the front.
        //
        // Example: data = {1,2,3,4,5,6,7,8,9}, amount = 3
        // - tail = GetRange(9 - 3, 3) -> {7,8,9}
        // - head = GetRange(0, 6) -> {1,2,3,4,5,6}
        // - result = tail + head -> {7,8,9,1,2,3,4,5,6}

        if (data == null || data.Count == 0)
        {
            return;
        }

        int n = data.Count;
        // Normalize amount in case caller provides an equivalent rotation (defensive)
        amount = amount % n;
        if (amount == 0)
        {
            // no rotation needed
            return;
        }

        // Get last 'amount' elements
        List<int> tail = data.GetRange(n - amount, amount);
        // Get the initial part
        List<int> head = data.GetRange(0, n - amount);

        // Clear original list and rebuild
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);

        // TODO Problem 2 End
    }
}