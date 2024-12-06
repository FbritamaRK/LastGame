﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnMenu : MonoBehaviour {

    public GameObject[] Enemy;
    public Transform SpawnPoint;

    public float TimerMin = 5f;
    public float TimerMax = 10f;

    private float Timer = 5;

    private float nextTime = 0.5F;
    private float myTime = 0.0F;


    void Update()
    {

        myTime = myTime + Time.deltaTime;
        if (myTime > nextTime)
        {
            Timer = Random.Range(TimerMin, TimerMax);
            nextTime = myTime + Timer;
            Instantiate(Enemy[Random.Range(0, 3)], new Vector2(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y), Quaternion.identity);          
            nextTime = nextTime - myTime;
            myTime = 0.0F;
        }
    }
}