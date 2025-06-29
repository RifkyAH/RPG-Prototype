using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable taged = collision.gameObject.GetComponent<IDamageable>();
        if (taged != null)
        {
            taged.TakeDamage(20);
        }
    }
}
