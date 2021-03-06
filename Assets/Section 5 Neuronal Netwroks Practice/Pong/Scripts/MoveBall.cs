﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Section5.Pong
{
    public class MoveBall : MonoBehaviour
    {

        Vector3 ballStartPosition;
        Rigidbody2D rb;
        float force = 400;
        public AudioSource blip;
        public AudioSource blop;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ballStartPosition = transform.position;
            ResetBall();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("backwall"))
            {
                blop.Play();
            }
            else
            {
                blip.Play();
            }
        }

        public void ResetBall()
        {
            transform.position = ballStartPosition;
            rb.velocity = Vector3.zero;
            Vector3 direction = new Vector3(Random.Range(100, 300), Random.Range(-100, 100), 0).normalized;
            rb.AddForce(direction * force);
        }

        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                ResetBall();
            }
        }
    }
}