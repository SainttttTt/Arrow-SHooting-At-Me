using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private UnityEvent PlayerLostScreen;

    public LogicManagement logic;
    public bool isAlive = true;
    public Rigidbody2D rb;
    public float m_Speed = 20.0f;
    public Joystick joystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Arrow"))
        {
            isAlive = false;
            PlayerLostScreen.Invoke(); //this calls the lostscreenCanva
        }

    }

    public float Radius = 24.0f;
    private Vector2 OriginPoint = new Vector2(0.0f, 0.0f);
    private void Update()
    {
        float distance = Vector2.Distance(this.transform.position, OriginPoint);

        if (distance > Radius)
        {
            Vector2 fromOriginToObject = new Vector2(transform.position.x, transform.position.y) - OriginPoint;
            fromOriginToObject *= Radius / distance;
            this.transform.position = OriginPoint + fromOriginToObject;
        }


        if (isAlive && logic.isPaused == false)
        {
            Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + input * Time.fixedDeltaTime * m_Speed);
        }
        else
        {
            joystick.gameObject.SetActive(false); //this gets reActiveted in GearButtonMenu in LogicManagement.cs
        }
    }
}
