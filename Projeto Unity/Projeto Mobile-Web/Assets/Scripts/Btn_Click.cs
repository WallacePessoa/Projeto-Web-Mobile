using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Btn_Click : MonoBehaviour {

    public GameObject Painel;
    public Image fadeOut;
    Button btn;

    string Scene;
    private void Start()
    {
        btn = GetComponent<Button>();
    }
    public void Click()
    {
        btn.interactable = false;
        fadeOut.gameObject.SetActive(true);
    }

    public void LoadScene(string scene1)
    {
        Scene = scene1;
        Invoke("Click",0f);
        StartCoroutine(enumerator());

    }

    public IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1);
        Painel.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Scene);
    }
}

