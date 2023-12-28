using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] private Pilha pilha;
    private float ingredientHeight = 0.1f; // Adjust this value based on the size of your ingredients
    private woodScript woodScript;

    void Start()
    {
        woodScript = GameObject.FindObjectOfType<woodScript>();
        Pilha pilha = gameObject.GetComponent<Pilha>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            bool deuCerto;
            pilha.Empilha(collision.gameObject, out deuCerto);
            if (deuCerto)
            {
                collision.transform.position = new Vector2(transform.position.x, transform.position.y + (pilha.topo + 1) * ingredientHeight);
                collision.transform.SetParent(transform); // Parent the ingredient to the plate
                collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true; // Set the ingredient's Rigidbody2D to kinematic
                woodScript.OnObjectPicked(collision.gameObject);
                Debug.Log(collision.gameObject.name);
            }
        }
    }

    public void ClearPlate()
    {
        GameObject desempilhado;
        bool deuCerto;
        while (!pilha.Vazia())
        {
            pilha.Desempilha(out desempilhado, out deuCerto);
            if (deuCerto)
            {
                Destroy(desempilhado);
            }
        }
    }
}
// public class PlateScript : MonoBehaviour
// {
//     [SerializeField] private List<GameObject> ingredients = new List<GameObject>();
//     private float ingredientHeight = 0.1f; // Adjust this value based on the size of your ingredients
//     private woodScript woodScript;
// void Start()
// {
//     woodScript = GameObject.FindObjectOfType<woodScript>();
// }
// public void OnTriggerEnter2D(Collider2D collision)
// {
//     if (collision.gameObject.CompareTag("food"))
//     {

//         ingredients.Add(collision.gameObject);
//         collision.transform.position = new Vector2(transform.position.x, transform.position.y + ingredients.Count * ingredientHeight);
//         collision.transform.SetParent(transform); // Parent the ingredient to the plate
//         collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true; // Set the ingredient's Rigidbody2D to kinematic
//         woodScript.OnObjectPicked(collision.gameObject);
//     }
// }

// public void ClearPlate()
// {
//     foreach (GameObject ingredient in ingredients)
//     {
//         Destroy(ingredient);
//     }
//     ingredients.Clear();
// }
// }