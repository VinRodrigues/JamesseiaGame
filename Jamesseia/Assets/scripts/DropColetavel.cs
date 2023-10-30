using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropColetavel : MonoBehaviour
{
    public GameObject salada2Prefab; // Prefab do colet�vel salada2
    public GameObject heartPrefab; // Prefab do colet�vel heart
    public float dropRateSalada2 = 0.3f; // Taxa de drop da salada2 (30% de chance)
    public float destroyTime = 5f; // Tempo em segundos antes do colet�vel ser destru�do
    public float velocidadeDescida = 2f; // Velocidade de descida dos colet�veis
    public Transform spawnPoint; // Ponto de spawn dos colet�veis

    void Start()
    {
        InvokeRepeating("DropColetavelAleatorio", 10f, 15f); // Invoca o m�todo DropColetavelAleatorio a cada segundo
        //Destroy(gameObject, destroyTime); // Destr�i o objeto DropColetavel ap�s 5 segundos
    }

    void DropColetavelAleatorio()
    {
        float random = Random.Range(0f, 1f); // Gera um n�mero aleat�rio entre 0 e 1

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
        //Destroy(coletavel, destroyTime); // Destr�i o colet�vel ap�s 5 segundos
    }
}
