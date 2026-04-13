using UnityEngine;
using UnityEngine.AI; // Necessário para usar o NavMeshAgent
using UnityEngine.EventSystems; // Necessário para detectar cliques na UI

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent agent;
    
    [Tooltip("Defina qual camada é considerada 'chão' para o clique.")]
    public LayerMask groundLayer;

    [Header("Visual")]
    public GameObject clickMarkerPrefab; // Prefab do efeito visual (ex: uma seta ou círculo)
    private GameObject currentMarker;    // Referência para o marcador ativo na cena

    void Start()
    {
        // Pega o componente de navegação acoplado ao personagem
        agent = GetComponent<NavMeshAgent>();

        // Se nenhuma Layer for definida no Inspector, assume a camada "Default"
        if (groundLayer == 0)
            groundLayer = LayerMask.GetMask("Default");
    }

    void Update()
    {
        // 1. Lógica para remover o marcador quando chegar ao destino
        // pathPending: verifica se o caminho ainda está sendo calculado
        // remainingDistance: distância que falta para chegar
        // stoppingDistance: a distância mínima definida para o agente parar
        if (currentMarker != null && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Destroy(currentMarker);
            currentMarker = null;
        }

        // 2. Detecta o clique do botão esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Bloqueia a movimentação se o usuário clicar em um botão ou menu da interface (UI)
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return; 
            }

            // Cria um raio que vai da câmera até a posição do mouse na tela
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Lança o raio. Se ele atingir algo na camada 'groundLayer'...
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                // Move o NavMeshAgent para o ponto onde o raio atingiu o chão
                agent.SetDestination(hit.point);

                // Gerencia o marcador visual
                if (currentMarker != null)
                {
                    Destroy(currentMarker);
                }

                if (clickMarkerPrefab != null)
                {
                    // Instancia o marcador um pouco acima do chão (Vector3.up * 0.01f) para evitar "Z-fighting"
                    Vector3 markerPos = hit.point + Vector3.up * 0.01f;
                    currentMarker = Instantiate(clickMarkerPrefab, markerPos, Quaternion.identity);
                }
            }
        }
    }
}
