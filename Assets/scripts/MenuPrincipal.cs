using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string nomeLevel;
    [SerializeField] private GameObject comojogar;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeLevel);
    }

    public void ComoJogarEntrar()
    {
       comojogar.SetActive(true);
    }

    public void ComoJogarSair()
    {
       comojogar.SetActive(false);
    }

    public void SairDoJogo()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }
}
