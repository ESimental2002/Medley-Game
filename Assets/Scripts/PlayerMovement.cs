using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float groundSpeed;
    public float jumpSpeed;
    [Range(0f, 1f)]
    public float groundDecay;
    public bool grounded;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public float acceleration;
    private SpriteRenderer spriteRenderer;

    float xInput;
    float yInput;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        CheckInput();

    }

    void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
        MoveWithInput();

    }



    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            body.linearVelocity = new Vector2(xInput * groundSpeed, body.linearVelocity.y);

            spriteRenderer.flipX = (xInput < 0);
        }

        if (Mathf.Abs(yInput) > 0 && grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, yInput * jumpSpeed);
        }
    }



    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length> 0;
    //Checks every frame if something is in the collider
    }

    void ApplyFriction()
    {
        if (grounded && xInput == 0 && yInput == 0)
        {
            body.linearVelocity *= groundDecay;
        }
    }



}
