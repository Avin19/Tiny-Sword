
using UnityEngine;

public class PointToClick : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AnimationCurve scaleCurve;

    private float timer;
    private float freqTimer;
    private Vector3 initialScale;
    void Start()
    {
        initialScale = transform.localScale;
    }
    void Update()
    {
        timer += Time.deltaTime;
        freqTimer += Time.deltaTime;

        if (freqTimer >= 1f)
        {
            freqTimer = 0f;
        }

        float scaleMultipler = scaleCurve.Evaluate(freqTimer);
        transform.localScale = initialScale * scaleMultipler;

        if (timer >= duration * 0.9f)
        {
            float fadeProgress = (timer - duration * 0.9f) / (duration * 0.1f);
            spriteRenderer.color = new Color(1, 1, 1, 1 - fadeProgress);
        }

        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}