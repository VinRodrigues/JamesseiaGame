using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    // variaveis de movimento
    public float maxSpeed;
    public float maxYPos; // Altura m�xima permitida
    public float minYPos; // Altura m�nima permitida
  
    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    // atirar parte
    public Transform spawnPointG;
    public GameObject bullet;
    public GameObject bullet2;
    float firerate = 0.5f;
    float nextFire = 0f;
    public int tirosRestantes = 10; // Quantidade inicial de tiros
    private bool tiroEspecialDisponivel = false;
    public Text textoTirosRestantes; // Refer�ncia ao objeto de texto no Unity para mostrar os tiros restantes

    // Booleano para verificar se a barra de espa�o est� sendo pressionada
    bool isSpeeding = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Limita a posição X entre -4.52 e 4.45
        float clampedXPos = Mathf.Clamp(myRB.position.x, -4.52f, 4.45f);
        myRB.position = new Vector2(clampedXPos, myRB.position.y);

        // Configura a velocidade do Rigidbody2D nas direções x e y
        myRB.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);

        // Limita a posição y dentro das bordas maxYPos e minYPos
        float clampedYPos = Mathf.Clamp(myRB.position.y, minYPos, maxYPos);
        myRB.position = new Vector2(myRB.position.x, clampedYPos);

        // Verifica se a barra de espa�o est� sendo pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpeeding = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space)) // Verifica se a barra de espa�o foi liberada
        {
            isSpeeding = false;
        }

        // Define o par�metro booleano no Animator para controlar a anima��o
        myAnim.SetBool("speed", isSpeeding);

        // Verifica a dire��o do movimento e inverte o sprite conforme necess�rio
        if ((moveX > 0 || moveY > 0) && (!facingRight))
        {
            flip();
        }
        else if ((moveX < 0) && (facingRight))
        {
            flip();
        }

        // disprado do player
        if (Input.GetAxisRaw("Fire1") > 0) saladaShot();
        if (Input.GetAxisRaw("Fire2") > 0 && tirosRestantes > 0 && tiroEspecialDisponivel)
        {
            tiroEspecialDisponivel = false;
            tirosRestantes--;
            saladaShot2();
            AtualizarTextoTirosRestantes();
            Invoke("decrementarTirosEspecial", 0.1f);
        }
    }

    void decrementarTirosEspecial(){
        tiroEspecialDisponivel = true;
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void saladaShot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            if (facingRight)
            {
                Instantiate(bullet, spawnPointG.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }else if (!facingRight)
            {
                Instantiate(bullet, spawnPointG.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
    void saladaShot2()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            if (facingRight)
            {
                Instantiate(bullet2, spawnPointG.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet2, spawnPointG.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
    void AtualizarTextoTirosRestantes()
    {
        textoTirosRestantes.text = "" + tirosRestantes.ToString();
    }
    public void AumentarMunicao(int quantidade)
    {
        tirosRestantes += quantidade;
        tiroEspecialDisponivel = true;
        AtualizarTextoTirosRestantes();
    }
}
