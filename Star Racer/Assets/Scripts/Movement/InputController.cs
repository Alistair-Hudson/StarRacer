using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Movement
{
    public abstract class InputController : MonoBehaviour
    {
        [SerializeField]
        private Transform modelTransform;
        [SerializeField]
        private float modelRoll = 45f;
        [SerializeField]
        private float modelPitch = 45f;
        [SerializeField]
        private float rollRate = 1f;

        public event Action<bool> Accelerate;
        public event Action<bool> Pitch;
        public event Action<bool> Turn;

        protected void CallAccelerate()
        {
            Accelerate.Invoke(true);
        }

        protected void CallDecelerate()
        {
            Accelerate.Invoke(false);
        }

        protected void CallTurnRight()
        {
            var eulers = modelTransform.localRotation.eulerAngles;
            float eulerZ = eulers.z <= 0 ? 360 - eulers.z : eulers.z;
            eulerZ = Mathf.Clamp(eulerZ - rollRate, 360 - modelRoll, 360);
            modelTransform.localRotation = Quaternion.Euler(new Vector3(eulers.x, eulers.y, eulerZ));
            Turn.Invoke(true);
        }

        protected void CallTurnLeft()
        {
            var eulers = modelTransform.localRotation.eulerAngles;
            float eulerZ = Mathf.Clamp(eulers.z + rollRate, 0, modelRoll);
            modelTransform.localRotation = Quaternion.Euler(new Vector3(eulers.x, eulers.y, eulerZ));
            Turn.Invoke(false);
        }

        protected void CallPitchDown()
        {
            //var eulers = modelTransform.localRotation.eulerAngles;
            //modelTransform.rotation = Quaternion.Euler(new Vector3(modelPitch, eulers.y, eulers.z));
            Pitch.Invoke(true);
        }

        protected void CallPitchUp()
        {
            //var eulers = modelTransform.localRotation.eulerAngles;
            //modelTransform.localRotation = Quaternion.Euler(new Vector3(-modelPitch, eulers.y, eulers.z));
            Pitch.Invoke(false);
        }

        protected void ResetModelRoll()
        {
            var eulers = modelTransform.localRotation.eulerAngles;
            var eulerZ = eulers.z;
            if (eulerZ < 0 || eulerZ > 180)
            {
                eulerZ += rollRate;
            }
            else if (eulerZ > 0)
            {
                eulerZ -= rollRate;
            }
            modelTransform.localRotation = Quaternion.Euler(eulers.x, eulers.y, eulerZ);
        }

        protected void ResetModelPitch()
        {
            var eulers = modelTransform.localRotation.eulerAngles;
            modelTransform.localRotation = Quaternion.Euler(0, eulers.y, eulers.z);
        }
    }
}