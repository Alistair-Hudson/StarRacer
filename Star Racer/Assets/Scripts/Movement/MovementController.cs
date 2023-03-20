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
        private float yawRate = 1f;
        [SerializeField]
        private float maxSpeed = 50f;

        private Rigidbody myRigidBody;

        private void Awake()
        {
            myRigidBody = GetComponent<Rigidbody>();
            var inputController = GetComponent<InputController>();
            inputController.Accelerate += Accelerate;
            inputController.Pitch += Pitch;
            inputController.Turn += Turn;
        }

        private void Accelerate(bool acclerate)
        {
            var currentVelocity = myRigidBody.velocity.z;
            currentVelocity += acclerate ? acceleration : -acceleration;
            currentVelocity = Mathf.Clamp(currentVelocity, 0, maxSpeed);
            myRigidBody.velocity = Vector3.forward * currentVelocity;
        }

        private void Pitch(bool pitchForward)
        {
            var rotation = transform.rotation.eulerAngles;
            rotation += Vector3.right * (pitchForward ? pitchRate : -pitchRate);
            transform.rotation = Quaternion.Euler(rotation);
        }

        private void Turn(bool turnRight)
        {
            var rotation = transform.rotation.eulerAngles;
            rotation += Vector3.up * (turnRight ? yawRate : -yawRate);
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}