using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InfiniteGround : MonoBehaviour
{
    public float speed = 3f;
    public float resetPosition = -15f; // x position to reset from
    public float startPosition = 15f;  // x position to reset to

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= resetPosition)
        {
            Vector2 newPos = new Vector2(startPosition, transform.position.y);
            transform.position = newPos;
        }
    }
}
