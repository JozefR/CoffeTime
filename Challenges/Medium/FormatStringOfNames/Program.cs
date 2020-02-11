using System;
using System.Collections.Generic;

namespace Format_a_string_of_names
{
    class Program
    {
        /*
         * Given: an array containing hashes of names
         * Return: a string formatted as a list of names separated by commas except for the
         * last two names, which should be separated by an ampersand.
         *
         * Example:
         * list([ {name: 'Bart'}, {name: 'Lisa'}, {name: 'Maggie'} ])
         * // returns 'Bart, Lisa & Maggie'
         *
         * list([ {name: 'Bart'}, {name: 'Lisa'} ]
         * // returns 'Bart & Lisa'
         *
         * list([ {name: 'Bart'} ])
         * // returns 'Bart'
         *
         * list([])
         * // returns ''
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            /*
             * set empty string
             * set counter for each iteration
             *     iterate over list of names if length is greater then 1
             *         set length of list for ,,and,, separator ()
             */
            var list = new List<string>
            {
                {"Bart"},
                {"Lisa"},
                {"Maggie"},
                {"Fero"}
            };
            
            var list1 = new List<string>
            {
                {"Bart"},
                {"Lisa"},
            };        
            
            var list2 = new List<string>
            {
                {"Bart"},
            };

            FormatString(list2);
        }

        private static string FormatString(List<string> list)
        {
            var format = "";
            var cnt = 0;

            if (list.Count == 1)
            {
                format += list[0];
            }

            for (int i = 0; i + 1 < list.Count; i++)
            {
                var andSeparator = list.Count - cnt;
                format += list[i];
                
                if (andSeparator == 2)
                {
                    format += " & ";
                    format += list[i + 1];
                    break;
                }

                format += ", ";
                cnt++;
            }
            
            return format;
        }
    }
}