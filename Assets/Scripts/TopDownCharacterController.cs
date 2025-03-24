using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint; 
    public float moveSpeed = 5f;
    public float projectileSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
        FaceMouse();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;

        if (movement != Vector3.zero)
        {
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }

    void FaceMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 lookDir = (hitPoint - transform.position).normalized;
            lookDir.y = 0f;

            transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 shootDir = (hitPoint - firePoint.position);
            shootDir.y = 0f; 
            shootDir = shootDir.normalized;

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(shootDir));
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.drag = 0f; 
            rb.velocity = shootDir * projectileSpeed;

            Destroy(projectile, 2f);
        }
    }
}
