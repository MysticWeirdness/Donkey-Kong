using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    private float startForce = 2f;
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * startForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("DespawnBarrels"))
        {
            Destroy(gameObject);
        }
    }
}
