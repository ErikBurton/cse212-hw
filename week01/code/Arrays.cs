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
        // Plan:
        // 1. Create a result array of size 'length'.
        // 2. For each index i from 0 to lenght -1:
        //    a. Compute the (i + 1)th multiple: number + (i +1).
        //    b. Store it in result [i].
        // 3. Return the result array.

        // Allocate new array to hold the results.
        // Its size is 'length', so it can store exactly 'length' multiples.
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            // Computes the (i + 1) multiple of 'number' by multiplying:
            //    number * (i + 1)
            // if i = 0 then number * 1
            // if i = 1 then number * 2
            // and so on, up to i = length - 1 then number * length.
            result[i] = number * (i + 1);
        }

        // Once all multiples are computed and storesd, return the filled array.
        return result; // replace this return statement with your own
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
        // Plan:
        // 1. Determine the actual rotation by taking amount modulo data.Count (to handle full rotations.)
        // 2. If the effective rotation is 0, do nothing and return.
        // 3. Otherwise:
        //    a. Extract the last 'rotate' elements using GetRange(startIndex, rotate).
        //    b. Remove those elements from the end of the list usning RemoveRange.
        //    c. Insert the extracted elements at the begining of the list using InsertRange.

        int count = data.Count;
        int rotate = amount % count;
        if (rotate == 0)
        {
            return;
        }

        // Extract the tail segment.
        List<int> tail = data.GetRange(count - rotate, rotate);
        // Remove the tail from the original list.
        data.RemoveRange(count - rotate, rotate);
        // Insert the tail at the front
        data.InsertRange(0, tail);
    }
}
