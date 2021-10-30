using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaFondo : MonoBehaviour
{

    private Transform camaraTransform;
    private Vector3 posAnteriorCamara;
    private float unidadDeTextura;
    [SerializeField] private float multiplicadorParallax = 0.5f;

    void Start()
    {
        camaraTransform = Camera.main.transform;
        posAnteriorCamara = camaraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D textura = sprite.texture;
        unidadDeTextura = textura.width / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        Vector3 desplazamiento = camaraTransform.position - posAnteriorCamara;
        transform.position += desplazamiento * multiplicadorParallax;
        posAnteriorCamara = camaraTransform.position;
        if(Mathf.Abs(camaraTransform.position.x - transform.position.x) >= unidadDeTextura)
        {
            float offset = (camaraTransform.position.x - transform.position.x) % unidadDeTextura;
            transform.position = new Vector3(camaraTransform.position.x + offset, transform.position.y);
        }
    }
}
