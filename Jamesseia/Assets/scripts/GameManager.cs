using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Hashtable sequenciaFases = new Hashtable();
    private Queue<TextObject> textos = new Queue<TextObject>();
    public GUISkin layout;
    private GUIStyle guiStyleBlq = new GUIStyle();
	private GUIStyle guiStyleFim = new GUIStyle();

    private void setBlqStyle(){
		guiStyleBlq.fontSize = 22;
		guiStyleBlq.normal.textColor = Color.green;

		Texture2D debugTex = new Texture2D(1,1);
      	debugTex.SetPixel(0,0, Color.black);
      	debugTex.Apply();

		guiStyleBlq.normal.background = debugTex;
	}

	private void setFimStyle(){
		guiStyleFim.fontSize = 22;
		guiStyleFim.normal.textColor = Color.red;

		Texture2D debugTex = new Texture2D(1,1);
      	debugTex.SetPixel(0,0,Color.black);
      	debugTex.Apply();

		guiStyleFim.normal.background = debugTex;
	}

    public void addTarjaBloqueio(){
        TextObject texto = new TextObject(Screen.width / 2 - 175, Screen.height - 80, " A Fase já foi concluída!", false);
		textos.Enqueue(texto);
    }

    public void addTarjaImcomplete(){
        TextObject texto = new TextObject(Screen.width / 2 - 300, Screen.height - 100, "  Fase bloqueada!\n  Conclua todas as fases para liberar a final!", true);
		textos.Enqueue(texto);
    }

    private void dequeueTextos(){
        
		textos.Dequeue();
        Debug.Log("Dequeiado2");
    }
	
    public void concludeFase(){
        ScoreManager.scoreFases[faseAtual()].chefeCompleto = true;
    }

    public bool selectionStatus(string nomeCena){
        if(faseNumber(nomeCena) != 5){
            return ScoreManager.scoreFases[faseNumber(nomeCena)].chefeCompleto;
        }else{
            bool completeAllFases = true;

            for(int i = 0; i < 5; i++){
                if(completeAllFases){
                    completeAllFases = ScoreManager.scoreFases[i].chefeCompleto ? true : false;
                }
            }

            return completeAllFases;
        }
    }

    public int faseAtual(){
        //era melhor fazer um switch case, sem tempo irmao
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
    
    public int faseNumber(string nomeCena){
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
        GUI.skin = layout;

        if(SceneManager.GetActiveScene().name == "selecao"){
            if(textos.Count > 0){
                foreach(TextObject texto in textos){
                    if(texto.isFinal)
                    {
                        GUI.Label(new Rect(texto.x, texto.y, 600, 50), texto.text, guiStyleFim);
                    }
                    else
                    {
                        GUI.Label(new Rect(texto.x, texto.y, 300, 25), texto.text, guiStyleBlq);
                    }

                    if(!texto.isDequeued){
                        texto.isDequeued = true;
                        Invoke("dequeueTextos", 2);
                    }
                }		
		    }
        }else if(SceneManager.GetActiveScene().name == "vitoria"){
            if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 40, 60, 22), "Pular"))
            {
                ScoreManager.resetPontuacoes();
                Invoke("changeScene", 2.5f);
            }
        }else if(SceneManager.GetActiveScene().name == "creditos"){
            if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 40, 90, 28), "Voltar pro menu"))
            {
                ScoreManager.resetPontuacoes();
                Invoke("changeScene", 2.5f);
            }
        }
	}

    private void restartGameManager(){
        ScoreManager.resetPontuacoes();
		Invoke("changeScene", 0.5f);
	}

    private void changeScene(){
        SceneManager.LoadScene(sequenciaFases[SceneManager.GetActiveScene().name].ToString());
	}

    public void finalScene(){
        SceneManager.LoadScene("vitoria");
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
        sequenciaFases.Add("vitoria", "creditos");
        sequenciaFases.Add("creditos", "menu");
        
        Time.timeScale = 1;
        Debug.Log("startado");

        textos.Clear();

        textos = new Queue<TextObject>();

        setBlqStyle();
        setFimStyle();
    }

    void Update()
    {
    }
}