using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jeringas : MonoBehaviour
{
    public SpriteRenderer jeringaRojaHUD, jeringaAzulHUD;
    public static float velocidadNormal, habilidadLenta, habilidadRapida;
    private float duracionJR, duracionJA, cronometroJR, cronometroJA;
    public Sprite cooldownJR, cooldownJA, normalJR, normalJA;
    public static bool habilidadJR, habilidadJA, pararTiempo;


    private void Awake()
    {
        //Setteo de varibles por defecto
        pararTiempo = false;
        //muerte = false;
        velocidadNormal = 2f;
        cronometroJR = 0;
        cronometroJA = 0;
        duracionJR = 0;
        duracionJA = 0;

        habilidadRapida = velocidadNormal * 2.5f;
        if (Doctor.visitaAlDoctor == true)
        {
            jeringaRojaHUD.enabled = true;
        }

    }
    private void Update()
    {
        JeringaLogica();
    }
    private void JeringaLogica()
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
        }

        //Dosis velocidad
        if (Input.GetKeyDown(KeyCode.F) && Time.unscaledTime >= cronometroJR)
        {

            jeringaRojaHUD.sprite = cooldownJR;
            cronometroJR = Time.unscaledTime + 3f;
            duracionJR = Time.unscaledTime + 3f;
            habilidadJR = true;
        }

        if (Time.unscaledTime > duracionJR && habilidadJR == true)
        {
            jeringaRojaHUD.sprite = normalJR;
            habilidadJR = false;
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
}
