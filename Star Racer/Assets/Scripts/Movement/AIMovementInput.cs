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

        private Waypoint targetWaypoint;
        private Vector3 target;

        private void Awake()
        {
            targetWaypoint = FindObjectOfType<StartPoint>();
            target = targetWaypoint.GetPoint(Random.Range(-1f, 1), Random.Range(-1f, 1), Random.Range(-1f, 1));
        }

        private void Update()
        {
            
        }
    }
}
