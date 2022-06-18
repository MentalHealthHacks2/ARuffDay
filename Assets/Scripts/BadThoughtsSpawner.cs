using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThoughtsSpawner : MonoBehaviour
{
    public GameObject badThought;
    public GameObject obj;
    private Vector3 position;
    // Start is called before the first frame update
    public void StartGame()
    {
        //StartCoroutine(SpawnBadThoughts());
        InvokeRepeating("SpawnBadThoughts", 0f, 2f);
        position = obj.transform.localPosition;
    }

    void SpawnBadThoughts() {
        //yield return new WaitForSeconds(1);
        Instantiate(badThought, position, Quaternion.identity);
    }
}
