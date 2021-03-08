using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public float moveSpeed;
  public Transform shottingOffset;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);
      }
      if (Input.GetButton("Horizontal"))
      {
        gameObject.transform.localPosition += 
          Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * moveSpeed;
      }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.tag == "EnemyBullet")
      {
        Destroy(this.gameObject);
        Destroy(other.gameObject);
      }
    }
}
