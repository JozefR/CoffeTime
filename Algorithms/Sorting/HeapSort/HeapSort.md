### Heap Sort

#### Previous: [Sorting &laquo;](../Sorting.md)

``` cs --region heapSortMain --source-file .\Program.cs --project .\HeapSort.csproj 
private static int[] HeapSort(int[] array)
{
    // First create heap from input array
    Heaping(array);

    // Start from the last index
    var lastIndex = array.Length - 1;

    // Take maximum which is always at index 0 after
    // heaping and swap it with last value. This last value
    // become lower each cycle until is equal 0 and
    // array is sorted !
    while (lastIndex > 0)
    {
        // At index 0 is always maximum !
        Swap(array,0, lastIndex);
        // Last value becomes lower each time !
        lastIndex -= 1;
        // When we swap last value with maximum we
        // need repair structure because last value
        // can interrupt heap !
        // It is basically as Upper method but we are
        // going from up to down.
        Down(array, lastIndex);
    }

    return array;
}
```

``` cs --region heaping --source-file .\Program.cs --project .\HeapSort.csproj 
private static void Heaping(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Upper(array, i);
    }
}
```

``` cs --region upper --source-file .\Program.cs --project .\HeapSort.csproj 
// The idea is check for each number if father is greater,
// if not move that number up and continue until father has lower value.
private static void Upper(int[] array, int i)
{
    int childIndex = i;
    while (childIndex > 0)
    {
        // father for particular child index
        int fatherIndex = (childIndex - 1) / 2;

        int child = array[childIndex];
        int father = array[fatherIndex];

        if (father < child)
        {
            // Father is lower then child, swap it.
            Swap(array, fatherIndex, childIndex);
            // After swapping, childIndex become fatherIndex.
            childIndex = fatherIndex;
        }
        else
        {
            // nothing happend father and child are in correct places.
            return;
        }
    }
}
```

``` cs --region down --source-file .\Program.cs --project .\HeapSort.csproj 
// Check if one from both childs are lower
private static void Down(int[] array, int lastIndex)
{
    // After swap last index become father and this can interrupt heap
    // we need repair it.
    int fatherIndex = 0;

    while (fatherIndex * 2 + 1 < lastIndex)
    {
        // find childs
        int childIndex = 2 * fatherIndex + 1;

        // Find which child is greater
        if (childIndex < lastIndex && array[childIndex] < array[childIndex + 1])
        {
            childIndex += 1;
        }

        // swap if father has lower value.
        if (array[fatherIndex] < array[childIndex])
        {
            Swap(array, fatherIndex, childIndex);
            fatherIndex = childIndex;
        }

        else
        {
            return;
        }
    }
}
```

#### Previous: [Sorting &laquo;](../Sorting.md)
