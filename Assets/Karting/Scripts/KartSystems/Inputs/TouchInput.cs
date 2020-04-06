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

        bool m_FixedUpdateHappened;

        //bools to prevent conflicting movements
        bool forward;
        bool backward;
        bool leftward;
        bool rightward;

        //movement functions accessed by touch controls
        public void Accelerating()
        {
            forward = true;
            backward = false;
            if (forward && (!backward))
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