using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Hashtable sequenciaFases = new Hashtable();
	
    public void concludeFase(){
        ScoreManager.scoreFases[faseAtual()].chefeCompleto = true;
    }

    public bool selectionStatus(string nomeCena){
        return ScoreManager.scoreFases[faseNumber(nomeCena)].chefeCompleto;
    }

    private int faseAtual(){
		if(SceneManager.GetActiveScene().name == "fase1a" 
        || SceneManager.GetActiveScene().name == "fase1b")
        {
			return 0;
        }
        else 
        if(SceneManager.GetActiveScene().name == "fase2a"
        || SceneManager.GetActiveScene().name == "fase2b")
        {
            return 1;
        }
        else
        if(SceneManager.GetActiveScene().name == "fase3a"
        || SceneManager.GetActiveScene().name == "fase3b")
        {
            return 2;
        }
        else
        if(SceneManager.GetActiveScene().name == "fase4a"
        || SceneManager.GetActiveScene().name == "fase4b")
        {
            return 3;
        }
        else
        if(SceneManager.GetActiveScene().name == "fase5a"
        || SceneManager.GetActiveScene().name == "fase5b")
        {
            return 4;
        }
        else
        if(SceneManager.GetActiveScene().name == "fase6a"
        || SceneManager.GetActiveScene().name == "fase6b")
        {
            return 5;
        }
		else
		{
			return -1;
		}
	}
    
    private int faseNumber(string nomeCena){
		if(nomeCena == "fase1a" 
        || nomeCena == "fase1b")
        {
			return 0;
        }
        else 
        if(nomeCena == "fase2a"
        || nomeCena == "fase2b")
        {
            return 1;
        }
        else
        if(nomeCena == "fase3a"
        || nomeCena == "fase3b")
        {
            return 2;
        }
        else
        if(nomeCena == "fase4a"
        || nomeCena == "fase4b")
        {
            return 3;
        }
        else
        if(nomeCena == "fase5a"
        || nomeCena == "fase5b")
        {
            return 4;
        }
        else
        if(nomeCena == "fase6a"
        || nomeCena == "fase6b")
        {
            return 5;
        }
		else
		{
			return -1;
		}
	}

	void OnGUI ()
    {
	    
	}

    private void restartGameManager(){
        ScoreManager.resetPontuacoes();
		Invoke("changeScene", 0.5f);
	}

    private void changeScene(){
        SceneManager.LoadScene(sequenciaFases[SceneManager.GetActiveScene().name].ToString());
	}

    void Start()
    {
        sequenciaFases.Add("menu", "selecao");
        sequenciaFases.Add("fase1a", "fase1b");
        sequenciaFases.Add("fase2a", "fase2b");
        sequenciaFases.Add("fase3a", "fase3b");
        sequenciaFases.Add("fase4a", "fase4b");
        sequenciaFases.Add("fase5a", "fase5b");
        sequenciaFases.Add("fase6a", "fase6b");
    }

    void Update()
    {
    }
}