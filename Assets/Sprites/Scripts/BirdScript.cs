using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {
    public float jumpForce = 50f;
    Rigidbody2D rb;
    public float forwardSpeed = 2f;
    public GameObject cam;
    public bool dead;
    public float xx;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
        if (dead == false)//Si el pajarito esta vivo aun
        {
            if (Input.GetButtonDown("Jump"))//testeamos si quiere saltar
            {
                rb.velocity = Vector2.zero;//el vector es zero
                rb.AddForce(new Vector2(0, 18 * jumpForce));//se le aplica la fuerza de salto
            }
            //Parámetros para el movimiento de la cámara y del pajarito
            rb.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
            cam.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);

           
        }
        //Si llega a la posicion 69 que se muera
        if (rb.transform.position.x > 69)
        {
            dead = true;
        }
       
        

    }
    /*
     * Este método es para colisiones
     * 
     * */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dead = true;
    }
}
