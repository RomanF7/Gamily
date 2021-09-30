using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LenguajesMenuPrincipal : MonoBehaviour
{
    public static bool enIngles;
    public Image logoJuego;
    public Sprite logoESP, logoING;
    public Sprite[] spritesBtnESP, spritesBtnING;
    public Button[] botones;
    public SpriteState[] accionESP, accionING;
    // Start is called before the first frame update
    private void Awake()
    {
        enIngles = LenguajesOpciones.enIngles;
    }

    private void Start()
    {
        if (enIngles == true)
        {
            logoJuego.sprite = logoING;
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.sprite = spritesBtnING[i];
                botones[i].spriteState = accionING[i];
            }
        }else if(enIngles == false)
        {
            logoJuego.sprite = logoESP;
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.sprite = spritesBtnESP[i];
                botones[i].spriteState = accionESP[i];
            }
        }
    }
    //Nota n°2: +NQKyoKqT4NvcHXTuMPeiHMDZCQBUw4tU6utomlIhjDaqOh/lSY6Ws6aqBDuumnSxdgXKLL/j4OPOOezKCz7Hr1t5zRkHi/BA9rqI60NwShKrGYBOek3APhAMj75VxEbhg6eFV0OfB1VrZEdWawn/A (https://cifraronline.com/aes)
}
