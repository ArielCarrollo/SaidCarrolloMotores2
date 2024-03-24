using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jugador : MonoBehaviour
{
    public float SpeedX;
    private Rigidbody2D _comRigiBody;
    private float horizontal;
    public float raycast;
    public bool Isground;
    public LayerMask Detectar;
    public bool Saltar;
    public float distancia;
    private int saltosRestantes; 
    public int maxSaltos = 2;
    private SpriteRenderer mySpriteRenderercolor;
    private float vida=10;
    private float VidaMaxima=10;
    public Vida BarraV;
    private void Start()
    {
        vida = VidaMaxima;
        BarraV.Full(vida);
    }
    public void RecibeDaño(float daño)
    {
        vida -= daño;
        BarraV.quitarvida(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("3");
        }
        
    }
    void Awake()
    {
        mySpriteRenderercolor = GetComponent<SpriteRenderer>();
        _comRigiBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Isground = Physics2D.Raycast(transform.position, Vector2.down, raycast, Detectar);
        if (Isground)
        {
            saltosRestantes = maxSaltos;
        }

        if (Input.GetButtonDown("Jump") && (saltosRestantes > 0))
        {
            Saltar = true;
            saltosRestantes--; 
        }
    }

    void FixedUpdate()
    {
        _comRigiBody.velocity = new Vector2(horizontal * SpeedX, _comRigiBody.velocity.y);
        if (Saltar)
        {
            _comRigiBody.velocity = new Vector2(_comRigiBody.velocity.x, 0); 
            _comRigiBody.AddForce(new Vector2(0, distancia), ForceMode2D.Impulse);
            Saltar = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        SpriteRenderer otherSpriteRenderer = collision.collider.GetComponent<SpriteRenderer>();
        if (otherSpriteRenderer != null)
        {
      
            if (mySpriteRenderercolor.color == otherSpriteRenderer.color)
            {
               
                GetComponent<Collider2D>().isTrigger = true;
            }
            else if (mySpriteRenderercolor.color != otherSpriteRenderer.color && otherSpriteRenderer.tag =="color")
            {
                RecibeDaño(1.0f);
            }
        }
        if( collision.gameObject.tag == "A")
        {
            SceneManager.LoadScene("2");
        }
        if (collision.gameObject.tag == "E")
        {
            SceneManager.LoadScene("4");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
