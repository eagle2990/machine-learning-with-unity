using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingGASWithSenses
{
    public class DNA
    {
        List<int> genes = new List<int>();
        int dnaLength = 0;
        int maxValues = 0;

        public DNA(int length, int max)
        {
            dnaLength = length;
            maxValues = max;
            SetRandom();
        }

        public void SetRandom()
        {
            genes.Clear();
            for (int i = 0; i < dnaLength; i++)
            {
                genes.Add(Random.Range(0, maxValues));
            }
        }

        public void SetInt(int position, int value)
        {
            genes[position] = value;
        }

        public void Combine(DNA dna1, DNA dna2)
        {
            for (int i = 0; i < dnaLength; i++)
            {
                if (i < dnaLength / 2.0)
                {
                    genes[i] = dna1.genes[i];
                }
                else
                {
                    genes[i] = dna2.genes[i];
                }
            }
        }

        public void Mutate()
        {
            genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValues);
        }

        public int GetGene(int position)
        {
            return genes[position];
        }
    }
}

