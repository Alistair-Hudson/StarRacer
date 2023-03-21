using StarRacer.Navigation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Movement
{
    public class AIMovementInput : InputController
    {
        [SerializeField]
        private float minDistanceToTarget = 0.1f;
        [SerializeField]
        private float deccelerationChance = 0.5f;

        public Waypoint targetWaypoint;
        private Vector3 target;

        private void Awake()
        {
            targetWaypoint = FindObjectOfType<StartPoint>();
            target = targetWaypoint.GetPoint(Random.Range(-1f, 1), Random.Range(-1f, 1), Random.Range(-1f, 1));
        }

        private void Update()
        {
            if (Vector3.Distance(target, transform.position) <= minDistanceToTarget)
            {
                targetWaypoint = targetWaypoint.NextWaypoint;
                target = targetWaypoint.GetPoint(Random.Range(-1f, 1), Random.Range(-1f, 1), Random.Range(-1f, 1));
            }

            transform.LookAt(target);
            //TODO: find a means of making this work, so the turning looks more natural
            /*Vector2 targetDir = targetWaypoint.transform.position - transform.position;
            float yawAngle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);
            if (yawAngle < 0)
            {
                TurnLeft();
            }
            else if (yawAngle > 0)
            {
                TurnRight();
            }
            else
            {
                ResetModelRoll();
            }

            float pitchAngle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.right);
            if (pitchAngle < 0)
            {
                PitchDown();
            }
            else if (pitchAngle > 0)
            {
                PitchUp();
            }*/

            //Accelerate towards target call random deccelerate
            if (Random.Range(0f, 1f) < deccelerationChance)
            {
                CallDecelerate();
            }
            else
            {
                CallAccelerate();
            }

        }
    }
}
