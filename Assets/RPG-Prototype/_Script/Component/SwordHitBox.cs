using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    [SerializeField] private Collider2D _attackHitbox;
    void Awake()
    {
        _attackHitbox.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable tagged = collision.gameObject.GetComponent<IDamageable>();
        if (tagged != null)
        {
            tagged.TakeDamage(20);
        }
    }
    public void EnableHitbox()
    {
        _attackHitbox.enabled = true;
    }
    public void DisableHitbox()
    {
        _attackHitbox.enabled = false;
    }
}
