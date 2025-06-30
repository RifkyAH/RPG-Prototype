using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class PlayerAttackHandler : MonoBehaviour
{
    [Inject] private PlayerStateController _player;
    [SerializeField] private Collider2D _attackHitbox;
    [SerializeField] private GameObject _arrowObject;
    [SerializeField] private Transform _spawnerArrow;
    [SerializeField] private float arrowForce = 10f;
    public ObjectPool<GameObject> arrowPool;
    void Awake()
    {
        _attackHitbox.enabled = false;
    }
    void Start()
    {
        arrowPool = new ObjectPool<GameObject>(
            createFunc: () =>Instantiate(_arrowObject),
            actionOnGet: arrow =>arrow.SetActive(true),
            actionOnRelease: arrow => arrow.SetActive(false),
            actionOnDestroy: Destroy,
            defaultCapacity: 10,
            maxSize: 30
        );
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
    public void EndAttackAnimation()
    {
        _player.GetModel.MeleeAttackPressed = false;
    }
    public void SpawnArrow()
    {
        GameObject arrow = arrowPool.Get();
        arrow.transform.position = _spawnerArrow.position;
        arrow.transform.rotation = Quaternion.identity;

        Projectile projectile = arrow.GetComponent<Projectile>();
        projectile.Init(this);
        
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        float direction = Mathf.Sign(transform.localScale.x);
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(direction * arrowForce, 0);

        Vector2 arrowScale = arrow.transform.localScale;
        arrowScale.x = Mathf.Abs(arrowScale.x) * direction;
        arrow.transform.localScale = arrowScale;
    }
    public void EndBowAnimation()
    {
        _player.GetModel.BowAttackPressed = false;
    }
}
