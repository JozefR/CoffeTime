using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AirportArrivalsDepartures
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ?!@#&()|<>.:=-+*/0123456789";

        public static string[] FlapDisplay(string[] lines, int[][] rotors)
        {
            string[] result = new String[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string rotatedResult = "";
                int rotorsSum = 0;

                for (int j = 0; j < lines[i].Length; j++)
                {
                    rotorsSum += rotors[i][j];
                    var oldCharacter = lines[i][j];

                    var newCharacter = Rotation(oldCharacter, rotorsSum);

                    rotatedResult += newCharacter;
                }

                result[i] = rotatedResult;
            }

            return result;
        }

        private static char Rotation(in char oldCharacter, int rotorsSum)
        {
            var startFromIndex = ALPHABET.IndexOf(oldCharacter);
            var rotation = (startFromIndex + rotorsSum) % ALPHABET.Length;
            return ALPHABET[rotation];
        }

        public static string[] FlapDisplay2(String[] lines, int[][] rotors)
        {
            for (int l = 0; l < lines.Length; l++)
            for (int i = 0; i < lines[l].Length; i++)
            for (int k = i; k < lines[l].Length; k++)
                lines[l] = lines[l].Remove(k, 1).Insert(k, lines[l][k].Rotate(rotors[l][i]));
            return lines;
        }
        
        public static string[] FlapDisplay3(String[] lines, int[][] rotors)
        {
            foreach (var line in lines.Select((value, h) => new {h, value}))
            {
                foreach (var ch in lines[line.h].Select((value, i) => new {i, value}))
                {
                    // move all letters at position i or greater by the rotor number and account for wrapping around ALPHABET
                    for (var j = ch.i; j < lines[line.h].Length; j++)
                    {
                        // if the move will reach the end of ALPHABET then start at the beginning of ALPHABET
                        // with the difference of ALPHABET.Length and the sum of current position and the move
                        var currentMove = ALPHABET.IndexOf(lines[line.h][j]) + rotors[line.h][ch.i];
                        while (currentMove >= ALPHABET.Length)
                        {
                            currentMove = currentMove - ALPHABET.Length;
                        }

                        lines[line.h] = lines[line.h].Remove(j, 1);
                        lines[line.h] = lines[line.h].Insert(j, ALPHABET.Substring(currentMove, 1));
                    }
                }
            }
        
            return lines;
        }
        
        public static string[] FlapDisplay4(String[] lines, int[][] rotors)
        {
            List<string> resultList = new List<string>();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i<lines.Length; i++){
                List<int> rotorsShifts = rotors[i].Select((x,index) => rotors[i].Take(index).Sum() + x).ToList();
                for(int index = 0; index<rotorsShifts.Count; index++){
                    char symbol = lines[i][index];
                    char newSymbol = ALPHABET[(ALPHABET.IndexOf(symbol) + rotorsShifts[index]) % ALPHABET.Length];
                    sb.Append(newSymbol);
                }
                resultList.Add(sb.ToString());
                sb.Clear();
            }
            return resultList.ToArray();
            
        }
        
        private static char RotateBy(char letter, int rotations){
            int oldPosition = ALPHABET.IndexOf(letter);
            int newPosition = (oldPosition + rotations) % ALPHABET.Length;
            return ALPHABET[newPosition];
        }

        public static string[] FlapDisplay5(String[] lines, int[][] rotors) {
            string[] result = new string[lines.Length];
    
            for(int i = 0; i < lines.Length; i++){
                var line = lines[i];
                var rotations = rotors[i];
      
                StringBuilder sb = new StringBuilder(line);
                for(int rotationIndex = 0; rotationIndex < rotations.Length; rotationIndex++){
                    int rotation = rotations[rotationIndex];
                    for(int j = rotationIndex; j < rotations.Length; j++){
                        sb[j] = RotateBy(sb[j], rotation);
                    }
                }
      
                result[i] = sb.ToString();
            }
            return result;
        }
    }

    public static class CharExtension
    {
        private static string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ?!@#&()|<>.:=-+*/0123456789";

        public static string Rotate(this char c, int rotor)
        {
            int position = ALPHABET.IndexOf(c) + rotor;
            while (position >= ALPHABET.Length)
                position -= ALPHABET.Length;
            return "" + ALPHABET[position];
        }
    }

    
    
    [TestFixture]
    public class AirportArrivalsDeparturesTests
    {
        [Test]
        public void TestCase()
        {
            // CAT => DOG
            var before = new[] {"CAT"};
            var rotors = new int[][] {new[] {1, 13, 27}};
            var after = Program.FlapDisplay(before, rotors);
            var expected = new[] {"DOG"};
            Assert.AreEqual(expected, after);
        }

        [Test]
        public void TestCase1()
        {
            // HELLO => WORLD!
            var before = new[] {"HELLO "};
            var rotors = new int[][] {new[] {15, 49, 50, 48, 43, 13}};
            var after = Program.FlapDisplay(before, rotors);
            var expected = new[] {"WORLD!"};
            Assert.AreEqual(expected, after);
        }

        [Test]
        public void TestCase2()
        {
            // CODE => WARS
            var before2 = new[] {"CODE"};
            var rotors2 = new int[][] {new[] {20, 20, 28, 0}};
            var after2 = Program.FlapDisplay(before2, rotors2);
            var expected2 = new[] {"WARS"};
            Assert.AreEqual(expected2, after2);
        }
    }
}