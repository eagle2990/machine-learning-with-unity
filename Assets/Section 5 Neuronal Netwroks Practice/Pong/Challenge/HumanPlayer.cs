using UnityEngine;

namespace Section5.Pong.Challenge
{
    public class HumanPlayer : MonoBehaviour
    {
        float paddleMinY = 8.6f;
        float paddleMaxY = 17.6f;
        Rigidbody2D rigidBody;
        float paddleMaxSpeed = 15f;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            if (transform.position.y > paddleMaxY)
            {
                rigidBody.velocity = Vector2.zero;
                transform.position = new Vector3(transform.position.x, paddleMaxY, transform.position.z);
            }


            if (transform.position.y < paddleMinY)
            {
                rigidBody.velocity = Vector2.zero;
                transform.position = new Vector3(transform.position.x, paddleMinY, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
                if(rigidBody.velocity.y < paddleMaxSpeed)
                {
                    rigidBody.velocity += Vector2.up;
                }
                
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                if (Mathf.Abs(rigidBody.velocity.y) < paddleMaxSpeed)
                {
                    rigidBody.velocity += Vector2.down;
                }
                
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                rigidBody.velocity = Vector2.zero;
            }
        }
    }
}