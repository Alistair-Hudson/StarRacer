using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Movement
{
    public class PlayerMovementInput : InputController
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                CallAccelerate();
            }
            else
            {
                CallDecelerate();
            }

            if (Input.GetKey(KeyCode.W))
            {
                CallPitchDown();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                CallPitchUp();
            }
            //else
            //{
            //    ResetModelPitch();
            //}

            if (Input.GetKey(KeyCode.D))
            {
                CallTurnRight();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                CallTurnLeft();
            }
            else
            {
                ResetModelRoll();
            }

        }
    }
}
