using UnityEngine;
using UnityEngine.EventSystems; 

// Classe responsável por gerenciar o comportamento de um item que pode ser quebrado pelo jogador.
public class ItemQuebravel : MonoBehaviour
{
    [Header("Configurações do Item")]
   
    public string nomeItem;
    public int vidaMaxima;
    public Sprite iconeGrande; // Ícone que será exibido na UI (interface)
    
    private Transform player;
    private bool esperandoJogador = false; // Flag para controlar se o clique já foi feito

    public GameObject itemDropPrefab;
    public int quantidadeVidaDrop;

    public int valorDrop;
    public int minDrop;
    public int maxDrop;

    private PlayerStamina stamina;

    void Start()
    {
        // Busca o objeto do jogador pela Tag "Player" no início do jogo.
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            stamina = playerObj.GetComponent<PlayerStamina>();
        }
    }

    void Update()
    {
        // Só executa o cálculo de distância se o jogador tiver clicado no item previamente.
        if (esperandoJogador && player != null)
        {
            float distancia = Vector3.Distance(transform.position, player.position);

            // Verifica se o jogador está a menos de 3 unidades de distância.
            if (distancia <= 3.0f)
            {
                // Chama a instância do UIManager (Singleton) para abrir a interface de quebra.
                // Passa "this" para que a UI saiba qual item está sendo manipulado.
                UIManager.instance.AbrirPainelQuebrar(this);
                
                // Reseta a flag para parar de checar a distância no Update.
                esperandoJogador = false;
            }
        }
    }

    // Método nativo da Unity chamado quando o objeto recebe um clique de mouse (ou toque).
    private void OnMouseDown()
{
    if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) 
    {
        return; 
    }

    if (stamina == null)
    {
        Debug.LogWarning("PlayerStamina nao encontrado no ItemQuebravel.");
        return;
    }

    if (!stamina.TryUseStamina(1))
    {
        Debug.Log("Sem stamina para interagir com o item.");
        return;
    }

    esperandoJogador = true;
}

    public void DropItem()
    {
        if(itemDropPrefab != null)
        {
            //posição que vai dropar o item
            Vector3 offset = new Vector3(
                Random.Range(0.8f, 1.5f),
                0,
                Random.Range(0.8f, 1.5f)
            );

            //drop do item
            GameObject drop = Instantiate(
                itemDropPrefab,
                transform.position + offset,
                Quaternion.identity
            );

            Rigidbody rb = drop.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 forca = new Vector3(
                    Random.Range(-1f, 1f),
                    Random.Range(2f, 4f), // altura do pulo
                    Random.Range(-1f, 1f)
                );

                rb.AddForce(forca, ForceMode.Impulse);
            }

            ItemDrop itemDrop = drop.GetComponent<ItemDrop>();

            if (itemDrop != null)
            {
                itemDrop.valor = valorDrop;
            }
        }
    }
}
