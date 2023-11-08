using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Velocidade de movimento do inimigo
    public float minX = -10.0f; // Posição X mínima (esquerda)
    public float maxX = 10.0f; // Posição X máxima (direita)
    private bool movingRight = true; // Flag para controlar a direção do movimento

    private void Update()
    {
        // Move o inimigo da direita para a esquerda
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            // Se atingir a posição máxima à direita, muda a direção
            if (transform.position.x >= maxX)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            // Se atingir a posição mínima à esquerda, muda a direção
            if (transform.position.x <= minX)
            {
                movingRight = true;
            }
        }
    }
}
