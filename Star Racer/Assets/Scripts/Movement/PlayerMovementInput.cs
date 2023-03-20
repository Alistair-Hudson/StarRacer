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
                Acclerate();
            }
            else
            {
                Decelerate();
            }

            if (Input.GetKey(KeyCode.W))
            {
                PitchForward();
            }
            if (Input.GetKey(KeyCode.S))
            {
                PitchBack();
            }
            if (Input.GetKey(KeyCode.D))
            {
                RollRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                RollLeft();
            }
        }
    }
}
