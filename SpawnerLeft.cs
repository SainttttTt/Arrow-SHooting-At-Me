using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLeft : MonoBehaviour
{
    public GameObject[] Arrows;
    public CircularSpawner spawner;
    private float minus6 = -12.0f;
    public void Spawn()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            GameObject arrow = Instantiate(Arrows[i], transform.position, Quaternion.Euler(0,0,-45.0f));
            arrow.transform.position = new Vector3(transform.position.x, minus6, 0.0f);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(spawner.Speed, 0.0f);
            minus6 += 3;
        }

        minus6 = -12.0f;
    }
}
