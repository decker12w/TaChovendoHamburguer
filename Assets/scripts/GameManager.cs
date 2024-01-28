using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ingredientsScript;  
    [SerializeField] private GameObject musica1;
    [SerializeField] private GameObject musica2;
    [SerializeField] private IngredientsScript ingredientsScript2;     
    [SerializeField] private GameObject woodScript;        
    [SerializeField] private GameObject playerMoviment;    
    [SerializeField] private GameObject gameOver;    
    public void GameOver()
    {
        
        woodScript.SetActive(false);
        playerMoviment.SetActive(false);
        ingredientsScript.SetActive(false);
        gameOver.SetActive(true);
        musica1.SetActive(false);
        musica2.SetActive(true);
        ingredientsScript2.DestroyIngredients();

    } 

    public void RestartGame()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

public void SairDoJogo()
{
    Debug.Log("saiu");
    Application.Quit();
}
}
