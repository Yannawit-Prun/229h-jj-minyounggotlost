using UnityEngine;

public class MoveLeftGround : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destroy object when it goes off-screen to the left
        if (transform.position.x < -35f)
        {
            Destroy(gameObject);
        }
    }
}
