using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimientoPersonaje : MonoBehaviour
{
    /*

        ****************************************************************************
        ****************************************************************************
        **ACLARACÓN TODA PARTE LÓGICA COMENTADA SE ESPERA QUE SE USE EN UN FUTURO.**
        ****************************************************************************
        ****************************************************************************

    */

    //Variables publicas
    public float velocidadNormal, salto;
    public Image jeringaRojaHUD, jeringaAzulHUD;
    public Sprite cooldownJR, cooldownJA, normalJR, normalJA;
    public Canvas canvasMenuPausa;
    public MenuPausa menuPausa;

    //Variables privadas
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal, vertical, duracionJR, duracionJA, habilidadLenta, habilidadRapida, velocidadActual, cronometroJR, cronometroJA;
    private int contador;
    private bool estaEnElPiso, habilidadJR, habilidadJA, pararTiempo;

    private void Awake()
    {
        if (Doctor.visitaAlDoctor)
        {
            jeringaRojaHUD.enabled = true;
        }
    }

    // Start
    private void Start()
    {
        //Setteo de varibles por defecto
        estaEnElPiso = false;
        pararTiempo = false;
        //muerte = false;

        cronometroJR = 0;
        cronometroJA = 0;
        duracionJR = 0;
        duracionJA = 0;

        velocidadActual = velocidadNormal;
        habilidadRapida = velocidadNormal * 2.5f;

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    // Update
    private void Update()
    {
        //Tomar ejes
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Jeringas
        Jeringas();

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
                transform.Translate(Time.deltaTime * horizontal * velocidadActual, 0f, 0f);
                animator.SetBool("Correr", true);
                //Ir a la izquierda
            }
            else if (horizontal == -1)
            {
                transform.Translate(Time.deltaTime * horizontal * velocidadActual, 0f, 0f);
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
    private void Jeringas()
    {
        //Dosis lento el entorno
        if (Input.GetKeyDown(KeyCode.G) && Time.unscaledTime >= cronometroJA)
        {

            jeringaAzulHUD.sprite = cooldownJA;
            cronometroJA = Time.unscaledTime + 3f;
            duracionJA = Time.unscaledTime + 3f;
            habilidadJA = true;
        }

        if (Time.unscaledTime <= duracionJA && habilidadJA == true)
        {
            habilidadLenta = velocidadNormal / 2f;
        }
        else if (habilidadJA == true)
        {
            jeringaAzulHUD.sprite = normalJA;
            habilidadJA = false;
            velocidadActual = velocidadNormal;
        }

        //Dosis velocidad
        if (Input.GetKeyDown(KeyCode.F) && Time.unscaledTime >= cronometroJR)
        {

            jeringaRojaHUD.sprite = cooldownJR;
            cronometroJR = Time.unscaledTime + 3f;
            duracionJR = Time.unscaledTime + 3f;
            habilidadJR = true;
        }

        if (Time.unscaledTime <= duracionJR && habilidadJR == true)
        {
            velocidadActual = habilidadRapida;
        }
        else if (habilidadJR == true)
        {
            jeringaRojaHUD.sprite = normalJR;
            habilidadJR = false;
            velocidadActual = velocidadNormal;
        }

        //Parar Tiempo
        if (habilidadJA == true && habilidadJR == true)
        {
            pararTiempo = true;
        }
        else
        {
            pararTiempo = false;
        }
    }

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

    //Getters
    public float GetVelocidadAPasar()
    {
        return habilidadLenta;
    }

    public bool GetHabilidadA()
    {
        return habilidadJA;
    }

    public bool GetEstaEnElPiso()
    {
        return estaEnElPiso;
    }

    public bool GetPararTiempo()
    {
        return pararTiempo;
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