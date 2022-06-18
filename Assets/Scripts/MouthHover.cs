using UnityEngine;

public class MouthHover : MonoBehaviour
{
    private CircleCollider2D _collider;
    public GameObject GameManager;


    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "grabbable")
        {
            FindObjectOfType<GameManager>().setTouchingCurtain(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "grabbable")
        {
            FindObjectOfType<GameManager>().setTouchingCurtain(false);
        }
    }
}
