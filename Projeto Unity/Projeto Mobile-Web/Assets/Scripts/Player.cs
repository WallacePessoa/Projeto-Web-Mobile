using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float hori;
    float vert;
    float FloatScore;
    public float ForçaShark;


    public Text TextScore;


    public float speed;
    public float speedRotation;


    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        rb.velocity = transform.up * vert * speed;

        rb.transform.Rotate(new Vector3(0, 0, -hori)* speedRotation);



    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coletavel"))
        {
            FloatScore++;
            TextScore.text = FloatScore.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Animal"))
        {
            FloatScore--;
            TextScore.text = FloatScore.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Tubarão"))
        {
            rb.AddForce(collision.gameObject.transform.up * ForçaShark);
        }

        if (collision.CompareTag("Baleia"))
        {

        }
    }
}
