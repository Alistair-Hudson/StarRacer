using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Movement
{
    public abstract class InputController : MonoBehaviour
    {
        public event Action<bool> Accelerate;
        public event Action<bool> Pitch;
        public event Action<bool> Turn;

        protected void Acclerate()
        {
            Accelerate.Invoke(true);
        }

        protected void Decelerate()
        {
            Accelerate.Invoke(false);
        }

        protected void TurnRight()
        {
            Turn.Invoke(true);
        }

        protected void TurnLeft()
        {
            Turn.Invoke(false);
        }

        protected void PitchForward()
        {
            Pitch.Invoke(true);
        }

        protected void PitchBack()
        {
            Pitch.Invoke(false);
        }

        protected void ResetRoll()
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        }
    }
}