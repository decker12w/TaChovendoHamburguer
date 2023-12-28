using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    [SerializeField] private int lifes;
    [SerializeField] private Text lifesText;

    void Start()
    {
        lifesText = GetComponent<Text>();
        lifesText.text = lifes.ToString(); 
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
