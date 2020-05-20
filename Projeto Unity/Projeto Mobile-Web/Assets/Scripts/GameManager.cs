using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text Conversa;
    public Image Painel;
    public string[] Textos;
    public Text TextButon;
    public Rank rank;

    int auxTexto = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()

    {
        Painel.gameObject.SetActive(true);
        Conversa.gameObject.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(Historia());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHirtoria()
    {
        StartCoroutine(Historia());
    }

    public void LoadScene(string cena)
    {

        rank.Score.Add(Player.FloatScore);
        SceneManager.LoadScene(cena);
        
    }

    public IEnumerator Historia()
    {

        if (auxTexto == Textos.Length)
        {
            Painel.gameObject.SetActive(false);
            Conversa.gameObject.SetActive(false);

            Time.timeScale = 1;
        }
        else
        {
            Conversa.text = Textos[auxTexto];
            auxTexto++;
            print(auxTexto);

            TextButon.gameObject.SetActive(true);
        }


        


        yield return null;
    }
}
