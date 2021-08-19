using UnityEngine;
using UnityEngine.AI;

namespace MyProject
{
    public class WayPointPatrol : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Transform[] _waypoints;
        private int _randomSpot;

        int _CurrentWaypointIndex;

        private void Awake()
        {
            _randomSpot = Random.Range(0, _waypoints.Length);
        }

        void Start()
        {
            navMeshAgent.SetDestination(_waypoints[0].position);
        }

        void Update()
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
                navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
            }
        }
    }
}
