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

    [Header("Loja")]
    private Loja lojaAtual;
    private bool indoParaLoja;

    [Header("workbench")]
    private Workbench workbenchAtual;
    private bool indoParaWorkbench;

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
        if (indoParaLoja)
        {
            if (!agent.pathPending &&
                agent.remainingDistance <= agent.stoppingDistance)
            {
                indoParaLoja = false;

                if (lojaAtual != null)
                {
                    lojaAtual.Abrir();
                }
            }
        }

        if (indoParaWorkbench)
        {
            if (!agent.pathPending &&
                agent.remainingDistance <= agent.stoppingDistance)
            {
                indoParaWorkbench = false;

                if (workbenchAtual != null)
                {
                    workbenchAtual.Abrir();
                }
            }
        }
     
        if (currentMarker != null &&
            !agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            Destroy(currentMarker);
            currentMarker = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current != null &&
                EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Ray lojaRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(lojaRay, out RaycastHit lojaHit))
            {
                if (lojaHit.collider.GetComponentInParent<Loja>() != null ||
                    lojaHit.collider.GetComponentInParent<Workbench>() != null)
                {
                    return;
                }
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

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                indoParaLoja = false;
                lojaAtual = null;

                agent.SetDestination(hit.point);

                if (currentMarker != null)
                {
                    Destroy(currentMarker);
                }

                if (clickMarkerPrefab != null)
                {
                    Vector3 markerPos = hit.point + Vector3.up * 0.01f;

                    currentMarker = Instantiate(
                        clickMarkerPrefab,
                        markerPos,
                        Quaternion.identity
                    );
                }
            }
        }
    }
    public void IrParaLoja(Loja loja)
    {
        if (loja == null || loja.pontoDeInteracao == null)
            return;

        lojaAtual = loja;
        indoParaLoja = true;

        agent.SetDestination(loja.pontoDeInteracao.position);
    }
    public void IrParaWorkbench(Workbench workbench)
    {
        if (workbench == null || workbench.pontoDeInteracao == null)
            return;

        workbenchAtual = workbench;
        indoParaWorkbench = true;

        agent.SetDestination(workbench.pontoDeInteracao.position);
    }
}
