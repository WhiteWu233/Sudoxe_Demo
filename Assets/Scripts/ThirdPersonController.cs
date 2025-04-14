using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpHeight = 10f;
    public float gravity = 9.81f;
    public float airControl = 10f;

    private CharacterController controller;
    private Vector3 input, moveDirection;
    private Animator animator;

    // Audio
    public AudioClip runSound;
    public AudioClip jumpSound;
    private AudioSource audioSource;
    private bool isPlayingRunSound = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        input = transform.right * moveHorizontal * moveSpeed;

        if (controller.isGrounded)
        {
            moveDirection = input;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
                audioSource.PlayOneShot(jumpSound, 0.5f);
            }

            if (input.magnitude > 0.1f)
            {
                animator.SetBool("IsWalking", true);

                if (!isPlayingRunSound)
                {
                    audioSource.clip = runSound;
                    audioSource.loop = true;
                    audioSource.Play();
                    isPlayingRunSound = true;
                }
            }
            else
            {
                animator.SetBool("IsWalking", false);

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
    }
}