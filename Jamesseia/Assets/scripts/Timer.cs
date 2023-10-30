using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float WaitSec;
    private int WaitSecInt;
    public Text text;
    public Text outroTexto;
    public Button botao;
    [SerializeField] private string nomeDaCena;

    private bool hasTimerEnded = false;

    private void Start()
    {
        
        outroTexto.gameObject.SetActive(false);
        botao.gameObject.SetActive(false);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (WaitSec > 0)
        {
            //Time.timeScale = 1f;
            WaitSec -= Time.deltaTime;
            WaitSecInt = Mathf.RoundToInt(WaitSec);
            text.text = WaitSecInt.ToString();
            yield return null;
        }

        hasTimerEnded = true;
        text.gameObject.SetActive(false);
        outroTexto.gameObject.SetActive(true);
        botao.gameObject.SetActive(true);
        //Time.timeScale = 0f;

        yield return new WaitForSeconds(3f);

        if (hasTimerEnded)
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
