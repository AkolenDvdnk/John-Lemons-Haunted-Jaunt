using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    private float horizontal, vertical;

    private bool isWalking;

    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;

    private Animator animator;
    private Rigidbody rb;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        CheckInput();
        SetMovement();
        UpdateAnimation();
        RotateCharacter();
        UpdateAudio();
    }
    private void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * animator.deltaPosition.magnitude);
    }
    private void CheckInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    private void SetMovement()
    {
        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        isWalking = hasHorizontalInput || hasVerticalInput;
    }
    private void RotateCharacter()
    {
        Vector3 desiredRotation = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredRotation);
        rb.MoveRotation(rotation);
    }
    private void UpdateAudio()
    {
        if (isWalking)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop(); 
        }
    }
    private void UpdateAnimation()
    {
        animator.SetBool("isWalking", isWalking);
    }
}
