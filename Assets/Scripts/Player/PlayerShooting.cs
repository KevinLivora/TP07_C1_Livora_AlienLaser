using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Bullet bulletPrefab;

    private PlayerController player;
    private float nextShotTime;

    public event Action Shot;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(data.shootKey) && Time.time >= nextShotTime)
            Shoot();
    }

    private void Shoot()
    {
        nextShotTime = Time.time + data.fireCooldown;

        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.Initialize(Vector2.right * player.FacingSign, data.bulletDamage, data.bulletSpeed, data.bulletLifeTime);

        Shot?.Invoke();
    }
}
