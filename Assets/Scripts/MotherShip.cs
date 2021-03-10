using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class MotherShip : MonoBehaviour
{
    public Points points;
    public GameObject EnemyType1;
    public GameObject EnemyType2;
    public GameObject EnemyType3;
    public GameObject EnemyType4;
    private int randomInt;
    public int deathCount = 0;

    private Enemy[] b;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    
    void Start()
    {
        MyInstantate("EnemyType1", transform,-3, 0);
        MyInstantate("EnemyType2", transform,-1, 0);
        MyInstantate("EnemyType3", transform,1, 0);
        MyInstantate("EnemyType4", transform,3, 0);
        b = FindObjectsOfType<Enemy>();
        StartCoroutine(Fire());
    }

    void MyInstantate(String gameTag, Transform position, float x, float y)
    {
        Vector3 pos = new Vector3(transform.position.x + x, transform.position.y + y,
            transform.position.z);

        switch (gameTag)
        {
            case "EnemyType1" :
                Instantiate(EnemyType1, pos, transform.rotation);
                break;
            case "EnemyType2" :
                Instantiate(EnemyType2, pos, transform.rotation);
                break;
            case "EnemyType3" :
                Instantiate(EnemyType3, pos, transform.rotation);
                break;
            case "EnemyType4" :
                Instantiate(EnemyType4, pos, transform.rotation);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        increaseMovement(4,2);
        increaseMovement(7,3);
        

    }

    private void FixedUpdate()
    {
        
    }


    void increaseMovement(int MoveSpeed, int conditon)
    {
        
        if (deathCount == conditon)
        {
            if (Enemy.moveSpeed < 0)
            {
                Enemy.moveSpeed = -MoveSpeed; 
            }
            else
            {
                Enemy.moveSpeed = MoveSpeed; 
            }
        }
    }

    IEnumerator Fire()
    {
        while (deathCount !=4)
        {
            randomInt = Random.Range(0, b.Length);

            while (!b[randomInt] &&  deathCount !=4)
            {
                randomInt = Random.Range(0, b.Length);
            }
            b[randomInt].Fire();
            yield return new WaitForSeconds(2);
        }
    }
}
