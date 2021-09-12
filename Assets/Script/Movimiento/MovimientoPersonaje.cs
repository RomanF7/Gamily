using UnityEngine;
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
    public SpriteRenderer jeringaRoja, jeringaAzul;
    public Sprite cooldownR, cooldownA, normalR, normalA;
    public Transform transformFondo;
    public Canvas canvasMenuPausa;
    public MenuPausa menuPausa;

    //Variables privadas
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal, vertical, duracionR, duracionA, velocidadAPasar, habilidadRapida, velocidadActual, cronometroR, cronometroA;
    private int contador;
    private bool estaEnElPiso, habilidadR, habilidadA, pararTiempo, enRampa/*, muerte*/;
    private Vector3 margenDeErrorFondo;

    // Start
    void Start()
    {
        //Setteo de varibles por defecto
        estaEnElPiso = false;
        pararTiempo = false;
        enRampa = false;
        //muerte = false;

        cronometroR = 0;
        cronometroA = 0;
        duracionR = 0;
        duracionA = 0;

        velocidadActual = velocidadNormal;
        habilidadRapida = velocidadNormal * 2.5f;

        margenDeErrorFondo = new Vector3(1.08f, 4f, 0f);

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update
    void Update()
    {
        //Tomar ejes
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Jeringas
        Jeringas();

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
                animator.SetBool("correrDerecha", true);
                animator.SetBool("correrIzquierda", false);

                //Ir a la izquierda
            }
            else if (horizontal == -1)
            {
                transform.Translate(Time.deltaTime * horizontal * velocidadActual, 0f, 0f);
                animator.SetBool("correrDerecha", false);
                animator.SetBool("correrIzquierda", true);

                //Sin hacer nada
            }
            else if (horizontal == 0)
            {
                animator.SetBool("correrDerecha", false);
                animator.SetBool("correrIzquierda", false);
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
        if (Input.GetKeyDown(KeyCode.G) && Time.unscaledTime >= cronometroA)
        {

            jeringaAzul.sprite = cooldownA;
            cronometroA = Time.unscaledTime + 3f;
            duracionA = Time.unscaledTime + 3f;
            habilidadA = true;
        }

        if (Time.unscaledTime <= duracionA && habilidadA == true)
        {
            velocidadAPasar = velocidadNormal / 2f;
        }
        else if (habilidadA == true)
        {
            jeringaAzul.sprite = normalA;
            habilidadA = false;
            velocidadActual = velocidadNormal;
        }

        //Dosis velocidad
        if (Input.GetKeyDown(KeyCode.F) && Time.unscaledTime >= cronometroR)
        {

            jeringaRoja.sprite = cooldownR;
            cronometroR = Time.unscaledTime + 3f;
            duracionR = Time.unscaledTime + 3f;
            habilidadR = true;
        }

        if (Time.unscaledTime <= duracionR && habilidadR == true)
        {
            velocidadActual = habilidadRapida;
        }
        else if (habilidadR == true)
        {
            jeringaRoja.sprite = normalR;
            habilidadR = false;
            velocidadActual = velocidadNormal;
        }

        //Parar Tiempo
        if (habilidadA == true && habilidadR == true)
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

    //Getters
    public float GetVelocidadAPasar()
    {
        return velocidadAPasar;
    }

    public bool GetHabilidadA()
    {
        return habilidadA;
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

        if (collision.gameObject.tag == "Rampa")
        {
            enRampa = true;
        }
        else
        {
            enRampa = false;
        }
    }
}