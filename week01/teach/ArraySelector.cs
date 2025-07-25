public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] result = new int[select.Length];
        int i1 = 0, i2 = 0;

        for (int i = 0; i < select.Length; i++)
        {
            switch (select[i])
            {
                case 1:
                    result[i] = list1[i1++];
                    break;
                case 2:
                    result[i] = list2[i2++];
                    break;
                default:
                    throw new ArgumentException("Selector array may only contain 1s and 2s");
            }
        }

        return result;
    }
}