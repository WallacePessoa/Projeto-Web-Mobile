using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject[] Animais;
    public GameObject Regate;
    public GameObject[] Reciclaveis;

    public List<GameObject> ReciclaveisAtivos = new List<GameObject>();
    public static List<GameObject> AnimaisVivos = new List<GameObject>();

    public Text Lixo;
    public Image PainelVitoria;
    public Image PainelDerrota;
    public Button Back;

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

        if(AnimaisVivos.Count/4 > ReciclaveisAtivos.Count && Contagem < 2)
        {
            Time.timeScale = 0;
            PainelVitoria.gameObject.SetActive(true);
            Back.gameObject.SetActive(true);

        }else if(AnimaisVivos.Count < ReciclaveisAtivos.Count/4 && Contagem < 2)
        {

            Time.timeScale = 0;
            Back.gameObject.SetActive(true);
            PainelDerrota.gameObject.SetActive(true);

        }

        Lixo.text = "Recicláveis: " + ReciclaveisAtivos.Count.ToString();

        if (ReciclaveisAtivos.Contains(Player.ColetDestroy))
        {
            ReciclaveisAtivos.Remove(Player.ColetDestroy);
        }

        //foreach(GameObject game in ReciclaveisAtivos)
        //{
        //    if(game == null)
        //    {
        //        ReciclaveisAtivos.Remove(game);
        //    }
        //}

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
            if ((AnimaisVivos.Count / 2) >= ReciclaveisAtivos.Count)
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
        yield return new WaitForSeconds(10f);
        Contagem -= 0.5f;

        if(Random.Range(0,2) == 0)
        {
            Instantiate(Regate, new Vector3(Random.Range(-50, 50), Random.Range(-36, 33), 1), transform.rotation);
        }

        StartCoroutine(Spawnar());
    }
}
