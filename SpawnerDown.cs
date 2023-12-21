using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerDown : MonoBehaviour
{
    public GameObject[] Arrows;
    public CircularSpawner spawner;
    private float minus6 = -13.66f; //values get from world
    public void Spawn()
    {
        for(int i = 0; i < Arrows.Length; i++)
        {
            GameObject arrow = Instantiate(Arrows[i], transform.position, Quaternion.Euler(0, 0, 45.0f)) ;
            arrow.transform.position = new Vector3(minus6, transform.position.y, 0.0f);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0, spawner.Speed);
            minus6 += 3;
        }

        minus6 = -13.66f;
    }
}
