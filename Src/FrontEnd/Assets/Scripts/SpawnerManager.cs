using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [Header("Configurações do Spawner")]
    public GameObject[] itensParaGerar; // Array de prefabs (pedras, itens, inimigos)
    public int quantidadeTotal = 5;     // Quantos itens serão criados no início
    
    void Start()
    {
        // Inicia a geração assim que o jogo começa
        GerarItens();    
    }

    /// <summary>
    /// Gera vários itens no início, garantindo que cada um use um SpawnPoint diferente.
    /// </summary>
    void GerarItens()
    {
        // Busca todos os objetos na cena que tenham a tag "SpawnPoint"
        GameObject[] pontos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        
        // Converte o array para uma Lista para podermos remover itens facilmente
        List<GameObject> pontosDisponiveis = new List<GameObject>(pontos);

        for (int i = 0; i < quantidadeTotal; i++)
        {
            // Se não houver mais pontos disponíveis, interrompe o loop para evitar erros
            if (pontosDisponiveis.Count == 0) break;

            // Escolhe um índice aleatório da lista de pontos e do array de itens
            int indexPonto = Random.Range(0, pontosDisponiveis.Count);
            int indexItem = Random.Range(0, itensParaGerar.Length);

            // Cria o item na posição do ponto escolhido
            Instantiate(itensParaGerar[indexItem], pontosDisponiveis[indexPonto].transform.position, Quaternion.identity);

            // REMOVE o ponto da lista para que o próximo item do loop não seja criado no mesmo lugar
            pontosDisponiveis.RemoveAt(indexPonto);
        }
    }

    /// <summary>
    /// Método público que pode ser chamado por outros scripts (ex: quando um item quebra)
    /// </summary>
    public void GerarUmNovoItem()
    {
        GameObject[] pontos = GameObject.FindGameObjectsWithTag("SpawnPoint");
    
        // Verifica se existem pontos e itens configurados antes de tentar criar
        if (pontos.Length > 0 && itensParaGerar.Length > 0)
        {
            int indexPonto = Random.Range(0, pontos.Length);
            int indexItem = Random.Range(0, itensParaGerar.Length);

            Instantiate(itensParaGerar[indexItem], pontos[indexPonto].transform.position, Quaternion.identity);
            Debug.Log("Novo item gerado em um ponto aleatório!");
        }
        else
        {
            Debug.LogError("Cuidado: Sem SpawnPoints ou Prefabs configurados no Inspector!");
        }
    }
}
