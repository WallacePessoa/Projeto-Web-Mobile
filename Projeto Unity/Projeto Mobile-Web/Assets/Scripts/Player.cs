using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    float hori;
    float vert;

    public Joystick Joystick;

    public static float FloatScore;
    public float ForçaShark;

    public Text TextScore;
    public Image Painel;
    public Text TextReturn;


    public float speed;
    public float speedRotation;


    Rigidbody2D rb;

    SpriteRenderer sprite;

    int aux = 0;

    Vector2 Colisão;
    bool colidiu = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if(colidiu == true)
        {
            //rb.velocity = Colisão.normalized * ForçaShark;
            rb.AddForce(Colisão.normalized * ForçaShark);
            if (hori != 0 || vert != 0)
                colidiu = false;
        }
        else
        {

            rb.velocity = new Vector2(Joystick.Horizontal, Joystick.Vertical) * speed;
            transform.up = rb.velocity;

            //rb.transform.Rotate(new Vector3(0, 0, -hori)* speedRotation);
        }



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
            colidiu = true;
            Colisão = transform.position - collision.gameObject.transform.position;

            yield return new WaitForSeconds(1f);
  
            print(Colisão);
            


        }

        if (collision.CompareTag("Baleia"))
        {
            sprite.enabled = !sprite.enabled;
            Painel.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            TextReturn.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-36, 32));
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.3f);
            TextReturn.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            Painel.gameObject.SetActive(false);

        }

        yield return null;
    }
}
