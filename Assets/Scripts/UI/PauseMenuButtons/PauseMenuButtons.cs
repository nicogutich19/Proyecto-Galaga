using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;   
public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        if (juegoPausado)
        {
            Reanudar();
        }
        else
        {
            Pausa();
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

    }
    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    
    public void cerrar()
    {
        Debug.Log("Cerrando el Juego, Gracias por Jugar...");
        Application.Quit();
    }
}