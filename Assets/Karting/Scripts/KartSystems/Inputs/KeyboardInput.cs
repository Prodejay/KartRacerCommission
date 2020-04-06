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

        float m_Acceleration;
        float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
      
        bool m_FixedUpdateHappened;

        //bools to prevent conflicting movements
        bool forward;
        bool backward;
        bool leftward;
        bool rightward;

        void Update ()
        {
            if (Input.GetKey(KeyCode.UpArrow))
                m_Acceleration = 1f;
            else if (Input.GetKey(KeyCode.DownArrow))
                m_Acceleration = -1f;
            else
                m_Acceleration = 0f;

            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                m_Steering = -1f;
            else if (!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                m_Steering = 1f;
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
            forward = true;
            backward = false;
            if(forward && (!backward))
            {
                m_Acceleration = 1f;
            }
        }

        public void Reversing()
        {
            forward = false;
            backward = true;
            if (!forward && (backward))
            {
                m_Acceleration = -1f;
            }
        }

        public void GoingLeft()
        {
            leftward = true;
            rightward = false;
            if (leftward && !rightward)
            {
                m_Steering = -1f;
            }
        }

        public void GoingRight()
        {
            leftward = false;
            rightward = true;
            if (!leftward && rightward)
            {
                m_Steering = 1f;
            }
        }
    }
}