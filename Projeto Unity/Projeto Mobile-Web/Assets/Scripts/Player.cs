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

    int aux = 0;


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

        //if(vert == 0 && hori == 0)
        //{
        //    rb.velocity = Vector2.zero;
        //    rb.transform.Rotate(Vector3.Lerp(Vector3.zero, transform.rotation.eulerAngles, 1f * Time.deltaTime));
        //}
       
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


            //while(transform.rotation.eulerAngles.z > Vector3.zero.z + 10 || transform.rotation.eulerAngles.z > Vector3.zero.z - 10)
            //{
            //    yield return new WaitForSeconds(0.01f);
            //    rb.transform.Rotate(Vector3.Lerp(Vector3.zero, transform.rotation.eulerAngles, 0.01f * Time.deltaTime));

            //    if (aux > 500)
            //    {
            //        print("Parou");
            //        aux = 0;
            //        rb.velocity = Vector3.zero;
                    

            //        break;

            //    }

            //    if(vert != 0)
            //    {
            //        rb.velocity = Vector3.zero;


            //        break;
            //    }

   
            //    aux++;
            //}

        }

        if (collision.CompareTag("Baleia"))
        {
            transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-36, 32));
        }

        yield return null;
    }
}
