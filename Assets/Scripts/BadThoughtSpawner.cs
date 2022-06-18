using UnityEngine;

public class BadThoughtSpawner : MonoBehaviour
{
    public Rigidbody2D thought;
    private void OnCollisionEnter2D (Collision2D collision) {
        Destroy(this.gameObject);
    }

    void Update() {
        thought.MovePosition(thought.position + (Vector2.right) * Time.deltaTime);
    }
}
