using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    Automatic,
    DMR
}

public class Gun : MonoBehaviour
{
    [SerializeField] protected GunType gunType = GunType.Automatic;
    [SerializeField] protected float fireRate = 1f;
    [SerializeField] protected float bulletTime = 10f;
    [SerializeField] protected float bulletSpeed = 5f; 
    [SerializeField] protected GameObject bulletPrefab = null;
    [SerializeField] protected Transform gunPoint;
    Transform gunTip;
    float shootCooldown = 0f;
    float shootTimer = 0f;
    bool readyToShoot = true;

    private void Awake()
    {
        gunTip = transform.GetChild(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 1f / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (!readyToShoot)
        {
            shootTimer -= Time.deltaTime;
            if(shootTimer < 0f)
            {
                readyToShoot = true;
            }
        }

        if (gunPoint)
        {
            transform.position = gunPoint.position;
        }
    }

    public void SprayShoot()
    {
        if (!readyToShoot)
            return;

        if (gunType != GunType.Automatic)
            return;

        Shoot();

        ShootReset();
    }

    public void TapShoot()
    {
        if (!readyToShoot)
            return;

        if (gunType != GunType.DMR)
            return;

        Shoot();

        ShootReset();
    }
    
    void ShootReset()
    {
        shootTimer = shootCooldown;
        readyToShoot = false;
    }

    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, null).GetComponent<Bullet>();
        bullet.ShootBullet(gunTip.position, transform.right, bulletSpeed, bulletTime);
    }
}
