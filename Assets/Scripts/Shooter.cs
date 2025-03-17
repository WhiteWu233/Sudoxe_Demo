using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Customizable projectile prefab
    public Transform firePoint; // The point from which projectiles will be fired
    public float fireRate = 0.1f; // Time between shots
    public float projectileForce = 20f; // Force applied to projectile

    private bool isFiring = false;
    private Coroutine firingCoroutine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartFiring();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopFiring();
        }
    }

    private void StartFiring()
    {
        if (!isFiring)
        {
            isFiring = true;
            firingCoroutine = StartCoroutine(FireContinuously());
        }
    }

    private void StopFiring()
    {
        if (isFiring)
        {
            isFiring = false;
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuously()
    {
        while (isFiring)
        {
            FireProjectile();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void FireProjectile()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            if (groundPlane.Raycast(ray, out float distance))
            {
                Vector3 targetPoint = ray.GetPoint(distance);
                Vector3 direction = (targetPoint - firePoint.position).normalized;
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(direction * projectileForce, ForceMode.Impulse);
                }
            }
        }
    }
}

