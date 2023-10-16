using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int damage = 10; 

    private static EnemyController instance; 

    private void Awake()
    {
        instance = this; 
    }

    public static EnemyController GetInstance()
    {
        return instance; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            HealthBarController PlayerHealt = HealthBarController.instance;
            PlayerHealt.UpdateHealth(-damage);
        }
    }
}
