using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// A basic keyboard implementation of the IInput interface for all the input information a kart needs.
    /// </summary>
    public class KeyboardInput : MonoBehaviour, IInput
    {
        public float Acceleration
        {
            get { return m_Acceleration; }
        }
        public float Steering
        {
            get { return m_Steering; }
        }
        public bool HopPressed
        {
            get { return m_HopPressed; }
        }
        public bool HopHeld
        {
            get { return m_HopHeld; }
        }

        public float m_Acceleration;
        public float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
      
        bool m_FixedUpdateHappened;

        //bools to prevent conflicting movements
        bool forward;
        bool backward;
        public bool leftward;
        public bool rightward;
        bool timeToTurn;
        bool turnButtonClicked;

        float steerDirection;

        private void Start()
        {
            forward = false;
            backward = false;
            rightward = false;
            leftward = false;

            steerDirection = m_Steering;
        }
        void Update ()
        {
            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
                m_Acceleration = 1f;
            else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
                m_Acceleration = -1f;
            else
                m_Acceleration = 0f;


            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                GoingLeft();
                m_Steering = steerDirection;
            }          
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                m_Steering = 1f;
            else
                m_Steering = 0f;

            //Touch Controls for Steering
            if (leftward && !rightward)
            {
                m_Steering = -1f;
            }
            else if (!leftward && rightward)
            {
                m_Steering = 1f;
            }
            else
                m_Steering = 0f;

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;
            }
        }

        void FixedUpdate ()
        {
            m_FixedUpdateHappened = true;
        }


        //movement functions accessed by touch controls
        public void Accelerating()
        {
            m_Acceleration = 1f;
        }

        public void Reversing()
        {   
            m_Acceleration = -1f;         
        }

        public void GoingLeft()
        {
            leftward = true;
        }

        public void GoingRight()
        {
            rightward = true;
        }
    }
}