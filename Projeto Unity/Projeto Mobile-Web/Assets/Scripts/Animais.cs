using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animais : MonoBehaviour
{
    public float Speed;
    public float SpeedShark;
    public float SpeedBaleia;
    public Vector2 target = Vector2.zero;

    public Transform[] Nodes;

    float SpeedAtual;

    Rigidbody2D rb;

    GameObject Player;

    public enum StateMachine
    {
        Nadar,
        Atack,
        Fugir
    }

    public StateMachine State;
    

    public enum Animal
    {
        Tartaruga,
        Tubarão,
        Baleia,
        Peixe
    }
    public Animal animal;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        SpeedAtual = Speed;
        target = (Vector2)transform.position - new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
    }

    // Update is called once per frame
    void Update()
    {
        switch (animal)
        {
            case Animal.Tartaruga:

                transform.up = Vector3.Lerp(transform.up, target - (Vector2)transform.position, 1 * Time.deltaTime);

                if (Vector2.Distance(transform.position, target) < 2f)
                    target = new Vector2(Random.Range(-50, 50), Random.Range(-36, 32));

                rb.velocity = transform.up * Speed;

                break;

            case Animal.Tubarão:


                switch (State)
                {

                    case StateMachine.Nadar:

                        transform.up = Vector3.Lerp(transform.up, target - (Vector2)transform.position, 1 * Time.deltaTime);
                        if (Vector2.Distance(transform.position, target) < 2f)
                            target = new Vector2(Random.Range(-50, 50), Random.Range(-36, 32));

                        rb.velocity = transform.up * SpeedAtual;

                        if (SpeedAtual > Speed)
                            SpeedAtual -= 0.1f;

                        if (Vector2.Distance(Player.transform.position, transform.position) < 10)
                            State = StateMachine.Atack;

                        break;

                    case StateMachine.Atack:

                        transform.up = Vector3.Lerp(transform.up, target - (Vector2)transform.position, 10f * Time.deltaTime);
                        target = Player.transform.position;

                        if (SpeedAtual < SpeedShark)
                            SpeedAtual += 0.1f;

                        rb.velocity = transform.up * SpeedAtual;

                        if (Vector2.Distance(Player.transform.position, transform.position) > 10)
                            State = StateMachine.Nadar;

                        break;

                    case StateMachine.Fugir:


                        transform.up = Vector3.Lerp(transform.up, (Vector2)transform.position - target, 1 * Time.deltaTime);
                        target = Player.transform.position;

                        if (SpeedAtual > Speed)
                            SpeedAtual -= 0.1f;

                        rb.velocity = transform.up * SpeedAtual;

                        break;
                }

                break;

            case Animal.Baleia:

                switch (State)
                {

                    case StateMachine.Nadar:

                        transform.up = Vector3.Lerp(transform.up, target - (Vector2)transform.position, 1 * Time.deltaTime);
                        if (Vector2.Distance(transform.position, target) < 2f)
                            target = new Vector2(Random.Range(-50, 50), Random.Range(-36, 32));

                        rb.velocity = transform.up * SpeedAtual;

                        if (SpeedAtual > Speed)
                            SpeedAtual -= 0.1f;

                        if (Vector2.Distance(Player.transform.position, transform.position) < 10)
                            State = StateMachine.Atack;

                        break;

                    case StateMachine.Atack:

                        transform.up = Vector3.Lerp(transform.up, target - (Vector2)transform.position,0.5f * Time.deltaTime);
                        target = Player.transform.position;

                        if (SpeedAtual < SpeedBaleia)
                            SpeedAtual += 0.1f;

                        rb.velocity = transform.up * SpeedAtual;

                        if (Vector2.Distance(Player.transform.position, transform.position) > 10)
                            State = StateMachine.Nadar;

                        break;

                    case StateMachine.Fugir:


                        transform.up = Vector3.Lerp(transform.up, (Vector2)transform.position - target, 1 * Time.deltaTime);
                        target = Player.transform.position;

                        if (SpeedAtual > Speed)
                            SpeedAtual -= 0.1f;

                        rb.velocity = transform.up * SpeedAtual;

                        break;
                }

                break;
        }



    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(target, Vector2.one);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            State = StateMachine.Fugir;
            print("aaaaaa");

            yield return new WaitForSeconds(7f);

            State = StateMachine.Nadar;
        }
    }

}
