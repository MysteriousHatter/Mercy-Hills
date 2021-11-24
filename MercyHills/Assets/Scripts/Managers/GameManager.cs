using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MonsterSpawner Spawners; //a reference to the spawner script instead of the GameObject
    private static GameManager _instance;
    public bool lightsOff { get; set; }

    public GameState currentState;
    public static event Action<GameState> OnGameStateChanged;
    public PlayerDetector introCutscene;

    public static int numOfDeaths;

    //For Testing purposes
    [SerializeField] bool enemyChecker;



    public static GameManager Instance
    {
        get
        {
            if(_instance == null) { Debug.LogError("GameManager is Null!!!"); }
            return _instance;
        }


        
    }
    private void Awake()
    {
        Spawners = FindObjectOfType<MonsterSpawner>();
        _instance = this;
    }
    private void Update()
    {
        ActivateDeactivateSpawner();
        //SkipCutscene();
    }

    private void SkipCutscene()
    {
        ///If the user presses a button we'll skip the cutscene
        ///
    }

    private void ActivateDeactivateSpawner()
    {
        if (enemyChecker)
        {
            Spawners.StartSpawners();
        }
        else
        {
            Spawners.StopSpawnWaves();
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(o);
            }

        }
    }

    void Start()
    {
        ChangeState(GameState.Normal);
    }

    public void ChangeState(GameState changeState)
    {
        currentState = changeState;

        switch (changeState)
        {
            case GameState.Normal:
                break;
            case GameState.Death:
                numOfDeaths += 1;
                break;
            case GameState.Pause:
                break;
        }

        OnGameStateChanged?.Invoke(changeState);
    }

}

public enum GameState
{
    Normal,
    Pause,
    Death
}

