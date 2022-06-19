using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyEatingScript : MonoBehaviour
{

    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager1>().setDoggoDelivery();
        }
    }
}
