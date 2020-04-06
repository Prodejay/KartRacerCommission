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

        //bools to prevent conflicting movements
        bool forward;
        bool backward;
        bool leftward;
        bool rightward;

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
            m_Steering = -1f;
        }

        public void GoingRight()
        {
             m_Steering = 1f;
        }
    }
}