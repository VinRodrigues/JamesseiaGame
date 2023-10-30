using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoviment : MonoBehaviour
{
    public float velocidadeMovimento = 5f; // Velocidade de movimento do inimigo
    public GameObject bulletPrefab; // Prefab da bala que o inimigo vai atirar
    public Transform bulletSpawnPoint; // Ponto de origem das balas
    public float taxaMinimaDeTiro = 1f; // Taxa m�nima de tempo entre os tiros (em segundos)
    public float taxaMaximaDeTiro = 3f; // Taxa m�xima de tempo entre os tiros (em segundos)

    private float tempoDecorrido = 0f;
    private float taxaDeTiro= 0.5f;

    void Start()
    {
        // Define uma taxa de tiro inicial aleat�ria dentro do intervalo especificado
        taxaDeTiro = Random.Range(taxaMinimaDeTiro, taxaMaximaDeTiro);
    }

    void Update()
    {
        // Movimenta o inimigo da direita para a esquerda
        transform.Translate(Vector3.left * velocidadeMovimento * Time.deltaTime);

        // Atualiza o tempo decorrido
        tempoDecorrido += Time.deltaTime;

        // Verifica se � hora de atirar
        if (tempoDecorrido >= taxaDeTiro)
        {
            Atirar(); // Chama a fun��o para atirar
            tempoDecorrido = 0f; // Reseta o tempo decorrido

            // Define uma nova taxa de tiro aleat�ria para o pr�ximo disparo
            taxaDeTiro = Random.Range(taxaMinimaDeTiro, taxaMaximaDeTiro);
        }
    }

    void Atirar()
    {
        // Instancia uma nova bala no ponto de origem das balas
        GameObject novaBala = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        // Define a dire��o da bala (para a esquerda)
        novaBala.GetComponent<Rigidbody2D>().velocity = Vector2.left * 4f;
        // Destroi a bala ap�s 2 segundos para evitar vazamento de mem�ria
        Destroy(novaBala,2f);
    }
}
