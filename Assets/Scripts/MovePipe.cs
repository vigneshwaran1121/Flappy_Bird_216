using UnityEngine;

public class MovePipe : MonoBehaviour

{
    [SerializeField] private float speed = 3f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // destroy when off screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}