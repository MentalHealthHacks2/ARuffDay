using UnityEngine;

public class Dream_DoggoMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D body;

    public float walkSpeed = 1f;
    float jumpForce = 2f;
    private bool facingRight;
    private float xAxis;
    private float yAxis;
    private float groundY;
    private Vector2 screenBounds;
    private float width;
    private float height;


    // Start is called before the first frame update
    void Start()
    {
        facingRight = false;
        groundY = Input.GetAxis("Vertical") - 1;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));    
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInputs();

        Move();
    }

    // Update is called once per frame
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, groundY, screenBounds.y);
        viewPos.y = Mathf.Clamp(viewPos.y, groundY, screenBounds.y);
        transform.position = viewPos;
    }

    private void GetMovementInputs()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
    }

    public void OnLanding() {
        animator.SetBool("isJumping", false);   
    }

    private void Move()
    {
        // this is for movement
        transform.position += xAxis * walkSpeed * Vector3.right;
        transform.position += yAxis * jumpForce * Vector3.up;

        body.MovePosition(body.position + new Vector2(xAxis * walkSpeed, yAxis * jumpForce) * Time.fixedDeltaTime);

        if (xAxis > 0 && !facingRight)
        {
            Flip();
        }
        else if (xAxis < 0 && facingRight)
        {
            Flip();
        }



        if (transform.position.y > groundY) {
            animator.SetBool("isJumping", true);
        } else {
            animator.SetBool("isJumping", false);
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
