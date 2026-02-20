using UnityEngine;

public class PipeTrigger : MonoBehaviour

{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;
            ScoreManager.instance.AddPoint();
        }
    }
}