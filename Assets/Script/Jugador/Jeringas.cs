using UnityEngine;

public class Jeringas : MonoBehaviour
{
    public SpriteRenderer medicinaRojaHUD, medicinaAzulHUD;
    public static float habilidadLenta, habilidadRapida;
    private float duracionMR, duracionMA, cronometroMR, cronometroMA, cooldownMR, cooldownMA;
    public Sprite noDisponibleMedRoja, noDisponibleMedAzul, normalMR, normalMA;
    public Animator animacionMedRoja, animacionMedAzul;
    public static bool habilidadMR, habilidadMA, pararTiempo;
    
    private void Awake()
    {

        //Setteo de varibles por defecto
        pararTiempo = false;

        cronometroMR = 0;
        cronometroMA = 0;
        
        duracionMR = 0;
        duracionMA = 0;

        animacionMedRoja.speed = 0.23f;
        animacionMedAzul.speed = 0.23f;

        animacionMedRoja.enabled = false;
        animacionMedAzul.enabled = false;

        // debería ser tomado del jugador, realmente, pero imposible
        habilidadRapida = 2f * 3f;
    }
    private void Update()
    {
        // Ralentizar entorno
        if (Input.GetKeyDown(KeyCode.G) && Time.unscaledTime >= cronometroMA)
        {

            medicinaAzulHUD.sprite = noDisponibleMedAzul;
            cronometroMA = Time.unscaledTime + 10f;
            duracionMA = Time.unscaledTime + 5f;
            habilidadMA = true;
        }

        if (Time.unscaledTime <= duracionMA && habilidadMA == true)
        {
            habilidadLenta = Jugador.velocidad / 2f;
        }
        else if (habilidadMA == true)
        {
            habilidadMA = false;
            animacionMedAzul.Rebind();
            animacionMedAzul.enabled = true;
        }
        else if (Time.unscaledTime >= cronometroMA && medicinaAzulHUD.sprite != normalMA)
        {
            animacionMedAzul.enabled = false;
            medicinaAzulHUD.sprite = normalMA;
        }

        // Hacer más rápido al jugador
        if (Input.GetKeyDown(KeyCode.F) && Time.unscaledTime >= cronometroMR)
        {
            medicinaRojaHUD.sprite = noDisponibleMedRoja;
            cronometroMR = Time.unscaledTime + 10f;
            duracionMR = Time.unscaledTime + 5f;
            habilidadMR = true;
        }

        if (Time.unscaledTime > duracionMR && habilidadMR == true)
        {
            habilidadMR = false;
            animacionMedRoja.Rebind();
            animacionMedRoja.enabled = true;
        }
        else if (Time.unscaledTime >= cronometroMR && medicinaRojaHUD.sprite != normalMR)
        {
            animacionMedRoja.enabled = false;
            medicinaRojaHUD.sprite = normalMR;
        }


        // Parar el tiempo
        if (habilidadMA == true && habilidadMR == true)
        {

            pararTiempo = true;
        }
        else
        {
            pararTiempo = false;
        }
    }
}

/*
public class Jeringas : MonoBehaviour
{
    public SpriteRenderer medicinaRojaHUD, medicinaAzulHUD;
    public static float velocidadNormal, habilidadRapida, multiplicadorLenta;
    private float duracionMR, duracionMA, cronometroMR, cronometroMA;
    public Sprite cooldownMR, cooldownMA, normalMR, normalMA;
    public static bool habilidadMR, habilidadMA, pararTiempo;

    void Awake()
    {
        // Definición de variables
        multiplicadorLenta = 0.5f;

    }

    void Update()
    {
        
    }
}*/
