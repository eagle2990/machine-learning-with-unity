﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Section3.Dodgeball
{
    public class Throw : MonoBehaviour
    {
        public GameObject spherePrefab;
        public GameObject cubePrefab;
        public Material green;
        public Material red;

        Perceptron perceptron;

        void Start()
        {
            perceptron = GetComponent<Perceptron>();
        }

        void Update()
        {
            if (Input.GetKeyDown("1"))
            {
                GameObject g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = red;
                g.GetComponent<Rigidbody>().AddForce(0, 0, 500);
                perceptron.SendInput(0, 0, 0);
            }
            else if (Input.GetKeyDown("2"))
            {
                GameObject g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = green;
                g.GetComponent<Rigidbody>().AddForce(0, 0, 500);
                perceptron.SendInput(0, 1, 1);
            }
            else if (Input.GetKeyDown("3"))
            {
                GameObject g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = red;
                g.GetComponent<Rigidbody>().AddForce(0, 0, 500);
                perceptron.SendInput(1, 0, 1);
            }
            else if (Input.GetKeyDown("4"))
            {
                GameObject g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = green;
                g.GetComponent<Rigidbody>().AddForce(0, 0, 500);
                perceptron.SendInput(1, 1, 1);
            }
        }
    }
}