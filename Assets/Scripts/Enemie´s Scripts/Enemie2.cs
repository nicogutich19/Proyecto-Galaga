using UnityEngine;

public class Enemie2 : MonoBehaviour
{
    public float velocidad = 5f;
    public float limiteDerecho = 10f;
    public float limiteIzquierdo = -10f;
    public float descenso = 0.5f; 

    private bool movimientoDerecha = true;

    void Update()
    {
        if (movimientoDerecha)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            if (transform.position.x >= limiteDerecho)
            {
                movimientoDerecha = false;
            
                transform.Translate(Vector2.down * descenso);
            }
        }
        else
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            if (transform.position.x <= limiteIzquierdo)
            {
                movimientoDerecha = true;
                // al cambiar de dirección, baja un poco
                transform.Translate(Vector2.down * descenso);
            }
        }
    }
}