using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenguajeMenuConfirmacion : MonoBehaviour
{
    public Image texto;
    public Sprite textoESP, textoING;
    public Sprite[] spritesBtnESP, spritesBtnING;
    public SpriteState[] accionESP, accionING;
    public Button[] botones;

    private bool enIngles;

    private void Awake()
    {
        enIngles = LenguajesOpciones.enIngles;
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (enIngles == true)
        {
            texto.sprite = textoING;
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.sprite = spritesBtnING[i];
                botones[i].spriteState = accionING[i];
            }
        }
        else if (enIngles == false)
        {
            texto.sprite = textoESP;
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.sprite = spritesBtnESP[i];
                botones[i].spriteState = accionESP[i];
            }
        }
    }
}
