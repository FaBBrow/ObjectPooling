using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 mousepoint;
    public Vector3 mouseposition;

    public float inputx;
    public float inputy;
    public Rigidbody2D body;
    public int speed;

    public static Player instance;
    private void Awake()
    {
        instance = this;
        body = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        mouseposition = Input.mousePosition;

        mousepoint = Camera.main.ScreenToWorldPoint(mouseposition);

        Vector2 direction = new Vector2(mousepoint.x - transform.position.x, mousepoint.y - transform.position.y);
        transform.up = direction;

       
        
    }
  
}
