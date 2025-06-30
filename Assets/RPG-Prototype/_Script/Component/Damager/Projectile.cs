using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Tooltip("The damage dealt by the projectile.")]
    [SerializeField] protected int m_Damage = 10;
    [Tooltip("The life time of the projectile before it is returned to the pool.")]
    [SerializeField] protected int m_LifeTime = 5;
    [SerializeField] private PlayerAttackHandler _handler;

    protected float m_StartTime;
    private void OnEnable()
    {
        m_StartTime = Time.time;
    }
    void Update()
    {
        if (m_StartTime + m_LifeTime < Time.time) {
            DestroyProjectile();
        }
    }
    public void DestroyProjectile()
    {
        _handler.arrowPool.Release(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable tagged = collision.gameObject.GetComponent<IDamageable>();
        if (tagged != null)
        {
            tagged.TakeDamage(m_Damage);
        }
        DestroyProjectile();
    }
}
