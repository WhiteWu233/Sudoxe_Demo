using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpHeight = 10;
    public float gravity = 9.81f;
    public float airControl = 10;

    private CharacterController controller;
    private Vector3 input, moveDirection;

    // Audio components
    public AudioClip runSound;
    public AudioClip jumpSound;
    private AudioSource audioSource;
    private bool isPlayingRunSound = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false; // Jump sound should not loop
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        input = transform.right * moveHorizontal;
        input *= moveSpeed;

        // Check if the character is grounded
        if (controller.isGrounded)
        {
            moveDirection = input;

            // Jump logic
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);

                // Play jump sound effect
                audioSource.PlayOneShot(jumpSound, 0.5f);
            }
            else
            {
                moveDirection.y = 0f;
            }

            // Running sound logic
            if (input.magnitude > 0.1f)
            {
                // If moving and the running sound is not playing
                if (!isPlayingRunSound)
                {
                    audioSource.clip = runSound;
                    audioSource.loop = true; // Running sound should loop
                    audioSource.Play();
                    isPlayingRunSound = true;
                }
            }
            else
            {
                // Stop running sound if not moving
                if (isPlayingRunSound)
                {
                    audioSource.Stop();
                    isPlayingRunSound = false;
                }
            }
        }
        else
        {
            moveDirection.x = Mathf.Lerp(moveDirection.x, input.x, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        if (input.magnitude > 0.1f)
        {
            float cameraYawRotation = Camera.main.transform.eulerAngles.y;
            Quaternion newRotation = Quaternion.Euler(0, cameraYawRotation, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 10);
        }
    }
}
