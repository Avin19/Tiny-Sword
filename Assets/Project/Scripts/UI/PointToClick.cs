
using UnityEngine;

public class PointToClick : MonoBehaviour
{
    [SerializeField] private float duration = 1f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}