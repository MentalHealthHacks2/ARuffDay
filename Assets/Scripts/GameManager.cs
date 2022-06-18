using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject doggoMouth;
    public GameObject curtainEdge;
    private bool isTouchingCurtain = false;
    private float portionMoved = 0f;


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && isTouchingCurtain)
        //{
        //    if (doggoMouth.transform.position.x <= -5.4 &&
        //        doggoMouth.transform.position.x >= -1)
        //    {
                
        //    }
        //}

        portionMoved = Mathf.Abs(curtainEdge.transform.position.x - (-1)) / 6.4f;
        FindObjectOfType<CurtainDraw>().updateCurtain(portionMoved);






    }

    public void setTouchingCurtain (bool touchingCurtain)
    {
        isTouchingCurtain = touchingCurtain;
    }
}
