using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_GC_A2_Partiel_POO.Level_1
{
    public class MyArray
    {
        // Pas d'utilisation de liste, pas d'utilisation de Linq
        // Vous devez produire vous même le nouveau tableau 
        public static int[] AppendElementInArray(int[] initialArray, int elementToAdd)
        {
            if(initialArray != null)
            {
                int[] arr = new int[initialArray.Length + 1];
                for(int i = 0; i < initialArray.Length; i++)
                {
                    arr[i] = initialArray[i];
                }
                arr[^1] = elementToAdd;
                return arr;
            } 
            else
                throw new ArgumentNullException();
        }

        // Pas d'utilisation de liste, pas d'utilisation de Linq
        // Vous devez produire vous même le nouveau tableau 
        public static int[] ConcatElementsInArray(int[] initialArray, int[] elementsToAdd)
        {
            if (initialArray != null && elementsToAdd != null)
            {
                int[] arr = new int[initialArray.Length + elementsToAdd.Length];
                for (int i = 0; i < initialArray.Length; i++)
                {
                    arr[i] = initialArray[i];
                }
                for (int i = initialArray.Length; i < elementsToAdd.Length+ initialArray.Length; i++)
                {
                    arr[i] = elementsToAdd[i- initialArray.Length];
                }
                return arr;
            }
            else
                throw new ArgumentNullException();
        }

        // Pas d'utilisation de liste, pas d'utilisation de Linq
        // Vous devez produire vous même le nouveau tableau 
        public static int[] RemoveOccurenceInArray(int[] initialArray, int filter)
        {
            if (initialArray != null)
            {
                int[] arr = new int[initialArray.Length -1];
                for (int i = 0; i < initialArray.Length; i++)
                {
                    if(i != filter-1)
                        arr[i] = initialArray[i];
                }
                return arr;
            }
            else
                throw new ArgumentNullException();
        }

        // Pas d'utilisation de liste, pas d'utilisation de Linq
        // Vous devez produire vous même le nouveau tableau 
        public static int[] RemoveOccurenceInArray(int[] initialArray, int[] filter)
        {
            throw new NotImplementedException();
        }
    }
}
