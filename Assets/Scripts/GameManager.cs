using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject curtainEdge;
    public GameObject roomLight;
    public GameObject Guy;
    public GameObject doggo;

    public StatusBarScript healthBar;
    public StatusBarScript hungerBar;
    public StatusBarScript waterBar;

    private float startTime;

    private int barkCounter = 0;
    private int sceneProgress = 0;

    private bool healthImproving = false;

    private float portionMoved = 0f;
    
    Light myLight;
    private Animator guyAnimator;

    private void Start()
    {
        myLight = roomLight.GetComponent<Light>();
        guyAnimator = Guy.GetComponent<Animator>();

        healthBar.SetHealth(10);
        hungerBar.SetHealth(8);
        waterBar.SetHealth(5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("DogBark");
            if (sceneProgress == 1)
            {
                barkCounter++;

                if (barkCounter > 5)
                {
                    sceneProgress = 2;
                }
            }
        }

        if (sceneProgress == 2)
        {
            // animate next part with the guy getting up
            doggo.GetComponent<Renderer>().enabled = false; // make the dog invisible
            guyAnimator.SetBool("petDog", true); // put the guy petting dog scene

            // move the dude
            Guy.transform.position = new Vector3(2.61f, -1.55f, Guy.transform.position.z);


            // health bar increase until health bar is full
            healthImproving = true;
            startTime = Time.time;

            sceneProgress = 3;


        }

        if (healthImproving)
        {
            healthBar.SetHealth((int)Mathf.Floor(Mathf.Lerp(10, 19, Time.time - startTime)));
        }


        portionMoved = Mathf.Abs(curtainEdge.transform.position.x - (-1)) / 6f;
        FindObjectOfType<CurtainDraw>().updateCurtain(portionMoved);
        myLight.intensity = (1- portionMoved) * 0.7f;

        if (1 - portionMoved > 0.9)
        {
            guyAnimator.SetBool("wake", true);
            sceneProgress = 1;
        }
    }


}
