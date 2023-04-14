using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Assertions;

namespace _2023_GC_A2_Partiel_POO.Level_1
{
    public class MyMath
    {
        // Interdictions :
        // classe Math & MathF
        public static int Abs(int input)
        {
            if(input < 0)
                return input * -1;
            else 
                return input;
        }

        // Interdictions :
        // classe Math & MathF
        public static int Clamp(int input, int min, int max)
        {
            if(input > max)
                input = max;
            else if (input < min)
                input = min;

            return input;
        }

        // Interdictions :
        // classe Math & MathF
        public static int Floor(float input)
        {
            throw new NotImplementedException();
        }

        // Interdictions :
        // classe Math & MathF
        public static int Ceil(float input)
        {
            throw new NotImplementedException();
        }

        // Interdictions :
        // classe Math & MathF
        public static int Round(float input)
        {
            throw new NotImplementedException();
        }

        // Interdictions :
        // classe Math & MathF
        // LINQ & Enumerable
        public static float CalculateAverage(int[] input)
        {
            if (input == null)
                throw new ArgumentNullException("liste null");
            if (input.Length == 0)
                throw new ArgumentException("liste vide");

            float result = 0;
            for(int i =0; i < input.Length; i++)
            {
                result += input[i];
            }

            return result/ input.Length;
        }

    }
}
