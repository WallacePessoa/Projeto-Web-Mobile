using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour
{
    public float Speed;

    Rigidbody2D rb;

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, target) < 2f)
        {
            target = new Vector2(Random.Range(-50, 50), Random.Range(-36, 32));
        }
        rb.velocity = transform.position * Speed;



    }
}
