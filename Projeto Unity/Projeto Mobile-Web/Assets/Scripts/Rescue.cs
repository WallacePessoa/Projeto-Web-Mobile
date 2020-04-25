using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rescue : MonoBehaviour
{

    public GameObject Animal;
    public GameObject Painel;
    public Text Text;


    void Start()
    {

    }

    
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Player.RConsumiveis >= 10)
            {
                Spawn.AnimaisVivos.Add(Instantiate(Animal, new Vector2(transform.position.x + 3.5f, transform.position.y), transform.rotation));
                Player.FloatScore++;
                Player.RConsumiveis -= 10;
                Destroy(gameObject);
            }
            else
            {
                Painel.SetActive(true);
                Text.text = "You need to collect " + (10 - Player.RConsumiveis) + " recyclables to save the animal " + Animal.name;
                yield return new WaitForSeconds(2f);
                Painel.SetActive(false);
            }

        }

        yield return null;
    }
}
