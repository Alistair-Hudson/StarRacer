using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(InputController))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField]
        private float acceleration = 1f;
        [SerializeField]
        private float pitchRate = 1f;
        [SerializeField]
        private float rollRate = 1f;
        [SerializeField]
        private float yawRate = 1f;

        private Rigidbody myRigidBody;

        private void Awake()
        {
            myRigidBody = GetComponent<Rigidbody>();
            var inputController = GetComponent<InputController>();
            inputController.Accelerate += Accelerate;
            inputController.Pitch += Pitch;
            inputController.Roll += Roll;
        }

        private void Accelerate(bool acclerate)
        {
            myRigidBody.velocity += Vector3.forward * (acclerate ? acceleration : -acceleration);
            if (myRigidBody.velocity.z < 0)
            {
                myRigidBody.velocity = Vector3.zero;
            }
        }

        private void Pitch(bool pitchForward)
        {
            var rotation = transform.rotation.eulerAngles;
            rotation += Vector3.right * (pitchForward ? pitchRate : -pitchRate);
            transform.rotation = Quaternion.Euler(rotation);
        }

        private void Roll(bool roolRight)
        {
            var rotation = transform.rotation.eulerAngles;
            rotation += Vector3.forward * (roolRight ? rollRate : -rollRate);
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}