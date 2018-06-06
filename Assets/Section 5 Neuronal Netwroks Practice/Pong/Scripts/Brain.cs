using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Section5.Pong
{
    public class Brain : MonoBehaviour
    {
        public GameObject paddle;
        public GameObject ball;
        Rigidbody2D ballRigidBody;
        float yVelocity;
        float paddleMinY = 8.6f;
        float paddleMaxY = 17.6f;
        float paddleMaxSpeed = 15f;
        public float numSaved = 0f;
        public float numMissed = 0f;

        ANN ann;

        // Use this for initialization
        void Start()
        {
            ann = new ANN(6, 1, 1, 4, 0.11);
            ballRigidBody = ball.GetComponent<Rigidbody2D>();
        }

        List<double> Run(double bx, double by, double bvx, double bvy, double px, double py, double pv, bool train)
        {
            List<double> inputs = new List<double>();
            List<double> outputs = new List<double>();
            inputs.Add(bx);
            inputs.Add(by);
            inputs.Add(bvx);
            inputs.Add(bvy);
            inputs.Add(px);
            inputs.Add(py);
            outputs.Add(pv);
            if (train)
                return ann.Train(inputs, outputs);
            else
                return ann.CalcOutput(inputs, outputs);
        }

        // Update is called once per frame
        void Update()
        {
            float positionY = Mathf.Clamp(paddle.transform.position.y + (yVelocity * Time.deltaTime * paddleMaxSpeed),
                paddleMinY, paddleMaxY);
            paddle.transform.position = new Vector3(paddle.transform.position.x, positionY, paddle.transform.position.z);

            List<double> output = new List<double>();
            int layerMask = 1 << 10;
            RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, ballRigidBody.velocity, 1000, layerMask);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("tops"))
                {
                    Vector3 reflection = Vector3.Reflect(ballRigidBody.velocity, hit.normal);
                    hit = Physics2D.Raycast(hit.point, reflection, 1000, layerMask);
                }

                if (hit.collider != null && hit.collider.CompareTag("backwall"))
                {
                    float directionY = hit.point.y - paddle.transform.position.y;

                    output = Run(ball.transform.position.x,
                                    ball.transform.position.y,
                                    ballRigidBody.velocity.x,
                                    ballRigidBody.velocity.y,
                                    paddle.transform.position.x,
                                    paddle.transform.position.y,
                                    directionY, true);
                    yVelocity = (float)output[0];
                }
                else
                {
                    yVelocity = 0;
                }
            }
        }
    }
}