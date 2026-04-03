using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent agent;
    public LayerMask groundLayer;

    public GameObject clickMarkerPrefab;
    private GameObject currentMarker;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (groundLayer == 0)
            groundLayer = LayerMask.GetMask("Default");
    }

    void Update()
    {

        if (currentMarker != null && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Destroy(currentMarker);
            currentMarker = null;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                agent.SetDestination(hit.point);

                if (currentMarker != null)
                {
                    Destroy(currentMarker);
                }

                if (clickMarkerPrefab != null)
                {
                    Vector3 markerPos = hit.point + Vector3.up * 0.01f; // evita z-fighting
                    currentMarker = Instantiate(clickMarkerPrefab, markerPos, Quaternion.identity);
                }
            }
        }
    }
}