using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossatk : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab da bala que o inimigo vai atirar
    public Transform bulletSpawnPoint; // Ponto de origem das balas
    public float taxaMinimaDeTiro = 1f; // Taxa mínima de tempo entre os tiros (em segundos)
    public float taxaMaximaDeTiro = 3f; // Taxa máxima de tempo entre os tiros (em segundos)

    private float tempoDecorrido = 0f;
    private float taxaDeTiro = 0.5f;

    void Start()
    {
        // Define uma taxa de tiro inicial aleatória dentro do intervalo especificado
        taxaDeTiro = Random.Range(taxaMinimaDeTiro, taxaMaximaDeTiro);
    }

    void Update()
    {
        // Atualiza o tempo decorrido
        tempoDecorrido += Time.deltaTime;

        // Verifica se é hora de atirar
        if (tempoDecorrido >= taxaDeTiro)
        {
            Atirar(); // Chama a função para atirar
            tempoDecorrido = 0f; // Reseta o tempo decorrido

            // Define uma nova taxa de tiro aleatória para o próximo disparo
            taxaDeTiro = Random.Range(taxaMinimaDeTiro, taxaMaximaDeTiro);
        }
    }

    void Atirar()
    {
        // Instancia uma nova bala no ponto de origem das balas
        GameObject novaBala = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        // Define a direção da bala (para baixo)
        novaBala.GetComponent<Rigidbody2D>().velocity = Vector2.down * 4f;
        // Destroi a bala após 2 segundos para evitar vazamento de memória
        Destroy(novaBala, 2f);
    }
}
