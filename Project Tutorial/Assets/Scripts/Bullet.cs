using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifetime;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet(Vector3 _origin, Vector3 _direction, float _speed, float _lifetime)
    {
        lifetime = _lifetime;
        transform.position = _origin;
        rb2d.velocity = _direction * _speed;

        StartCoroutine(LifetimeTimer());
    }

    IEnumerator LifetimeTimer()
    {
        yield return new WaitForSeconds(lifetime);

        DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(LifetimeTimer());

        DestroyBullet();
    }
}
