using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float speed = 10.0f;
    float rotationSpeed = 100.0f;
    float currentSpeed = 0.0f;
    float maxSpeed = 10f;
    float runSpeed = 10f;
    float walkSpeed = 1f;
    float minSpeed = -1f;
    [HideInInspector]
    public Animator animator;
    public bool isJumping { get; set; }
    public bool isClimbing { get; set; }
    public bool isFalling { get; set; }
    public bool isSoaring { get; set; }
    public float JumpHeight = 1f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        animator.SetFloat("Rotation", Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed += translation;
            maxSpeed = runSpeed;
            if (currentSpeed > maxSpeed)
                currentSpeed = maxSpeed;
            if (currentSpeed < minSpeed)
                currentSpeed = minSpeed;
        }
        else
        {
            maxSpeed = walkSpeed;
            if (currentSpeed > maxSpeed)
                currentSpeed -= Time.deltaTime * speed;
            else if (currentSpeed < minSpeed)
                currentSpeed = minSpeed;
            else
                currentSpeed += translation;
        }

        //if (Mathf.Abs(currentSpeed) < .01)
        //    currentSpeed = 0;


        if (!isClimbing && !isSoaring)
        {
            animator.SetFloat("Speed", currentSpeed);

            if (Mathf.Abs(translation) > Mathf.Epsilon)
            {
                animator.SetBool("IsWalking", true);
                transform.Rotate(0, rotation, 0);
            }
            else
            {
                animator.SetBool("IsWalking", false);
                if(currentSpeed > 0)
                {
                    currentSpeed -= Time.deltaTime * speed; 
                }
                else
                {
                    currentSpeed += Time.deltaTime * speed;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && currentSpeed >= 0 && !isJumping)
            {
                animator.SetTrigger("Jumped");
            }
        }
        else if (isClimbing)
        {
            currentSpeed = 0;
            animator.SetFloat("Translation", Input.GetAxis("Vertical"));

            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jumped");
            }
        }
    }

    public bool IsGrounded { get; set; }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            IsGrounded = true;
            animator.SetBool("IsGrounded", true);
            isFalling = false;
            animator.SetBool("IsFalling", false);
        }
    }

    //consider when character is jumping, it will exit collision.
    //I should maybe do raycasts instead
    void OnCollisionExit(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            IsGrounded = false;//is teh bool needed?
            animator.SetBool("IsGrounded", false);

            if(!isJumping)
            {
                isFalling = true;//probably only need either isfalling or isgrounded? no because when jump up to hit is not grounded but not falling
                animator.SetBool("IsFalling", true);
                //this doesn't work for when you jump off a cliff though
            }
        }
    }
}
