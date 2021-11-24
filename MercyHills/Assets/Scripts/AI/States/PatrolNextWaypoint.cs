using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

internal class PatrolNextWaypoint : IState
{

    private readonly Monster _monster;
    private readonly NavMeshAgent _navMeshAgent;
    private readonly int _currentIndex;
    //Patrol Values
    private float PATROL_SPEED;
    private float PATROL_ANGULAR_SPEED;
    private float PATROL_ACCELERATION;

    private Vector3 _lastPosition = Vector3.zero;

    public float TimeStuck;
    Status status;


    public PatrolNextWaypoint(Monster monster, NavMeshAgent navMeshAgent, int currentIndex, float pSpeed, float pAngular, float pAcceleration, Status statusPatrol)
    {
        _monster = monster;
        _navMeshAgent = navMeshAgent;
        _currentIndex = currentIndex;
        PATROL_SPEED = pSpeed;
        PATROL_ANGULAR_SPEED = pAngular;
        PATROL_ACCELERATION = pAcceleration;
        status = statusPatrol;
    }
    public void OnEnter()
    {
        TimeStuck = 0f;
        _navMeshAgent.enabled = true;
        _navMeshAgent.speed = status.getValue() >= 40? PATROL_SPEED * 2 : PATROL_SPEED;
        _navMeshAgent.angularSpeed = status.getValue() >= 40 ? PATROL_ANGULAR_SPEED * 2 : PATROL_ANGULAR_SPEED;
        _navMeshAgent.acceleration = status.getValue() >= 40 ? PATROL_ACCELERATION * 2 : PATROL_ACCELERATION;
        _navMeshAgent.SetDestination(_monster.waypoints[_monster.currentWaypointIndex].transform.position);

    }

    public void OnExit()
    {
        _navMeshAgent.enabled = false;
    }

    public void Tick()
    {
        Vector3 direction = (_monster.waypoints[_monster.currentWaypointIndex].transform.position - _monster.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _monster.transform.rotation = Quaternion.Slerp(_monster.transform.rotation, lookRotation, Time.deltaTime * 10f) ;
        //Debug.Log(_currentIndex);
        // float enemyDistance = Vector3.Distance(_monster.waypoints[_currentIndex].transform.position, _lastPosition);
        // Debug.Log("Enemy Distance " + enemyDistance);

        //if (enemyDistance <= 0f)
        //{
        //    TimeStuck += Time.deltaTime;
        //    //Debug.Log("The enemy's distance: " + enemyDistance);
        //}

        //_lastPosition = _monster.waypoints[_currentIndex].transform.position;
    }

}
