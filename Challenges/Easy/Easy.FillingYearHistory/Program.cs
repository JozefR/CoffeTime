using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Easy.FillingYearHistory
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // Always return last four years.
        private static List<int> HistoryOfLastFour(List<int> latestHistoryList)
        {
            var orderedHistoryList = latestHistoryList.OrderByDescending(x => x).Take(4).ToList();
            var lastFourYears = Enumerable.Range(DateTime.Now.Year - 3, 4).Reverse().ToList();

            for (int i = 0; i < lastFourYears.Count; i++)
            {
                if (CheckEmptyOrNotFourHistory(i, lastFourYears, orderedHistoryList))
                {
                    AddMissingYear(i, lastFourYears, orderedHistoryList);
                }
            }

            return orderedHistoryList.Take(4).ToList();
        }

        private static bool CheckEmptyOrNotFourHistory(int i, List<int> lastFourYears, List<int> latestHistoryList)
        {
            if (latestHistoryList.Count == 0 || i == latestHistoryList.Count)
            {
                return true;
            }

            var year = latestHistoryList[i];

            if (year != lastFourYears[i])
            {
                return true;
            }

            return false;
        }

        private static void AddMissingYear(int i, List<int> lastFourYears, List<int> latestHistoryList)
        {
            var missingYear = lastFourYears[i];
            
            latestHistoryList.Insert(i, missingYear);
        }
        
        [TestFixture]
        public class HistoryOfFourTests
        {
            private static readonly object[] _years = 
            {
                new object[] {new List<int>()},   
                new object[] {new List<int> {2020, 2019, 2018, 2017}},
                new object[] {new List<int> {2017, 2018, 2019, 2020}},
                new object[] {new List<int> {2020, 2019, 2018, 2017, 2016, 2015}},
                new object[] {new List<int> {2015, 2016, 2017, 2018, 2019, 2020}},
                new object[] {new List<int> {2016, 2015}},
                new object[] {new List<int> {2020 }},   
                new object[] {new List<int> {2019 }},   
                new object[] {new List<int> {2018 }},   
                new object[] {new List<int> {2017 }},   
                new object[] {new List<int> {2016 }},   
                new object[] {new List<int> {2015 }},   
            };
            
            [TestCaseSource(nameof(_years))]
            public void CheckYears(List<int> list)
            {
                var expected = new List<int> { 2020, 2019, 2018, 2017 };
                
                Assert.AreEqual(expected, Program.HistoryOfLastFour(list));
            }
        }
    }
}