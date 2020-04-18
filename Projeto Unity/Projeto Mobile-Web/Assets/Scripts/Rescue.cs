using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{

    public GameObject Animal;



    void Start()
    {

    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("aaa");
            Spawn.AnimaisVivos.Add(Instantiate(Animal, new Vector2(transform.position.x + 3.5f, transform.position.y), transform.rotation));
            Player.FloatScore++;
            Destroy(gameObject);
        }
    }
}
