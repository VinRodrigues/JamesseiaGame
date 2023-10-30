using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saladade10 : MonoBehaviour
{
    public int quantidadeMunicao = 10; // Quantidade de munição a ser adicionada ao jogador quando coletado

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtém a referência ao script playerController no jogador
            playerController jogador = collision.GetComponent<playerController>();

            // Adiciona a quantidade de munição ao jogador
            jogador.AumentarMunicao(quantidadeMunicao);

            // Destroi o coletável após ser coletado
            Destroy(gameObject);
        }
    }
}
