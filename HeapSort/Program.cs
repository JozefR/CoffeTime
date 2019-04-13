using System.Net;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 2, 10, 6, 7};
            int[] array2 = {1, 3, 4, 5, 6, 7, 2};
            int[] heapArray = new int[array.Length];
            var test = HeapSort(array);
        }

        private static int[] HeapSort(int[] array)
        {
            Heaping(array);

            var index = array.Length - 1;

            while (index > 0)
            {
                Swap(array,0, index);
                index = index - 1;
                Down(array, index);
            }

            return array;
        }

        private static void Down(int[] array, int end)
        {
            int father = 0;
            while (father * 2 + 1 <= end)
            {
                int son = father * 2 + 1;
                if (son < father && array[son] < array[son + 1])
                {
                    son = son + 1;
                }

                if (array[father] < array[son])
                {
                    Swap(array, father, son);
                    father = son;
                }
                else
                {
                    return;
                }
            }
        }

        private static void Heaping(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Upper(array, i);
            }
        }

        private static void Upper(int[] array, int i)
        {
            int son = i;
            while (son > 0)
            {
                int father = (son - 1) / 2;

                if (array[father] < array[son])
                {
                    Swap(array ,father, son);
                    son = father;
                }
                else
                {
                    return;
                }
            }
        }

        private static void Swap(int[] array, int father, int son)
        {
            var temp = array[father];
            array[father] = array[son];
            array[son] = temp;
        }
    }
}