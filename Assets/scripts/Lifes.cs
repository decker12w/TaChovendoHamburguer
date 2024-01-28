using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    [SerializeField] public int lifes;
    [SerializeField] private Text lifesText;

    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        lifesText = GetComponent<Text>();
        lifesText.text = lifes.ToString(); 
    }
    
   void Update()
    {
        if (lifes <= 0)
        {
            gameManager.GameOver();
        }
    }
    public void removeLife(int points)
    {
        lifes -= points;
        if (lifes < 0)
        {
            lifes = 0;
        }
        lifesText.text = lifes.ToString();
    }
}
