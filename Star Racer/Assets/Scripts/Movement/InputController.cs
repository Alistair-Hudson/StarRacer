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
        public event Action<bool> Roll;

        protected void Acclerate()
        {
            Accelerate.Invoke(true);
        }

        protected void Decelerate()
        {
            Accelerate.Invoke(false);
        }

        protected void RollLeft()
        {
            Roll.Invoke(true);
        }

        protected void RollRight()
        {
            Roll.Invoke(false);
        }

        protected void PitchForward()
        {
            Pitch.Invoke(true);
        }

        protected void PitchBack()
        {
            Pitch.Invoke(false);
        }
    }
}