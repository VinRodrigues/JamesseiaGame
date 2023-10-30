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
        SceneManager.LoadScene(nomeDaCena);
    }
}
