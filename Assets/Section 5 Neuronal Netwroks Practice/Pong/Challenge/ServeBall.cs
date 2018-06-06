using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Section5.Pong.Challenge
{
    public class ServeBall : MonoBehaviour
    {
        public GameObject ball;

        public bool backWall = false;
        public Brain b;

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "ball" && backWall)
            {
                b.numMissed += 1;
                ball.GetComponent<MoveBall>().ResetBall();
            }
        }
    }
}