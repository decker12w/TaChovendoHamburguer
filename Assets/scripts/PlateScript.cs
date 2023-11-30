using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> ingredients = new List<GameObject>();
    private float ingredientHeight = 0.1f; // Adjust this value based on the size of your ingredients
    private woodScript woodScript;
void Start()
{
    woodScript = GameObject.FindObjectOfType<woodScript>();
}
public void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("food"))
    {

        ingredients.Add(collision.gameObject);
        collision.transform.position = new Vector2(transform.position.x, transform.position.y + ingredients.Count * ingredientHeight);
        collision.transform.SetParent(transform); // Parent the ingredient to the plate
        collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true; // Set the ingredient's Rigidbody2D to kinematic
        woodScript.OnObjectPicked(collision.gameObject);
    }
}

public void ClearPlate()
{
    foreach (GameObject ingredient in ingredients)
    {
        Destroy(ingredient);
    }
    ingredients.Clear();
}
}