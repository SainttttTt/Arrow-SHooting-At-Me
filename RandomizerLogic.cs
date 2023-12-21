using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class RandomizerLogic : MonoBehaviour
{
    public CircularSpawner[] Spawns;
    public UnityEvent[] SpawnRows;

    private void Start()
    {
        InvokeRepeating("SpawnRowsofArrow", 13.00f, 6.50f);
    }

    private void Update()
    {
        float VarySpeed = Random.Range(1.0f, 1.56f);      //this changes the rate at the start at which every spawner spawn the arrows
        for (int i = 0; i < Spawns.Length; i++)
        {
            Spawns[i].timeSpawn = VarySpeed;
            VarySpeed += Random.Range(0.2f,0.16f);
        }
    }
    public void SpawnRowsofArrow()
    {
        int random = Random.Range(0, SpawnRows.Length);
        SpawnRows[random].Invoke();
    }

}
