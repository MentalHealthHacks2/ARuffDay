using UnityEngine;

public class RunDoggo : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D body;
    public AudioSource doorOpen;

    public float walkSpeed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        Flip();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        animator.SetFloat("walkingSpeed", walkSpeed);
        body.MovePosition(body.position + (Vector2.right) * walkSpeed * Time.deltaTime);
    }

    // controls the scale of sprite and flips it
    private void Flip()
    {   
        // save the current state of the localScale
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if(collision.gameObject.tag == "door") doorOpen.Play();
    }
}
