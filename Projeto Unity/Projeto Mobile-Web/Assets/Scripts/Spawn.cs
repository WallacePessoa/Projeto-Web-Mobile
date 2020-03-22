using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Animais;
    public GameObject[] Reciclaveis;

    public float Contagem;

    void Start()
    {
        StartCoroutine(Contar());
        StartCoroutine(Spawnar());
    }

    // Update is called once per frame
    void Update()
    {
        if (Contagem < 1)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator Contar()
    {
        if(Random.Range(0,2) == 0)
        {
            Instantiate(Animais[Random.Range(0, Animais.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-36, 33),1), transform.rotation);
        }
        else
        {
            Instantiate(Reciclaveis[Random.Range(0, Reciclaveis.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-36, 33),1), transform.rotation);
        }

        yield return new WaitForSeconds(Contagem);

        StartCoroutine(Contar());
    }

    private IEnumerator Spawnar()
    {
        yield return new WaitForSeconds(5f);
        Contagem -= 0.5f;
        StartCoroutine(Spawnar());
    }
}
