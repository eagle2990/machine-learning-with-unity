using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace EthanWalker
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class Brain : MonoBehaviour
    {
        public int DNALength = 1;
        public float timeAlive;
        public float distanceTravelled;
        private Vector3 initialPosition;
        public DNA dna;

        private ThirdPersonCharacter m_Character;
        private Vector3 m_Move;
        private bool m_Jump;
        bool alive = true;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("dead"))
            {
                alive = false;
            }
        }

        public void Init()
        {
            //initialise DNA
            //0 forward
            //1 back
            //2 left
            //3 right
            //4 jump
            //5 crouch
            dna = new DNA(DNALength, 6);
            m_Character = GetComponent<ThirdPersonCharacter>();
            timeAlive = 0;
            distanceTravelled = 0;
            initialPosition = transform.position;
            alive = true;
        }

        private void FixedUpdate()
        {
            float h = 0;
            float v = 0;
            bool crouch = false;

            switch (dna.GetGene(0))
            {
                case 0:
                    v = 1;
                    break;
                case 1:
                    v = -1;
                    break;
                case 2:
                    h = -1;
                    break;
                case 3:
                    h = 1;
                    break;
                case 4:
                    m_Jump = true;
                    break;
                case 5:
                    crouch = true;
                    break;
                default:
                    break;
            }

            m_Move = v * Vector3.forward + h * Vector3.right;
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
            if (alive)
            {
                timeAlive += Time.deltaTime;
                distanceTravelled = Vector3.Distance(transform.position, initialPosition);
            }
        }
    }
}
