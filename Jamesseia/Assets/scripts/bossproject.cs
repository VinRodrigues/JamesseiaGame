using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossproject : MonoBehaviour
{
    public float saladaSpeed;
    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRB.AddForce(Vector2.down * saladaSpeed, ForceMode2D.Impulse); // Alterado para adicionar força para baixo
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
