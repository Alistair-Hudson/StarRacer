using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Navigation
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField]
        private float waypointRadius = 1f;
        public float WaypointRadius { get => waypointRadius; }
        [SerializeField]
        private Waypoint nextWaypoint;
        public Waypoint NextWaypoint { get => nextWaypoint; }

        public Vector3 GetPoint(float percentX, float percentY, float percentZ)
        {
            percentX = Mathf.Clamp(percentX, -1, 1);
            percentY = Mathf.Clamp(percentY, -1, 1);
            percentZ = Mathf.Clamp(percentZ, -1, 1);

            float x = transform.position.x + waypointRadius * percentX;
            float y = transform.position.y + waypointRadius * percentY;
            float z = transform.position.z + waypointRadius * percentZ;

            return new Vector3(x, y, z);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 0.1f);

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, waypointRadius);
            
            if (nextWaypoint != null)
            {
                transform.LookAt(nextWaypoint.transform);
                Gizmos.DrawLine(transform.position, nextWaypoint.transform.position);
            }

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.forward);
        }
    }
}