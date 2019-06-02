#### Previous: [Home &laquo;](../../README.md)

# Intro to Sorting Algorithms

### Selection Sort

``` cs --region selectionSort --source-file .\SelectionSort\Program.cs --project .\SelectionSort\SelectionSort.csproj 
private static int[] selectionSort(int[] array)
{
    for (int i = 0; i < array.Length; i++) // (n - 1)
    {
        int minimum = array[i];
        int minimumIndex = i;

        for (int j = minimumIndex + 1; j < array.Length; j++) // (n - i)
        {
            if (minimum > array[j])
            {
                minimum = array[j];
                minimumIndex = j;
            }
        }
        Swap(array, i, minimumIndex); // O(1)
    }
    return array;
}
```

### Insertion Sort

``` cs --region insertionSort --source-file .\InsertionSort\Program.cs --project .\InsertionSort\InsertionSort.csproj 
for (int i = 0; i < array.Length; i++)
{
    var key = array[i];
    var leftIndex = i - 1;

    while (leftIndex > 0 && array[leftIndex] > key)
    {
        array[leftIndex + 1] = array[leftIndex];
        leftIndex -= 1;
    }

    array[leftIndex + 1] = key;
}

return array;
```

### Bubble Sort Simple

``` cs --region bubbleSortSimple --source-file .\BubbleSort\Program.cs --project .\BubbleSort\BubbleSort.csproj 
    private static int[] BubbleSortSimple(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                var a = array[j];
                var b = array[j + 1];

                if (a > b)
                {
                    array[j] = b;
                    array[j + 1] = a;
                }
            }
        }

        return array;
    }
```
### Bubble Sort

``` cs --region bubbleSort --source-file .\BubbleSort\Program.cs --project .\BubbleSort\BubbleSort.csproj 
    private static int[] BubbleSort(int[] array)
    {
        bool continueOrdering;
        var sortedIndex = array.Length - 1;

        do
        {
            continueOrdering = false;

            for (int i = 0; i < sortedIndex; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(array, i, i + 1);
                    continueOrdering = true;
                }
            }

            sortedIndex = sortedIndex - 1;
        } while (continueOrdering);

        return array;
    }
```

### Quick Sort

``` cs --region quickSortMain --source-file .\QuickSort\Program.cs --project .\QuickSort\QuickSort.csproj 
private static void quickSort(int[] array, int left, int right)
{
    if (left < right)
    {
        var pivot = partition(array, left, right);
        quickSort(array, left, pivot - 1);
        quickSort(array, pivot + 1, right);
    }
}

private static int partition(int[] array, int left, int right)
{
    int pivot = array[right];

    int smaller = left - 1;
    int smallerRight = left;

    while (smallerRight < right)
    {
        if (array[smallerRight] <= pivot)
        {
            smaller++;

            swap(array, smaller, smallerRight);
        }

        smallerRight++;
    }

    swap(array, smaller + 1, right);

    return smaller + 1;
}

private static void swap(int[] array, int smaller, int smallerRight)
{
    int temp = array[smaller];
    array[smaller] = array[smallerRight];
    array[smallerRight] = temp;
}
```

#### Previous: [Home &laquo;](../../README.md)
