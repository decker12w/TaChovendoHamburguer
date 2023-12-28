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


    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

   IEnumerator FruitSpawn(){
    while(true){
        var wanted = Random.Range(minTrans,maxTrans);
        var position = new Vector3(wanted,transform.position.y);
        GameObject gameObject = Instantiate(ingredients[Random.Range(0,ingredients.Length)],position,Quaternion.identity);
        yield return new WaitForSeconds(secondsSpawn);
    }
   }

    
}
