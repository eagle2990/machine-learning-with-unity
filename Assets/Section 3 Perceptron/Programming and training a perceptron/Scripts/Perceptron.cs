using UnityEngine;

namespace Section3.Perceptron
{
    [System.Serializable]
    public class TrainingSet
    {
        public double[] input;
        public double output;
    } 

    public class Perceptron : MonoBehaviour
    {
        public TrainingSet[] trainingSet;
        double[] weights = { 0, 0 };
        double bias = 0;
        double totalError = 0;

        double DotProductBias(double[] weights, double[] inputs)
        {
            if (weights == null || inputs == null)
            {
                return -1;
            }

            if (weights.Length != inputs.Length)
            {
                return -1;
            }

            double d = 0;
            for (int x = 0; x < weights.Length; x++)
            {
                d += weights[x] * inputs[x];
            }
            d += bias;
            return d;
        }

        double CalculateOutput(int i)
        {
            double dotProduct = DotProductBias(weights, trainingSet[i].input);
            if (dotProduct > 0) return (1);
            return (0);
        }

        double CalculateOutput(double input1, double input2)
        {
            double[] input = new double[] { input1, input2 };
            double dotProduct = DotProductBias(weights, input);
            if (dotProduct > 0) return 1;
            return 0;
        }

        void UpdateWeights(int j)
        {
            double error = trainingSet[j].output - CalculateOutput(j);
            totalError += Mathf.Abs((float)error);
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = weights[i] + error * trainingSet[j].input[i];
            }
            bias += error;
        }

        void InitialiseWeights()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = Random.Range(-1.0f, 1.0f);
            }
            bias = Random.Range(-1.0f, 1.0f);
        }

        void Train(int epochs)
        {
            InitialiseWeights();

            for (int e = 0; e < epochs; e++)
            {
                totalError = 0;
                for (int t = 0; t < trainingSet.Length; t++)
                {
                    UpdateWeights(t);
                    Debug.Log("W1: " + (weights[0]) + " W2: " + (weights[1]) + " B " + bias);
                }
                Debug.Log("TOTAL ERROR: " + totalError);
            }
        }

        void Start()
        {
            Train(8);
            Debug.Log("Test 0 0: " + CalculateOutput(0, 0));
            Debug.Log("Test 0 1: " + CalculateOutput(0, 1));
            Debug.Log("Test 1 0: " + CalculateOutput(1, 0));
            Debug.Log("Test 1 1: " + CalculateOutput(1, 1));
        }
    }
}
