using UnityEngine;
using UnityEngine.UI;

public class woodScript : MonoBehaviour
{
    public Image[] images;
    private int currentIndex = 0;

    private PlateScript plateScript;
    private Receita receita;
    private GeradorDeReceita geradorDeReceita; 

    private ScoreScript score;
    private Lifes lifes;

    private Pilha pilha;
    
    void Awake(){
        geradorDeReceita = GameObject.FindObjectOfType<GeradorDeReceita>(); 
        receita = geradorDeReceita.GerarReceitaAleatoria();
    }
    void Start()
    {
        plateScript = GameObject.FindObjectOfType<PlateScript>();
        score = GameObject.FindObjectOfType<ScoreScript>(); 
        lifes = GameObject.FindObjectOfType<Lifes>(); 
        
        pilha = GameObject.FindObjectOfType<Pilha>();
        // Generate images based on the recipe
        for (int i = 0; i < receita.GetQuantidade(); i++)
        {
            images[i].sprite = receita.ingredients[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void OnObjectPicked(GameObject pickedObject)
{
    Sprite pickedSprite = pickedObject.GetComponent<SpriteRenderer>().sprite;

   
    if (receita.ingredients[currentIndex].GetComponent<SpriteRenderer>().sprite == pickedSprite)
    {
        images[currentIndex].color = new Color(0, 1, 0, 1); // Change the image color to green
        currentIndex++; // Move to the next object

        if (currentIndex >= receita.GetQuantidade()) // If all objects have been picked in the correct order
        {
            currentIndex = 0; // Reset the index
            Destroy(receita); // Destroy the current recipe
            plateScript.ClearPlate();
            receita = geradorDeReceita.GerarReceitaAleatoria(); // Generate a new random recipe
            pilha.UpdateReceita(receita);
            GenerateElementsOnCanvas(); // Generate a new order
            score.AddScore(100);
            
        }
    }
    else
    {
        currentIndex = 0; // Reset the index
        plateScript.ClearPlate(); // Clear the plate
        Destroy(receita); // Destroy the current recipe
        receita = geradorDeReceita.GerarReceitaAleatoria(); // Generate a new random recipe
        pilha.UpdateReceita(receita);
        GenerateElementsOnCanvas(); // Generate a new order
        lifes.removeLife(1);
      
    }
}

    public void GenerateElementsOnCanvas()
    {
        // Clear the current images
        foreach (Image image in images)
        {
            image.sprite = null;
            image.color = Color.white; // Reset the color to white
        }

        // Generate images based on the recipe
        for (int i = 0; i < receita.GetQuantidade(); i++)
        {
            images[i].sprite = receita.ingredients[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
}