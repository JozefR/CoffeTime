#### Previous: [Home &laquo;](../../README.md)

# Intro to Searching Algorithms

- [Binary Search Tree](./BST/BST.md)


### Binary search

``` cs --region binarySearch --source-file .\Binary\Program.cs --project .\Binary\Binary.csproj 
private static int BinarySearch(int[] array, int target)
{
    int left = 0;
    int right = array.Length - 1;

    while (right > left)
    {
        var guess = (left + right) / 2;

        if (array[guess] == target)
        {
            return guess;
        }

        if (array[guess] < target)
        {
            left = guess + 1;
        }
        else
        {
            right = guess - 1;
        }
    }

    return -1;
}```

### Binary search with recursion

``` cs --region binarySearchRecursion --source-file .\Binary\Program.cs --project .\Binary\Binary.csproj 
private static int BinarySearchRecursion(int[] array, int target, int leftIndex, int rightIndex)
{
    if (leftIndex > rightIndex)
        return -1;

    int middle = (leftIndex + rightIndex) / 2;

    if (array[middle] == target)
        return target;

    if (target > array[middle])
        return BinarySearchRecursion(array, target, middle + 1, rightIndex);

    if (target < array[middle])
        return BinarySearchRecursion(array, target, leftIndex, middle - 1);

    return middle;
}
```

#### Previous: [Home &laquo;](../../README.md)