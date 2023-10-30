using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamemaneger : MonoBehaviour
{
    public GameObject playerisdead; 
    public Text texto; 
    public Button restart; 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        restart.gameObject.SetActive(false);
        texto.gameObject.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        // Verifica se o objeto foi destru�do
        if (playerisdead == null)
        {
            Time.timeScale = 0f;
            texto.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
    }

    
}
