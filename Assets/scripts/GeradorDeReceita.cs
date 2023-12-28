 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class GeradorDeReceita : MonoBehaviour
 {
     [SerializeField] private GameObject[] ingredientesPossiveis;
     [SerializeField] private int minIngredientes = 2;
     [SerializeField] private int maxIngredientes = 5;

     [SerializeField] public Receita receita;

     public Receita GerarReceitaAleatoria()
     {
         int quantidade = Random.Range(minIngredientes, maxIngredientes + 1);
         Receita receita = gameObject.AddComponent<Receita>();
         receita.Initialize(quantidade);

         for (int i = 0; i < quantidade; i++)
         {
             GameObject ingredienteAleatorio = ingredientesPossiveis[Random.Range(0, ingredientesPossiveis.Length)];
             bool temElemento;
             receita.AddIngrediente(ingredienteAleatorio, i, out temElemento);
         }

         return receita;
        
     }
 }