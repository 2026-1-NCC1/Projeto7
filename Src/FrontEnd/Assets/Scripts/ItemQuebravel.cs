using UnityEngine;
using UnityEngine.EventSystems; 

public class ItemQuebravel : MonoBehaviour
{
    public string nomeItem;
    public int vidaMaxima = 10;
    public Sprite iconeGrande;

    private Transform player;
    private bool esperandoJogador = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (esperandoJogador)
        {
            float distancia = Vector3.Distance(transform.position, player.position);

            if (distancia <= 3.0f)
            {
                UIManager.instance.AbrirPainelQuebrar(this);
                esperandoJogador = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) 
        {
            return; 
        }

        esperandoJogador = true;
    }
}