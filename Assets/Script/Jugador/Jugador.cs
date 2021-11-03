using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{

    public static GameObject jugador;
    public GameObject jugadorAPasar;
    // Variables publicas
    public float salto;
    public Canvas canvasMenuPausa, canvasGameOver;
    public static bool morido;

    // Variables privadas
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal, vertical;
    private int contador;
    private bool estaEnElPiso;



    // Start
    private void Start()
    {
        jugador = jugadorAPasar;
        estaEnElPiso = false;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update
    private void Update()
    {
        // dudo de la ética de lo que voy a hacer, pero ta, queda poco tiempo c:
        if (morido)
            Reiniciar();

        // Tomar ejes
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Calibracion de Horizontal y Vertical
        CalibrarHorizontalVertical();

        // Rotar segun el eje
        Rotar();

        // Movimiento
        MapeadoDeTeclaSinFisicas();

        // Reinicio de nivel por caída
        if (transform.position.y < -7)
        {
            /*  [insertar sprite de game over]; no sé parar el movimiento
                del personaje, pero por ahí viene la cosa. -igna */
            morido = true;
        }
    }

    // FixedUpdate (Física)
    private void FixedUpdate()
    {
        MapeadoDeTeclaConFisica();
    }

    // (Movimiento basico)
    private void MapeadoDeTeclaSinFisicas()
    {
        if (MenuPausa.enPausa == false)
        {
            // Ir a la derecha
            if (horizontal == 1)
            {
                if (Jeringas.habilidadMR == true)
                {
                    transform.Translate(Time.deltaTime * horizontal * Jeringas.habilidadRapida, 0f, 0f);
                }
                else
                {
                    transform.Translate(Time.deltaTime * horizontal * Jeringas.velocidadNormal, 0f, 0f);
                }
                animator.SetBool("Correr", true);
                // Ir a la izquierda
            }
            else if (horizontal == -1)
            {
                if (Jeringas.habilidadMR == true)
                {
                    transform.Translate(Time.deltaTime * horizontal * Jeringas.habilidadRapida, 0f, 0f);
                }
                else
                {
                    transform.Translate(Time.deltaTime * horizontal * Jeringas.velocidadNormal, 0f, 0f);
                }
                animator.SetBool("Correr", true);
                // Sin hacer nada
            }
            else if (horizontal == 0)
            {
                animator.SetBool("Correr", false);
            }

            // Pausar
            if (Input.GetKeyDown(KeyCode.P))
            {
                GuardarCargarDatos.intancia.Guardar();
                canvasMenuPausa.enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                GuardarCargarDatos.intancia.Cargar();
            }
        }
        else
        {
            animator.SetBool("Correr", false);
        }
    }

    // (Saltar)
    private void MapeadoDeTeclaConFisica()
    {
        if (MenuPausa.enPausa == false)
        {
            // Saltar
            if (vertical == 1 && estaEnElPiso == true)
            {
                rigidbody.AddForce(new Vector2(0, salto));
                // animator.SetBool("saltar", true);
                estaEnElPiso = false;

            }
        }
    }

    // (Se reinicia el nivel)
    private void Reiniciar()
    {
        // parar música
        MenuPausa.enPausa = true;
        if (!canvasGameOver.isActiveAndEnabled)
        {
            canvasGameOver.enabled = true;
        }        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            MenuPausa.enPausa = false;
            morido = false;
            canvasGameOver.enabled = false;
        }

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
    // Dectectar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Dectectar el piso
        if (collision.gameObject.tag == "Piso")
        {
            estaEnElPiso = true;
            // animator.SetBool("saltar", false);
        }

        // Dectectar colision con pinchos
        if (collision.gameObject.tag == "Enemigo")
        {
            morido = true;
        }
    }

}