using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour
{
    public float velocidade = 2f; // Velocidade de movimento do inimigo
    public float limiteSuperior = 5f; // Limite superior no eixo Y
    public float limiteInferior = -5f; // Limite inferior no eixo Y

    private int direcao = 1; // 1 para mover para cima, -1 para mover para baixo

    void Update()
    {
        // Movimenta o inimigo
        transform.Translate(Vector2.up * velocidade * direcao * Time.deltaTime);

        // Verifica se o inimigo atingiu o limite superior ou inferior
        if (transform.position.y > limiteSuperior)
        {
            // Muda a direção para baixo
            direcao = -1;
        }
        else if (transform.position.y < limiteInferior)
        {
            // Muda a direção para cima
            direcao = 1;
        }
    }
}
