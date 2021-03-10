using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public static bool moveDown = false;
    private Points pointsManager;
    public static int MOVE_TIME = 1;
    private MotherShip motherShip;
    public GameObject bullet;
    private Vector3 CurrentPosition;
    private Rigidbody2D rb;
    public static float moveSpeed = 1;
    private void Awake()
    {
        pointsManager = FindObjectOfType<Points>();
        motherShip = FindObjectOfType<MotherShip>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MoveDown();
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Bullet")
      {
          pointsManager.awardPoint(tag);
          Destroy(collision.gameObject);
          Destroy(this.gameObject);
          motherShip.deathCount++;
      }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            moveSpeed = -moveSpeed;
            moveDown = true;
        }
    }

    private IEnumerator OnTriggerExit2D(Collider2D other)
    {
        yield return new WaitForSeconds(MOVE_TIME);
        moveDown = false;
    }


    void Move()
    {
            transform.Translate(Vector3.left* moveSpeed* Time.deltaTime);
    }

    void MoveDown()
    {
        if (moveDown)
        {
            transform.Translate(Vector3.down* Time.deltaTime);
        }
    }

    public void Fire()
    {
        CurrentPosition = new Vector3(transform.position.x, 
            transform.position.y - 1, transform.position.z);
        
        Instantiate(bullet,CurrentPosition,transform.rotation);
    }
    
}
