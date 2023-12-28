using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class Receita: MonoBehaviour

 {
     [SerializeField] public int quantidade; 
     [SerializeField] public GameObject[] ingredients;

     public void Initialize(int q)
     {
         if (q >= 2 && q <= 5)
         {
             quantidade = q;
         }
         else
         {
             quantidade = 2;
         }

         ingredients = new GameObject[quantidade];
     }


     public void AddIngrediente(GameObject ingrediente, int posicao, out bool temElemento)
     {
         temElemento = false;
         if (posicao >= 0 && posicao < quantidade)
         {
             ingredients[posicao] = ingrediente;
             temElemento = true;
         }
     }

     public GameObject GetIngrediente(int posicao, out bool temElemento)
     {
         temElemento = false;
         GameObject ingrediente = null;
         if (posicao >= 0 && posicao < quantidade)
         {
             ingrediente = ingredients[posicao];
             temElemento = true;
         }
         return ingrediente;
     }

     public int GetQuantidade()
     {
         return quantidade;
     }
 }