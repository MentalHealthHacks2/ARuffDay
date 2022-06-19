using UnityEngine;

public class Dream_DogController : MonoBehaviour
{
    public BadThoughtsSpawner gameController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "human")
        {
            gameController.collidedWithHuman = true;
        }
    }

}
