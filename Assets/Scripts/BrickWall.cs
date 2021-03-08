using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWall : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
