using UnityEngine;

public class DoggoMovement : MonoBehaviour
{

    public float walkSpeed;
    private Animator animator;
    private bool facingRight;
    private float xAxis;
    private float yAxis;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInputs();

        Move();
    }

    private void GetMovementInputs()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        // this is for movement
        transform.position += xAxis * walkSpeed * Vector3.right;
        transform.position += yAxis * walkSpeed * Vector3.up;

        _rb.MovePosition(_rb.position + new Vector2(xAxis, yAxis) * walkSpeed * Time.fixedDeltaTime);

        // this is for animation
        animator.SetFloat("walkingSpeed", Mathf.Abs(xAxis) + Mathf.Abs(yAxis));

        if (xAxis > 0 && facingRight)
        {
            Flip();
        }
        else if (xAxis < 0 && !facingRight)
        {
            Flip();
        }
    }

    // controls the scale of sprite and flips it
    private void Flip()
    {
        facingRight = !facingRight;

        // save the current state of the localScale
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
