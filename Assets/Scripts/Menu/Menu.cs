using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string escena = "Nivel";
    public string creditos = "creditos";

    public void CambiaEscena(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
