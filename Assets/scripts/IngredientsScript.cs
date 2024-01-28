//-4.38
//8.38

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientsScript : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private float secondsSpawn = 2f;
    [SerializeField] private float minTrans;
    [SerializeField] private float maxTrans;

    // Lista para armazenar todas as instâncias de ingredientes
    private List<GameObject> ingredientInstances = new List<GameObject>();

    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTrans, maxTrans);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(ingredients[Random.Range(0, ingredients.Length)], position, Quaternion.identity);

            // Adicione a instância à lista
            ingredientInstances.Add(gameObject);

            yield return new WaitForSeconds(secondsSpawn);
        }
    }

    // Método para destruir todas as instâncias de ingredientes
    public void DestroyIngredients()
    {
        foreach (GameObject instance in ingredientInstances)
        {
            Destroy(instance);
        }

        // Limpe a lista
        ingredientInstances.Clear();
    }
}