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

        private void Start()
        {
            targetWaypoint = FindObjectOfType<StartPoint>();
            target = new Vector3(transform.position.x, transform.position.y, targetWaypoint.transform.position.z);
        }

        private void Update()
        {
            if (Vector3.Distance(target, transform.position) <= minDistanceToTarget)
            {
                targetWaypoint = targetWaypoint.NextWaypoint;
                target = targetWaypoint.GetPoint(Random.Range(-1f, 1), Random.Range(-1f, 1), Random.Range(-1f, 1));
            }

            transform.LookAt(target);

            //Accelerate towards target, call random deccelerate
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
