#### Previous: [Home &laquo;](../Medium.md)

# Number Zoo Patrol

Task:
Write a function that takes a shuffled list of unique numbers from 1 to n with one element missing (which can be any number including n). Return this missing number.

Note: huge lists will be tested.

Examples:

    [1, 3, 4]  =>  2
    [1, 2, 3]  =>  4
    [4, 2, 3]  =>  1


## Solutions

``` cs  
public static int FindNumber(int[] shuffledArray)
{
    var missingNumber = 1;
    var orderedArray = shuffledArray.OrderBy(x => x).ToArray();
    for (int i = 0; i < orderedArray.Count(); i++)
    {
        if (missingNumber != orderedArray[i]) break;
        
        missingNumber++;
    }
    
    return missingNumber;
}

// We use a HashSet here because since a HashSet is composed of unique items and our inputs only has unique items
// This allows use to use `HashSet.Contains`, which is a constant O(1) operation, opposed to `Array.IndexOf`, which is a linear O(n) operation.
// Alternatively, we could have sorted our input array using `Array.Sort` or `IEnumerable.OrderBy` and iterated over that, but that's a O(n + n log(n)) solution. That's OK, but we can do better!
// With HashSet.Contains, our solution is done in O(n) time (~1 * n), as opposed to O(n ^ 2) for Array.IndexOf (n * n).

// Relevant links:

// Big O notation cheat sheet:
// http://bigocheatsheet.com/

// HashSet.Contains:
// https://msdn.microsoft.com/en-us/library/bb356440(v=vs.110).aspx

// Array.IndexOf:
// https://msdn.microsoft.com/en-us/library/7eddebat(v=vs.110).aspx

// O(n) -- Best

HashSet<int> animals = new HashSet<int>(array);

// Iterate over 1 to n + 1, and return the missing number
foreach (int i in Enumerable.Range(1, array.Length + 1))
{
    if (!animals.Contains(i)) { return i; }
}

return -1;


// O(n + n log(n)) -- Worse
/*
//Array.Sort(array) // mutates your input, don't do this!
int[] newArray = array.OrderBy(x => x).ToArray();

for (int i = 0; i < newArray.Length; ++i)
{
  if (newArray[i] != i + 1) { return i + 1; }
}

return newArray.Length + 1;
*/

// O(n ^ 2) -- Step it up, JavaScript!
/*
for (int i = 1; i <= array.Length + 1; ++i)
{
  if (Array.IndexOf(array, i) < 0) { return i; }
}

return -1;
*/
```

#### Previous: [Home &laquo;](../Medium.md)
