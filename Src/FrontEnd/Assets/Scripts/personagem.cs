using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent agent;

    [Tooltip("Defina qual camada é considerada 'chão' para o clique.")]
    public LayerMask groundLayer;

    [Header("Stamina")]
    public PlayerStamina stamina;

    [Header("Visual")]
    public GameObject clickMarkerPrefab;
    private GameObject currentMarker;

    void Start()
    {
    agent = GetComponent<NavMeshAgent>();

    if (stamina == null)
        stamina = GetComponent<PlayerStamina>();

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
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (stamina == null)
            {
                Debug.LogWarning("Stamina nao foi encontrada no ClickToMove.");
                return;
            }

            if (!stamina.TryUseStamina(1))
            {
                Debug.Log("Sem stamina. Movimento bloqueado.");
                return;
            }

            Debug.Log("Clique consumiu 1 de stamina.");

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
                    Vector3 markerPos = hit.point + Vector3.up * 0.01f;
                    currentMarker = Instantiate(clickMarkerPrefab, markerPos, Quaternion.identity);
                }
            }
        }
    }
}
