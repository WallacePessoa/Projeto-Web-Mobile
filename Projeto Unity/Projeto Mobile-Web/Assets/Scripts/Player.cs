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
    public Text TextReciclaveis;

    public bool bollNadar;
    public bool bollMobile;

    public float NadarSpeed;
    public float speed;
    public float speedRotation;

    bool Nadando;
    bool MobileOrPc = false;


    Rigidbody2D rb;

    SpriteRenderer sprite;

    int aux = 0;
    public static int RConsumiveis = 0;

    Vector2 Colisão;
    bool colidiu = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (bollMobile)
            StartCoroutine(Mobile());
        else
            StartCoroutine(PC());

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
            MobileOrPc = true;
        }
        else
        {
            if (bollMobile && MobileOrPc)
            {
                StartCoroutine(Mobile());
                MobileOrPc = false;
            }
            else if(!bollMobile && MobileOrPc)
            {
                StartCoroutine(PC());
                MobileOrPc = false;
            }

            if (bollMobile)
            {
                transform.up = rb.velocity;
            }


        }

        TextReciclaveis.text = "collected recyclables: " + RConsumiveis.ToString();

    }

    public IEnumerator Mobile()
    {
        if (bollNadar)
        {
            rb.drag = 4f;
            NadarSpeed = 300;
            if (Input.touchCount > 1 && !Nadando)
            {
                Nadando = true;
                rb.AddForce(new Vector2(Joystick.Horizontal, Joystick.Vertical) * NadarSpeed);


            }
            else
            {
                Nadando = false;

                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            rb.drag = 10f;
            print("aqui");
            rb.velocity = new Vector2(Joystick.Horizontal, Joystick.Vertical) * speed;
            transform.up = rb.velocity;
        }
        yield return null;
        StartCoroutine(Mobile());
    }

    public IEnumerator PC()
    {

        if (bollNadar)
        {
            rb.drag = 4f;
            NadarSpeed = 1000;
            if (Input.GetKey(KeyCode.P) && !Nadando)
            {
                Nadando = true;
                rb.AddForce(transform.up * NadarSpeed);
            }
            else
            {
                Nadando = false;
                yield return new WaitForSeconds(0.1f);
            }

        }
        else
        {
            rb.drag = 10f;
            rb.velocity = transform.up * vert * speed;
        }


        rb.transform.Rotate(new Vector3(0, 0, -hori) * speedRotation);


        yield return null;
        StartCoroutine(PC());

    }



    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coletavel"))
        {
            FloatScore++;
            TextScore.text = "Score: " + FloatScore.ToString();
            RConsumiveis += Random.Range(1, 5);
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
