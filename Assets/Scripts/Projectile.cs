using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; 
    public Transform firePoint; 
    public float projectileSpeed = 10f; 
    public float projectileLifetime = 5f;

    [Header("Shooting Cooldown")]
    public float fireCooldown = 0.5f;
    private float nextFireTime = 0f;

    private bool facingRight = true;

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
            facingRight = true;
        else if (move < 0)
            facingRight = false;
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        Vector3 direction = facingRight ? Vector3.right : Vector3.left;
        rb.velocity = direction * projectileSpeed;

        projectile.transform.forward = direction;

        Destroy(projectile, projectileLifetime);
    }
}