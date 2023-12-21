using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSpawner : MonoBehaviour
{
    public GameObject arrowPreFab; //this is the arrow
    public GameObject Target; //this is the player

    public float Speed      = 9.0f; //speed of arrow
    public float timeSpawn  = 1.5f; //time of spawn between arrow
    public float timer      = 0.0f;

    private void Update()
    {
        if(timer < timeSpawn)
        {
            timer += Time.deltaTime;
            return;
        }

        float AngleRotation = RotateToTarget();
        
        GameObject Arrow = Instantiate(arrowPreFab, transform.position, Quaternion.Euler(0, 0, (AngleRotation * 180.0f / Mathf.PI) - 45.0f)); // conversion in degrees, -45 bcs is 45 degrees up
        Arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * Mathf.Cos(AngleRotation), Speed * Mathf.Sin(AngleRotation)); // to get a modulo vector of Speed
       
        timer = 0;
    }

    private float RotateToTarget()
    {
        float distanceX = Target.transform.position.x - transform.position.x;
        float distanceY = Target.transform.position.y - transform.position.y;
        return Mathf.Atan2(distanceY,distanceX); //angles in radians
    }
}
