using UnityEngine;
using System.Collections;

public class RunDoggo : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D body;
    public AudioSource doorOpen;
    public AudioSource bark;
    public GameObject neighbourHouse;

    float walkSpeed = 4f;

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
        if(collision.gameObject.tag == "door")  {
            doorOpen.Play();
            StartCoroutine(ShowNeighbourHouse());
        }
    }

    IEnumerator ShowNeighbourHouse() {
        yield return new WaitForSeconds(2);
        neighbourHouse.SetActive(true);
        bark.Play();
        bark.Play();
    }
}
