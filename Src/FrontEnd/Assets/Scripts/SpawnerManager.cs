using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] itensParaGerar;
    public int quantidadeTotal = 5;
    
    void Start()
    {
        GerarItens();    
    }

    // Update is called once per frame
    void GerarItens()
    {
        GameObject[] pontos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        List<GameObject> pontosDisponiveis = new List<GameObject>(pontos);

        for (int i = 0; i < quantidadeTotal; i++)
        {
            if (pontosDisponiveis.Count == 0) break;

            int indexPonto = Random.Range(0, pontosDisponiveis.Count);
            int indexItem = Random.Range(0, itensParaGerar.Length);

            Instantiate(itensParaGerar[indexItem], pontosDisponiveis[indexPonto].transform.position, Quaternion.identity);

            pontosDisponiveis.RemoveAt(indexPonto);
        }

    }

    public void GerarUmNovoItem()
    {
        GameObject[] pontos = GameObject.FindGameObjectsWithTag("SpawnPoint");
    
        if (pontos.Length > 0 && itensParaGerar.Length > 0)
        {
            int indexPonto = Random.Range(0, pontos.Length);
            int indexItem = Random.Range(0, itensParaGerar.Length);

            Instantiate(itensParaGerar[indexItem], pontos[indexPonto].transform.position, Quaternion.identity);
            Debug.Log("Nova pedra gerada!");
        }
        else
        {
            Debug.LogError("Cuidado: Sem SpawnPoints ou Prefabs configurados!");
        }
    }
}
