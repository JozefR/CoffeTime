#### Previous: [Home &laquo;](../../README.md)

# Intro to Sorting Algorithms

- [Quick Sort](./QuickSort/QuickSort.md)

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
private static int[] InsertionSort(int[] array)
{
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
}
```
### Insertion Sort Refactored

``` cs --region insertionSortRefactored --source-file .\InsertionSort\Program.cs --project .\InsertionSort\InsertionSort.csproj 
private static int[] InsertionSortRefactored(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        var key = array[i];
        var leftIndex = i - 1;
        Insert(array, leftIndex, key);
    }

    return array;
}

private static void Insert(int[] array, int leftIndex, int key)
{
    while (leftIndex > 0 && array[leftIndex] > key)
    {
        array[leftIndex + 1] = array[leftIndex];
        leftIndex = leftIndex - 1;
    }

    array[leftIndex + 1] = key;
}
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

#### Previous: [Home &laquo;](../../README.md)
