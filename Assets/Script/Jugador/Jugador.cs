using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{

    public static GameObject jugador;
    public GameObject jugadorAPasar, jabon, jefe;
    // Variables publicas
    public static float velocidad;
    public float salto;
    public Canvas canvasMenuPausa, canvasGameOver;
    public static bool gameOver;

    // Variables privadas
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float horizontal, vertical;
    private int contador;
    private bool estaEnElPiso;




    // Awake
    private void Awake()
    {
        velocidad = 2f;
        jugador = jugadorAPasar;
        estaEnElPiso = false;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GuardarCargarDatos.instancia.Guardar();
    }


    // Update
    private void Update()
    {
        // Detectar Game Over
        if (gameOver)
            Reiniciar();

        if (jabon.transform.position != jefe.transform.position)
        {
            if (jabon.GetComponent<SpriteRenderer>().isVisible)
            {
                jabon.transform.position = Vector2.MoveTowards(jabon.transform.position, jefe.transform.position, .5f);
            }
        }

        // Tomar ejes
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Calibracion de Horizontal y Vertical
        CalibrarHorizontalVertical();

        // Rotar segun el eje
        Rotar();

        // Movimiento
        MapeadoDeTeclaSinFisicas();
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
                    transform.Translate(Time.deltaTime * horizontal * velocidad, 0f, 0f);
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
                    transform.Translate(Time.deltaTime * horizontal * velocidad, 0f, 0f);
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
                GuardarCargarDatos.instancia.Guardar();
                canvasMenuPausa.enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                GuardarCargarDatos.instancia.Cargar();
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
        if (!canvasGameOver.isActiveAndEnabled && gameOver)
        {
            Debug.Log("Reiniciado");
            MenuPausa.enPausa = true;
            spriteRenderer.enabled = false;
            canvasGameOver.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameOver = false;
            canvasGameOver.enabled = false;
            MenuPausa.enPausa = false;
            if (SceneManager.GetActiveScene().name == "Acto3")
            {
                DialogoNivel3.click = 76;
                Jefe.stop = false;
                Jefe.stop2 = false;
                Jefe.ataque1 = false;
                Jefe.ataque2 = false;
                Jefe.ataque3 = false;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            gameOver = true;
        }
    }
    public void PARAR()
    {
        animator.SetBool("Jabon", false);
        jabon.SetActive(true);
    }
}