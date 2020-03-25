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



    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coletavel"))
        {
            FloatScore++;
            TextScore.text = "Score: " + FloatScore.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Animal"))
        {
            FloatScore--;
            TextScore.text = "Score: " + FloatScore.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Tubarão"))
        {
            rb.AddForce(transform.position - collision.gameObject.transform.position * ForçaShark);
            yield return new WaitForSeconds(1f);
            rb.velocity = Vector2.zero;
        }

        if (collision.CompareTag("Baleia"))
        {
            transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-36, 32));
        }
    }
}
