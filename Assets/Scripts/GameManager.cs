using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject curtainEdge;
    public GameObject roomLight;
    public GameObject Guy;


    private float portionMoved = 0f;
    
    Light myLight;
    private Animator guyAnimator;

    private void Start()
    {
        myLight = roomLight.GetComponent<Light>();
        guyAnimator = Guy.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("DogBark");
            Debug.Log("Bark");
        }

        portionMoved = Mathf.Abs(curtainEdge.transform.position.x - (-1)) / 6f;
        FindObjectOfType<CurtainDraw>().updateCurtain(portionMoved);
        myLight.intensity = (1- portionMoved) * 0.7f;

        if (1 - portionMoved > 0.9)
        {
            guyAnimator.SetBool("wake", true);
        }
    }


}
