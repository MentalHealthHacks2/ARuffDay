using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadThoughtsSpawner : MonoBehaviour
{
    public GameObject badThought;
    public GameObject doggo;
    public Rigidbody2D phoneDoggo;
    public GameObject obj;
    [SerializeField] Text timer;

    int time = 10;
    private Vector3 position;
    private float walkingSpeed = 1f;

    public void StartGame()
    {
        //StartCoroutine(SpawnBadThoughts());
        InvokeRepeating("SpawnBadThoughts", 0f, 2f);
        InvokeRepeating("Countdown", 0f, 1f);
        position = obj.transform.localPosition;
    }

    void SpawnBadThoughts() {
        //yield return new WaitForSeconds(1);
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

            //phoneDoggo.gameObject.SetActive(true);
            //phoneDoggo.MovePosition(phoneDoggo.position - new Vector2(Vector2.right * walkSpeed, yAxis) * Time.fixedDeltaTime);
        }
    }
}
