using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject[] Animais;
    public GameObject[] Reciclaveis;
    public Text Lixo;

    public float Contagem;

    public List<GameObject> ReciclaveisAtivos = new List<GameObject>();
    public List<GameObject> AnimaisVivos = new List<GameObject>();

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

        Lixo.text = "Reciclaveis: " + ReciclaveisAtivos.Count.ToString();

        foreach(GameObject game in ReciclaveisAtivos)
        {
            if(game == null)
            {
                ReciclaveisAtivos.Remove(game);
            }
        }

        foreach (GameObject game in AnimaisVivos)
        {
            if (game == null)
            {
                ReciclaveisAtivos.Remove(game);
            }
        }
    }

    private IEnumerator Contar()
    {
        if(AnimaisVivos.Count != 0 && ReciclaveisAtivos.Count != 0)
        {
            if ((AnimaisVivos.Count / 2) > ReciclaveisAtivos.Count)
            {
                ReciclaveisAtivos.Add(Instantiate(Reciclaveis[Random.Range(0, Reciclaveis.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-36, 33), 1), transform.rotation));
            }
            else if (AnimaisVivos.Count < (3 / ReciclaveisAtivos.Count))
            {
                AnimaisVivos.Add(Instantiate(Animais[Random.Range(0, Animais.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-36, 33), 1), transform.rotation));
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    AnimaisVivos.Add(Instantiate(Animais[Random.Range(0, Animais.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-36, 33), 1), transform.rotation));
                }
                else
                {
                    ReciclaveisAtivos.Add(Instantiate(Reciclaveis[Random.Range(0, Reciclaveis.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-36, 33), 1), transform.rotation));
                }
            }
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                AnimaisVivos.Add(Instantiate(Animais[Random.Range(0, Animais.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-36, 33), 1), transform.rotation));
            }
            else
            {
                ReciclaveisAtivos.Add(Instantiate(Reciclaveis[Random.Range(0, Reciclaveis.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-36, 33), 1), transform.rotation));
            }
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
