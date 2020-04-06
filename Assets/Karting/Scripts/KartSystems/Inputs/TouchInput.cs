using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    public class TouchInput : MonoBehaviour, IInput
    {
        public float Acceleration
        {
            get { return m_Acceleration; }
        }
        public float Steering
        {
            get { return m_Steering; }
        }
        public bool BoostPressed
        {
            get { return m_BoostPressed; }
        }
        public bool FirePressed
        {
            get { return m_FirePressed; }
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
        bool m_BoostPressed;
        bool m_FirePressed;

        bool m_FixedUpdateHappened;

        bool accelerate;
        bool reverse;

        private void Start()
        {
            accelerate = false;
            reverse = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                m_Acceleration = 1f;
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                m_Acceleration = -1f;
            else
                m_Acceleration = 0f;

            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                m_Steering = -1f;
            else if (!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                m_Steering = 1f;
            else
                m_Steering = 0f;

            m_HopHeld = Input.GetKey(KeyCode.Space);

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            //m_HopPressed |= Input.GetKeyDown (KeyCode.Space);
            //m_BoostPressed |= Input.GetKeyDown (KeyCode.RightShift);
            //m_FirePressed |= Input.GetKeyDown (KeyCode.RightControl);
        }

        void FixedUpdate()
        {
            m_FixedUpdateHappened = true;
        }

        public void Accelerating()
        {
            m_Acceleration = 1f;
        }

        public void Reversing()
        {
            m_Acceleration = -1f;
        }
    }
}