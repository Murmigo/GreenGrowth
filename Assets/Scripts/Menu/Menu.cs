using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject CreditosPanel;
    public string escena = "Nivel";

    public void CambiaEscena(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void MostrarCreditos()
    {
        if (!CreditosPanel.activeSelf)
        {
            MenuPanel.SetActive(false);
            CreditosPanel.SetActive(true);
        }
        else {
            MenuPanel.SetActive(true);
            CreditosPanel.SetActive(false);
        }
    }
}
