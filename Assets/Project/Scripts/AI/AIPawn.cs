using UnityEngine;

public class AIPawn : MonoBehaviour
{

    private Vector3? m_Destination;
    public Vector3? Destination => m_Destination;
    [SerializeField] private float m_Speed = 5f;

    private void Start()
    {
        SetDestination(new Vector3(5f, -5f, 0f));
    }

    private void Update()
    {
        if (m_Destination.HasValue)
        {
            var dir = m_Destination.Value - transform.position;
            transform.position += dir.normalized * m_Speed * Time.deltaTime;

            var distanceToDestination = Vector3.Distance(transform.position, m_Destination.Value);

            if (distanceToDestination < 0.1f)
            {
                m_Destination = null;
            }
        }

    }
    public void SetDestination(Vector3 destination)
    {
        m_Destination = destination;
    }

}