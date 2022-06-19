using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadThoughtsSpawner : MonoBehaviour
{
    public GameObject badThought;
    public GameObject doggo;
    public Rigidbody2D phoneDoggo;
    public GameObject obj;
    [SerializeField] Text timer;
    public GameObject speechBubble;
    public bool collidedWithHuman = false;

    public StatusBarScript healthBar;
    public StatusBarScript hungerBar;
    public StatusBarScript waterBar;

    int time = 10;
    private Vector3 position;
    private float walkSpeed = 1f;
    private float yAxis;
    private float xAxis;


    private void Start()
    {
        healthBar.SetHealth(5);
        hungerBar.SetHealth(7);
        waterBar.SetHealth(6);
    }

    public void StartGame()
    {
        timer.gameObject.SetActive(true);
        InvokeRepeating("SpawnBadThoughts", 0f, 2f);
        InvokeRepeating("Countdown", 0f, 1f);
        position = obj.transform.localPosition;
        phoneDoggo.gameObject.SetActive(false);
        yAxis = Input.GetAxis("Vertical");
        xAxis = Input.GetAxis("Horizontal");

        
    }

    void SpawnBadThoughts() {
        GameObject thought = Instantiate(badThought, position, Quaternion.identity);
        thought.gameObject.tag = "Respawn";
    }

    void Countdown() {
        time--;
        timer.text = time.ToString() + "s";
    }

    void Update() {
        if (time == 0) {
            timer.gameObject.SetActive(false);
            CancelInvoke();
            doggo.gameObject.SetActive(false);

            var clones = GameObject.FindGameObjectsWithTag ("Respawn");
            foreach (var clone in clones){
                Destroy(clone);
            }

            phoneDoggo.gameObject.SetActive(true);
            phoneDoggo.MovePosition(phoneDoggo.position - new Vector2(xAxis, yAxis) * walkSpeed * Time.fixedDeltaTime);
        }

        if (collidedWithHuman == true) {
            speechBubble.SetActive(true);
            GoToNextScene();
        }
    }

    public void GoToNextScene()
    {
        StartCoroutine(GoNextScene());
    }

    private IEnumerator GoNextScene()
    {
        yield return new WaitForSeconds(2); // Wait a couple seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield return null;
    }
}
