using System;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public int valor = 0;

    public float velocidadeRotacao = 100f;
    public float velocidadeAtracao = 5f;
    public float distanciaAtracao = 3f;
    public float delayAtracao = 0.5f; // tempo antes de começar a puxar

    private Transform player;
    private Rigidbody rb;
    private bool podeAtrair = false;

    void Start()
    {
        valor = UnityEngine.Random.Range(1, 3);
        rb = GetComponent<Rigidbody>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        // ativa atração depois de um tempo
        Invoke(nameof(AtivarAtracao), delayAtracao);
    }

    void AtivarAtracao()
    {
        podeAtrair = true;

        // desliga física pra evitar atravessar chão
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        // rotação
        transform.Rotate(0, velocidadeRotacao * Time.deltaTime, 0);

        if (!podeAtrair || player == null) return;

        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= distanciaAtracao)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                velocidadeAtracao * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Coletar();
        }
    }

    // função para coletar o dinheiro que dropa dos minérios 
    void Coletar()
    {
        UIManager.instance.AdicionarDinheiro(valor);
        Destroy(gameObject);
    }
}