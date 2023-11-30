using UnityEngine;
using UnityEngine.UI;

public class woodScript : MonoBehaviour
{
    public GameObject[] ObjectArray;
    public Image[] images;
    private Sprite[] spriteOrder;
    private int currentIndex = 0;

    private PlateScript plateScript;

    void Start()
    {
        GenerateElementsOnCanvas();

        plateScript = GameObject.FindObjectOfType<PlateScript>();
    }

    public void OnObjectPicked(GameObject pickedObject)
    {
        Sprite pickedSprite = pickedObject.GetComponent<SpriteRenderer>().sprite;

        if (spriteOrder[currentIndex] == pickedSprite)
        {
            images[currentIndex].color = new Color(0, 1, 0, 1); // Change the image color to green
            currentIndex++; // Move to the next object

            if (currentIndex >= spriteOrder.Length) // If all objects have been picked in the correct order
            {
                currentIndex = 0; // Reset the index
                GenerateElementsOnCanvas(); // Generate a new order
            }
        }
        else
        {
            currentIndex = 0; // Reset the index
            plateScript.ClearPlate(); // Clear the plate
            GenerateElementsOnCanvas(); // Generate a new order
        }
    }

    public void GenerateElementsOnCanvas()
    {
        spriteOrder = new Sprite[images.Length];

        for (int i = 0; i < images.Length; i++)
        {
            int random = Random.Range(0, ObjectArray.Length);
            Sprite sprite = ObjectArray[random].GetComponent<SpriteRenderer>().sprite;
            images[i].sprite = sprite;
            spriteOrder[i] = sprite;
            images[i].color = new Color(1, 1, 1, 1); // Reset the image color to white
        }
    }
}