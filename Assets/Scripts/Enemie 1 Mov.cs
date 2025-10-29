using UnityEngine;

public class Enemie1 : MonoBehaviour
{
    public float velocidad;
    public float limiteDerecho = 15f;
    public float limiteIzquierdo = -15f;

    private bool movimientoDerecha = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movimientoDerecha)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            if (transform.position.x >= limiteDerecho)
            {
                movimientoDerecha = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            if (transform.position.x <= limiteIzquierdo)
            {
                movimientoDerecha = true;
        }   }
    }
}
