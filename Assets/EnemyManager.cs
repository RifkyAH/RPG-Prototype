using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IDamageable
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable taged = collision.gameObject.GetComponent<IDamageable>();
        if (taged != null)
        {
            taged.TakeDamage(20);
        }
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("Musuh terkena Damage" + amount);
    }
}
