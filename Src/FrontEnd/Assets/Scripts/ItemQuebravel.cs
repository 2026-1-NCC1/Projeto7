using UnityEngine;
using UnityEngine.EventSystems; 

// Classe responsável por gerenciar o comportamento de um item que pode ser quebrado pelo jogador.
public class ItemQuebravel : MonoBehaviour
{
    [Header("Configurações do Item")]
    public string nomeItem;
    public int vidaMaxima = 10;
    public Sprite iconeGrande; // Ícone que será exibido na UI (interface)
    
    private Transform player;
    private bool esperandoJogador = false; // Flag para controlar se o clique já foi feito

    void Start()
    {
        // Busca o objeto do jogador pela Tag "Player" no início do jogo.
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
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
        // Verifica se o clique foi sobre um elemento de UI (botões, painéis etc.).
        // Isso impede que o jogador clique no item "através" de um menu aberto.
        if (EventSystem.current.IsPointerOverGameObject()) 
        {
            return; 
        }

        // Ativa o estado de espera para que o Update comece a monitorar a distância.
        esperandoJogador = true;
    }
}
