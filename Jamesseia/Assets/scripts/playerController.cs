using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    // variaveis de movimento
    public float maxSpeed;
    public float maxYPos; // Altura máxima permitida
    public float minYPos; // Altura mínima permitida

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
    public Text textoTirosRestantes; // Referência ao objeto de texto no Unity para mostrar os tiros restantes

    // Booleano para verificar se a barra de espaço está sendo pressionada
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

        // Configura a velocidade do Rigidbody2D nas direções x e y
        myRB.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);

        // Limita a posição y dentro das bordas maxYPos e minYPos
        float clampedYPos = Mathf.Clamp(myRB.position.y, minYPos, maxYPos);
        myRB.position = new Vector2(myRB.position.x, clampedYPos);

        // Verifica se a barra de espaço está sendo pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpeeding = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space)) // Verifica se a barra de espaço foi liberada
        {
            isSpeeding = false;
        }

        // Define o parâmetro booleano no Animator para controlar a animação
        myAnim.SetBool("speed", isSpeeding);

        // Verifica a direção do movimento e inverte o sprite conforme necessário
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
        if (Input.GetAxisRaw("Fire2") > 0 && tirosRestantes > 0)
        {
            saladaShot2();
            tirosRestantes--;
            AtualizarTextoTirosRestantes();
        }
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
        AtualizarTextoTirosRestantes();
    }
}
