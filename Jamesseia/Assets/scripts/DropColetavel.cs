using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropColetavel : MonoBehaviour
{
    public GameObject salada2Prefab; // Prefab do coletável salada2
    public GameObject heartPrefab; // Prefab do coletável heart
    public float dropRateSalada2 = 0.3f; // Taxa de drop da salada2 (30% de chance)
    public float destroyTime = 5f; // Tempo em segundos antes do coletável ser destruído
    public float velocidadeDescida = 2f; // Velocidade de descida dos coletáveis
    public Transform spawnPoint; // Ponto de spawn dos coletáveis

    void Start()
    {
        InvokeRepeating("DropColetavelAleatorio", 10f, 15f); // Invoca o método DropColetavelAleatorio a cada segundo
        //Destroy(gameObject, destroyTime); // Destrói o objeto DropColetavel após 5 segundos
    }

    void DropColetavelAleatorio()
    {
        float random = Random.Range(0f, 1f); // Gera um número aleatório entre 0 e 1

        GameObject coletavelPrefab;

        if (random <= dropRateSalada2)
        {
            coletavelPrefab = salada2Prefab;
        }
        else
        {
            coletavelPrefab = heartPrefab;
        }

        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        GameObject coletavel = Instantiate(coletavelPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = coletavel.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * velocidadeDescida;
        //Destroy(coletavel, destroyTime); // Destrói o coletável após 5 segundos
    }
}
