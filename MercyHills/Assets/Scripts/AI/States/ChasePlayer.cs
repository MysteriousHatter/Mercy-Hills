using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : IState
{
    private readonly Monster _monster;
    private NavMeshAgent _navmeshAgent;
    private readonly PlayerDetector _playerDetector;

    private float _initialSpeed;
    private float CHASE_SPEED;
    private float ANGULAR_SPEED;
    private float MON_ACCELERATE;
    private float distanceToPlayer;

    Status status;


    public ChasePlayer(Monster monster, NavMeshAgent navMeshAgent, PlayerDetector playerDetector, float Monspeed, float MonAngular, float MonAccelerate, Status patrolSpeed)
    {
        _monster = monster;
        _navmeshAgent = navMeshAgent;
        _playerDetector = playerDetector;
        CHASE_SPEED = Monspeed;
        ANGULAR_SPEED = MonAngular;
        MON_ACCELERATE = MonAccelerate;
        status = patrolSpeed;

    }
    public void OnEnter()
    {
        _navmeshAgent.enabled = true;
        _initialSpeed = _navmeshAgent.speed;
        _navmeshAgent.speed = status.getValue() >= 40? CHASE_SPEED * 2: CHASE_SPEED;
        _navmeshAgent.angularSpeed = status.getValue() >= 40 ? ANGULAR_SPEED * 2: ANGULAR_SPEED;
        _navmeshAgent.acceleration = status.getValue() >= 40 ? MON_ACCELERATE * 2 : MON_ACCELERATE;
    }
    public void Tick()
    {
        Vector3 direction = (_playerDetector._detectedPlayer.transform.position - _monster.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _monster.transform.rotation = Quaternion.Slerp(_monster.transform.rotation, lookRotation, Time.deltaTime * 10f);
        distanceToPlayer = Vector3.Distance(_monster.transform.position, _playerDetector._detectedPlayer.transform.position);
        DealingWithPlayer();
    }

    private void DealingWithPlayer()
    {
        if(distanceToPlayer >= _navmeshAgent.stoppingDistance)
        {
            _navmeshAgent.SetDestination(_playerDetector._detectedPlayer.transform.position);
        }
        else if(distanceToPlayer <= _navmeshAgent.stoppingDistance)
        {
            Debug.Log("Attack Player");
            status.deaths += 1; //This works but I will try another method with an animation event 
        }
    }

    public void OnExit()
    {
        _navmeshAgent.speed = _initialSpeed;
        _navmeshAgent.enabled = false;
    }

}
