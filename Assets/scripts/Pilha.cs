using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Pilha : MonoBehaviour
{
    public GeradorDeReceita geradorDeReceita;
    [SerializeField] private Receita receita;
    [SerializeField] private GameObject[] ingredientes;
    public int topo;

    void Awake()
    {
        geradorDeReceita = GameObject.FindObjectOfType<GeradorDeReceita>();
    }

    void Start()
    {
        receita = geradorDeReceita.GetComponent<Receita>();
        ingredientes = new GameObject[receita.GetQuantidade()];
        topo = -1;
        for (int i = 0; i < receita.GetQuantidade(); i++)
        {
            Debug.Log(receita.ingredients[i]);
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
         if (topo + 1 < receita.GetQuantidade())
         {
            bool temElemento;
            GameObject original = receita.GetIngrediente(topo + 1, out temElemento);
            if (temElemento && original.CompareTag(i.tag))
            {
                topo += 1;
                if (topo < ingredientes.Length)
                {
                    ingredientes[topo] = i;
                    deuCerto = true;
                    Debug.Log("Empilhou");
                }
            }
            else
            {
                GameObject desempilhado;
                bool ok;
                Desempilha(out desempilhado, out ok);
            }
         }
    }

    public void UpdateReceita(Receita novaReceita)
    {
        receita = novaReceita;
        ingredientes = new GameObject[receita.GetQuantidade()];
        for (int i = 0; i < receita.GetQuantidade(); i++)
        {
            ingredientes[i] = receita.ingredients[i];
        }
        topo = -1;
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
