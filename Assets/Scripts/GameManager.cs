using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject curtainEdge;
    public GameObject roomLight;
    public GameObject Guy;


    private bool isTouchingCurtain = false;
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


        }

        portionMoved = Mathf.Abs(curtainEdge.transform.position.x - (-1)) / 6.4f;
        FindObjectOfType<CurtainDraw>().updateCurtain(portionMoved);
        Debug.Log(portionMoved * 0.7f);
        myLight.intensity = (1- portionMoved) * 0.7f;

        if (1 - portionMoved > 0.9)
        {
            guyAnimator.SetBool("wake", true);
        }
    }


}
