using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saladaepecial : MonoBehaviour
{
    public int quantidadeMunicao = 10; // Quantidade de muni��o a ser adicionada ao jogador quando coletado

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obt�m a refer�ncia ao script playerController no jogador
            playerController jogador = collision.GetComponent<playerController>();

            // Adiciona a quantidade de muni��o ao jogador
            jogador.AumentarMunicao(quantidadeMunicao);

            // Destroi o colet�vel ap�s ser coletado
            Destroy(gameObject);
        }
    }
}