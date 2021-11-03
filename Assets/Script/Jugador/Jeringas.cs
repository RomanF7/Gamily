using UnityEngine;

public class Jeringas : MonoBehaviour
{
    public SpriteRenderer medicinaRojaHUD, medicinaAzulHUD;
    public static float velocidadNormal, habilidadLenta, habilidadRapida;
    private float duracionMR, duracionMA, cronometroMR, cronometroMA;
    public Sprite cooldownMR, cooldownMA, normalMR, normalMA;
    public static bool habilidadMR, habilidadMA, pararTiempo;


    private void Awake()
    {

        //Setteo de varibles por defecto
        pararTiempo = false;
        //muerte = false;
        velocidadNormal = 2f;
        cronometroMR = 0;
        cronometroMA = 0;
        duracionMR = 0;
        duracionMA = 0;

        habilidadRapida = velocidadNormal * 3f;
    }
    private void Update()
    {
        MedicinaLogica();
    }
    private void MedicinaLogica()
    {
        //Dosis lento el entorno
        if (Input.GetKeyDown(KeyCode.G) && Time.unscaledTime >= cronometroMA)
        {

            medicinaAzulHUD.sprite = cooldownMA;
            cronometroMA = Time.unscaledTime + 5f;
            duracionMA = Time.unscaledTime + 5f;
            habilidadMA = true;
        }

        if (Time.unscaledTime <= duracionMA && habilidadMA == true)
        {
            habilidadLenta = velocidadNormal / 2f;
        }
        else if (habilidadMA == true)
        {
            medicinaAzulHUD.sprite = normalMA;
            habilidadMA = false;
        }

        //Dosis velocidad
        if (Input.GetKeyDown(KeyCode.F) && Time.unscaledTime >= cronometroMR)
        {

            medicinaRojaHUD.sprite = cooldownMR;
            cronometroMR = Time.unscaledTime + 5f;
            duracionMR = Time.unscaledTime + 5f;
            habilidadMR = true;
        }

        if (Time.unscaledTime > duracionMR && habilidadMR == true)
        {
            medicinaRojaHUD.sprite = normalMR;
            habilidadMR = false;
        }

        //Parar Tiempo
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
