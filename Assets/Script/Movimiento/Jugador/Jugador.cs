using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    //Variables publicas
    public float salto;
    public Canvas canvasMenuPausa;
    public MenuPausa menuPausa;

    //Variables privadas
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal, vertical;
    private int contador;
    private bool estaEnElPiso;



    // Start
    private void Start()
    {
        estaEnElPiso = false;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update
    private void Update()
    {
        //Tomar ejes
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Calibracion de Horizontal y Vertical
        CalibrarHorizontalVertical();

        //Rotar segun el eje
        Rotar();

        //Movimiento
        MapeadoDeTeclaSinFisicas();
    }

    //FixedUpdate (Fisicas)
    private void FixedUpdate()
    {
        MapeadoDeTeclaConFisicas();
    }

    //(Movimiento basico)
    private void MapeadoDeTeclaSinFisicas()
    {
        if (menuPausa.GetEnPausa() == false)
        {
            //Ir a la derecha
            if (horizontal == 1)
            {
                if (Jeringas.habilidadJR == true)
                {
                    transform.Translate(Time.deltaTime * horizontal * Jeringas.habilidadRapida, 0f, 0f);
                }
                else
                {
                    transform.Translate(Time.deltaTime * horizontal * Jeringas.velocidadNormal, 0f, 0f);
                }
                animator.SetBool("Correr", true);
                //Ir a la izquierda
            }
            else if (horizontal == -1)
            {
                if (Jeringas.habilidadJR == true)
                {
                    transform.Translate(Time.deltaTime * horizontal * Jeringas.habilidadRapida, 0f, 0f);
                }
                else
                {
                    transform.Translate(Time.deltaTime * horizontal * Jeringas.velocidadNormal, 0f, 0f);
                }
                animator.SetBool("Correr", true);
                //Sin hacer nada
            }
            else if (horizontal == 0)
            {
                animator.SetBool("Correr", false);
            }

            //Reinicio de "Nivel1"
            if (Input.GetKey(KeyCode.R))
            {
                contador++;
                if (contador >= 180)
                {
                    Reiniciar();
                }
            }

            //Pausar
            if (Input.GetKeyDown(KeyCode.P))
            {
                canvasMenuPausa.enabled = true;
            }

        }
    }

    //(Saltar)
    private void MapeadoDeTeclaConFisicas()
    {
        if (menuPausa.GetEnPausa() == false)
        {
            //Saltar
            if (vertical == 1 && estaEnElPiso == true)
            {
                rigidbody.AddForce(new Vector2(0, salto));
                //animator.SetBool("saltar", true);
                estaEnElPiso = false;

            }
        }
    }

    //(Funcionamiento de jeringas)


    //(Se reinicia nivel 1)
    private void Reiniciar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    private void Rotar()
    {
        if (horizontal == 1)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontal == -1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void CalibrarHorizontalVertical()
    {
        if (horizontal > 0.25f)
        {
            horizontal = 1;
        }
        else if (horizontal < -0.25)
        {
            horizontal = -1;
        }

        if (vertical > 0.25f)
        {
            vertical = 1;
        }
        else if (vertical < -0.25)
        {
            vertical = -1;
        }
    }
    //Dectectar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Dectectar el piso
        if (collision.gameObject.tag == "Piso")
        {
            estaEnElPiso = true;
            //animator.SetBool("saltar", false);
        }

        //Dectectar colision con pinchos
        if (collision.gameObject.tag == "Pincho")
        {
            //muerte = true;
        }
    }
}