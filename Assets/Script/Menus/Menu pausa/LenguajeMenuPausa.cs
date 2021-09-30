using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenguajeMenuPausa : MonoBehaviour
{
    public Image pausa;
    public Sprite pausaING, pausaESP;
    public Sprite[] spriteBtnESP, spriteBtnING;
    public SpriteState[] accionESP, accionING;
    public Button[] botones;

    private bool enIngles;
    // Start is called before the first frame update

    private void Awake()
    {
        enIngles = LenguajesOpciones.enIngles;
    }

    private void Start()
    {
        if (enIngles == true)
        {
            pausa.sprite = pausaING;
            for(int i = 0; i < botones.Length; i++)
            {
                botones[i].image.sprite = spriteBtnING[i];
                botones[i].spriteState = accionING[i];
            }
        }else if(enIngles == false)
        {
            pausa.sprite = pausaESP;
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.sprite = spriteBtnESP[i];
                botones[i].spriteState = accionESP[i];
            }
        }       
    }
}
