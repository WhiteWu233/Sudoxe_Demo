using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint;
    public float moveSpeed = 5f;
    public float projectileSpeed = 10f;

    private Vector3 moveDirection = Vector3.right;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;

        if (movement != Vector3.zero)
        {
            transform.position += movement * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(movement); // facing the move direction
            moveDirection = movement;  // change the shooting direction
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
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(moveDirection));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = moveDirection * projectileSpeed;
    }
}
