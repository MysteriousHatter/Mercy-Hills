using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitOnWaypoint : IState
{
    private readonly Monster _monster;
    private float _nextIdleWaitTIme;
    private const float _WaitPerSecond = 8f;


    public WaitOnWaypoint(Monster monster)
    {
        _monster = monster;
    }



    public void Tick()
    {
        if(_monster.canMove != false)
        {
            if(_nextIdleWaitTIme <= Time.time)
            {
                if(_monster.currentWaypointIndex % 2 == 0)
                {
                    _nextIdleWaitTIme = Time.time + (1f / _WaitPerSecond);
                    _monster.StartCoroutine(_monster.WaitBeforeMoving());
                }
                else
                {
                    _nextIdleWaitTIme = Time.time + (1f / _WaitPerSecond);
                    _monster.canMove = true;
                }

                
            }
        }
    }


    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

}
