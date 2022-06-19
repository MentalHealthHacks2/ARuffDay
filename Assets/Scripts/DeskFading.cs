using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskFading : MonoBehaviour
{
    private float startTime;

    private void Awake()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Mathf.Lerp(0.1562f, 0, (Time.time - startTime) / 20), Mathf.Lerp(0.1562f, 0, (Time.time - startTime) / 20), 0f);
    }
}
