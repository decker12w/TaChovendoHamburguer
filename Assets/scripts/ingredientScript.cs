using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientScript : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D collision)
{
    if (groundLayer == (groundLayer | (1 << collision.gameObject.layer)))
    {
        Destroy(gameObject);
    }

    else if (collision.gameObject.CompareTag("plate"))
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.transform.position = collision.transform.position;
        Console.WriteLine("Colidiu com o prato");
    }
}
}