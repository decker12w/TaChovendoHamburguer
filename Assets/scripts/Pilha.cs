using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

     public class Pilha : MonoBehaviour
     {
         [SerializeField]
         public GeradorDeReceita geradorDeReceita;
         private Receita receita;
         private GameObject[] ingredientes;
         public int topo;

            void Awake()
    {
                geradorDeReceita = GameObject.FindObjectOfType<GeradorDeReceita>();
    }
        void Start()
        {
            receita = geradorDeReceita.GerarReceitaAleatoria();
            ingredientes = new GameObject[receita.GetQuantidade()];
            topo = -1;
            for (int i = 0; i < receita.GetQuantidade(); i++)
            {
               Debug.Log( receita.ingredients[i] );
            }
        }

         public bool Cheia()
         {
             return topo == (receita.GetQuantidade() - 1) ? true : false;
         }

         public bool Vazia()
         {
             return topo == -1 ? true : false;
         }

         public void Empilha(GameObject i, out bool deuCerto)
         {
             deuCerto = false;
             if (Cheia())
             {
                 return;
             }
             bool temElemento;
             GameObject original = receita.GetIngrediente(topo + 1, out temElemento);
             if (temElemento && original.CompareTag(i.tag))
             {
                 topo += 1;
                 ingredientes[topo] = i;
                 deuCerto = true;
                 Debug.Log("Empilhou");
             }
             else
             {
                 GameObject desempilhado;
                 bool ok;
                 Desempilha(out desempilhado, out ok);
             }
         }

         public void Desempilha(out GameObject i, out bool deuCerto)
         {
             deuCerto = false;
             if (Vazia())
             {
                 i = null;
                 return;
             }
             i = ingredientes[topo];
        
             topo -= 1;
             deuCerto = true;
         }
     }