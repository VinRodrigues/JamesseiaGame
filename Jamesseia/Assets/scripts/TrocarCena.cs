using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    // Nome da cena que ser� carregada (pode ser alterado no Inspector do Unity)
    [SerializeField] private string nomeDaCena;

    // Fun��o para trocar de cena
    public void TrocarDeCena()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        
        if (!gameManager.selectionStatus(nomeDaCena))
        {
            SceneManager.LoadScene(nomeDaCena);
        }else{
            Debug.Log("Fase já concluída");
            SceneManager.LoadScene("menu");
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void loadSelection()
    {
        SceneManager.LoadScene("selecao");
    }

    public void loadBoss()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
