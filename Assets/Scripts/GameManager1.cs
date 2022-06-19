using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager1 : MonoBehaviour
{
    public GameObject Guy;
    public GameObject doggo;

    public GameObject AfterPanel;

    public StatusBarScript healthBar;
    public StatusBarScript hungerBar;
    public StatusBarScript waterBar;

    private float startTime;

    private bool hungerImproving = false;
    private bool waterImproving = false;

    private int sceneProgress = 0;

    private bool doggoDelievery = false;

    private Animator guyAnimator;
    private Animator dogAnimator;

    private void Start()
    {
        guyAnimator = Guy.GetComponent<Animator>();
        dogAnimator = doggo.GetComponent<Animator>();

        healthBar.SetHealth(19);
        hungerBar.SetHealth(8);
        waterBar.SetHealth(5);

    }

    private void Awake()
    {
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("DogBark");
        }

        if (sceneProgress == 0 && doggoDelievery)
        {
            sceneProgress = 1;
            doggoDelievery = false;
            waterImproving = true;
            waterGiven();

            // reset doggo position
            doggo.transform.position = new Vector3(-6.14f, -3.06f, doggo.transform.position.z);

            dogAnimator.SetBool("hasWater", true);
        }


        if (sceneProgress == 1 && doggoDelievery)
        {
            doggoDelievery = false;
            hungerImproving = true;
            foodGiven();

            dogAnimator.SetBool("hasFood", true);

            doggo.transform.position = new Vector3(-1.96f, -1.72f, doggo.transform.position.z);

            StartCoroutine(GuyEatFood());


        }

        if (waterImproving)
        {
            waterBar.SetHealth((int)Mathf.Floor(Mathf.Lerp(5, 20, (Time.time - startTime)/5)));

        }

        if (hungerImproving)
        {
            hungerBar.SetHealth((int)Mathf.Floor(Mathf.Lerp(8, 17, (Time.time - startTime) / 5)));
        }


        if (sceneProgress == 2 && hungerBar.slider.value == 17)
        {

            doggo.SetActive(false);

            guyAnimator.SetBool("petDog", true); // put the guy petting dog scene

            Vector3 tempScale = Guy.transform.localScale;
            tempScale.x *= -1;
            Guy.transform.localScale = tempScale;

            sceneProgress = 3;

            // move the dude
            Guy.transform.position = new Vector3(-2.28f, -1.68f, Guy.transform.position.z);

            StartCoroutine(AfterPanelActive());
        }


    }

    public void setDoggoDelivery()
    {
        doggoDelievery = true;
    }

    public void waterGiven()
    {
        FindObjectOfType<AudioManager>().Play("drinkWater");
        guyAnimator.SetBool("hasWater", true);

    }

    public void foodGiven()
    {
        FindObjectOfType<AudioManager>().Play("eatFood");
        guyAnimator.SetBool("hasFood", true);

    }

    private IEnumerator AfterPanelActive()
    {
        yield return new WaitForSeconds(3); // Wait a couple seconds
        AfterPanel.SetActive(true);

        yield return null;
    }


    private IEnumerator GuyEatFood()
    {
        yield return new WaitForSeconds(3); // Wait a couple seconds
        sceneProgress = 2;

        yield return null;
    }

    
}
