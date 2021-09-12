using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenguajesOpciones : MonoBehaviour
{
    public Image[] textos;
    public Sprite[] imagenesTextoING, imagenesTextoESP, spriteBtnING, spriteBtnESP, spriteBandera;
    public MenuOpciones menuOpciones;
    public Button[] botones;
    public Button btn_banderas;
    public SpriteState[] accionESP;
    public SpriteState[] accionING;

    //Nota n°1: Como una tarde para hacer una variable globar porque en Google hay mucha información. Pero era re facil solo añadiendo "static" .
    public static bool enIngles;

    void Start()
    {
        btn_banderas.onClick.AddListener(BTN_banderas);
        Debug.Log(enIngles);
    }

    // Update is called once per frame
    void Update()
    {
        EnIngles();
    }

    void BTN_banderas()
    {
        if (enIngles == true)
        {
            enIngles = false;
        }
        else if(enIngles == false)
        {
            enIngles = true;
        }
    }

    private void EnIngles()
    {
        if (enIngles == true)
        {
            btn_banderas.image.sprite = spriteBandera[0];
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].sprite = imagenesTextoING[i];
            }
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.sprite = spriteBtnING[i];
                botones[i].spriteState = accionING[i];
            }
        }
        else if (enIngles == false)
        {
            btn_banderas.image.sprite = spriteBandera[1];
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].sprite = imagenesTextoESP[i];
            }
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.sprite = spriteBtnESP[i];
                botones[i].spriteState = accionESP[i];
            }
        }
    }
}
