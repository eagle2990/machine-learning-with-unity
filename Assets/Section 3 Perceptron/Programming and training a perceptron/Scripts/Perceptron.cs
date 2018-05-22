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

        public SimpleGrapher grapher;

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
            DrawAllPoints();
            Train(200);
            grapher.DrawRay((float)(-(bias / weights[1]) / (bias / weights[0])), (float)(-bias / weights[1]), Color.red);
            DrawCalculatedPoint(0, 0);
            DrawCalculatedPoint(0, 1);
            DrawCalculatedPoint(1, 0);
            DrawCalculatedPoint(1, 1);
            DrawCalculatedPoint(0.3, 0.9);
            DrawCalculatedPoint(0.8, 0.1);
        }

        void DrawAllPoints()
        {
            for (int i = 0; i < trainingSet.Length; i++)
            {
                if (trainingSet[i].output == 0)
                {
                    grapher.DrawPoint((float)trainingSet[i].input[0], (float)trainingSet[i].input[1], Color.magenta);
                }
                else
                {
                    grapher.DrawPoint((float)trainingSet[i].input[0], (float)trainingSet[i].input[1], Color.green);
                }
            }
        }

        void DrawCalculatedPoint(double point1, double point2)
        {
            double output = CalculateOutput(point1, point2);
            Debug.Log("Test " + point1 + " " + point2 + ": " + output);
            if (CalculateOutput(point1, point2) == 0)
            {
                grapher.DrawPoint((float)point1, (float)point2, Color.red);
            }
            else
            {
                grapher.DrawPoint((float)point1, (float)point2, Color.yellow);
            }
        }
    }
}
