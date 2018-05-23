using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Section4.FirstNeuralNetwork
{
    public class Brain : MonoBehaviour
    {
        ArtificialNeuralNetwork artificialNeuralNetwork;
        double sumSqrError = 0;

        void Start()
        {
            artificialNeuralNetwork = new ArtificialNeuralNetwork(2, 1, 1, 2, 0.8);
            List<double> result;

            for (int i = 0; i < 50000; i++)
            {
                sumSqrError = 0;
                result = Train(1, 1, 1);
                sumSqrError += Mathf.Pow((float)result[0] - 1, 2);
                result = Train(1, 0, 0);
                sumSqrError += Mathf.Pow((float)result[0] - 0, 2);
                result = Train(0, 1, 0);
                sumSqrError += Mathf.Pow((float)result[0] - 0, 2);
                result = Train(0, 0, 1);
                sumSqrError += Mathf.Pow((float)result[0] - 1, 2);
            }
            Debug.Log("SSE: " + sumSqrError);

            result = Train(1, 1, 1);
            Debug.Log(" 1 1 " + result[0]);
            result = Train(1, 0, 0);
            Debug.Log(" 1 0 " + result[0]);
            result = Train(0, 1, 0);
            Debug.Log(" 0 1 " + result[0]);
            result = Train(0, 0, 1);
            Debug.Log(" 0 0 " + result[0]);
        }

        List<double> Train(double i1, double i2, double o)
        {
            List<double> inputs = new List<double>();
            List<double> outputs = new List<double>();
            inputs.Add(i1);
            inputs.Add(i2);
            outputs.Add(o);
            return artificialNeuralNetwork.Go(inputs, outputs);
        }
    }
}