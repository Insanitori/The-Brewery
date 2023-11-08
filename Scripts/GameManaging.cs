using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManaging : MonoBehaviour
{
    public GameObject SugarPrefab, CaffPrefab, DecafPrefab, MilkPrefab, CreamPrefab, IcePrefab, VanillaPrefab, PumpkinPrefab, CaramelPrefab, PotionPrefab;
    private Transform SugarSpot, CafSpot, DecafSpot, MilkSpot, CreamSpot, IceSpot, VanillaSpot, PumpkinSpot, CaramelSpot, PotionSpot;
    public Transform customerSpot;
    public TextMeshProUGUI namming;

    public int peoplepicker;

    public bool tutorial;
    public bool go;
    public GameObject shit;
    public bool delay;

    private DialogueStuff dialogueStuff;
    // Start is called before the first frame update
    void Start()
    {
        //coffee spots
        SugarSpot = GameObject.Find("sugar (1)").transform;
        CafSpot = GameObject.Find("Caffinated (1)").transform;
        DecafSpot = GameObject.Find("Decaffinated (1)").transform;
        MilkSpot = GameObject.Find("Milk (1)").transform;
        CreamSpot = GameObject.Find("Cream (1)").transform;
        IceSpot = GameObject.Find("ice (1)").transform;
        VanillaSpot = GameObject.Find("Vanilla (1)").transform;
        PumpkinSpot = GameObject.Find("pumpkin (1)").transform;
        CaramelSpot = GameObject.Find("Caramel (1)").transform;
        PotionSpot = GameObject.Find("Potion (1)").transform;
        
        dialogueStuff = GetComponent<DialogueStuff>();

        peoplepicker = 0;

        tutorial = true;
        go = false;
        delay = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Monster") == null && go && delay)
        {
            //Debug.Log("This is doing things");
            shit.SetActive(false);
            people();
            delay = false;
        }

        if (GameObject.Find("Sugar") == null)
        {
            GameObject Sugar = Instantiate(SugarPrefab, SugarSpot.position, transform.rotation);
            Sugar.gameObject.name = ("Sugar");
        }

        if (GameObject.Find("Caffinated") == null)
        {
            GameObject Caff = Instantiate(CaffPrefab, CafSpot.position, transform.rotation);
            Caff.gameObject.name = ("Caffinated");
        }

        if (GameObject.Find("Decaffinated") == null)
        {
            GameObject Decaf = Instantiate(DecafPrefab, DecafSpot.position, transform.rotation);
            Decaf.gameObject.name = ("Decaffinated");
        }

        if (GameObject.Find("Cream") == null)
        {
            GameObject Cre = Instantiate(CreamPrefab, CreamSpot.position, transform.rotation);
            Cre.gameObject.name = ("Cream");
        }

        if (GameObject.Find("Milk") == null)
        {
            GameObject Mil = Instantiate(MilkPrefab, MilkSpot.position, transform.rotation);
            Mil.gameObject.name = ("Milk");
        }

        if (GameObject.Find("Ice") == null)
        {
            GameObject i = Instantiate(IcePrefab, IceSpot.position, transform.rotation);
            i.gameObject.name = ("Ice");
        }

        if (GameObject.Find("Vanilla") == null)
        {
            GameObject Nilla = Instantiate(VanillaPrefab, VanillaSpot.position, transform.rotation);
            Nilla.gameObject.name = ("Vanilla");
        }

        if (GameObject.Find("Pumpkin") == null)
        {
            GameObject Pump = Instantiate(PumpkinPrefab, PumpkinSpot.position, transform.rotation);
            Pump.gameObject.name = ("Pumpkin");
        }

        if (GameObject.Find("Caramel") == null)
        {
            GameObject Mel = Instantiate(CaramelPrefab, CaramelSpot.position, transform.rotation);
            Mel.gameObject.name = ("Caramel");
        }

        if (GameObject.Find("Potion") == null)
        {
            GameObject pot = Instantiate(PotionPrefab, PotionSpot.position, transform.rotation);
            pot.gameObject.name = ("Potion");
        }
    }

    public void people()
    {
        //when it opens, then characters start arriving.
        GameObject Mon;

        peoplepicker = Random.Range(1, 5);
        if (peoplepicker == 1)
        {
            Mon = Instantiate(GameObject.Find("Person 1"), customerSpot.position, transform.rotation);
            Mon.gameObject.name = ("Customer");
            Mon.gameObject.tag = ("Monster");
            namming.text = Mon.gameObject.name;

            peoplepicker = 0;

        }
        else if (peoplepicker == 2)
        {
            Mon = Instantiate(GameObject.Find("Person 2"), customerSpot.position, transform.rotation);
            Mon.gameObject.name = ("Creature");
            Mon.gameObject.tag = ("Monster");
            namming.text = Mon.gameObject.name;
            peoplepicker = 0;
        }
        else if (peoplepicker == 3)
        {
            Mon = Instantiate(GameObject.Find("Person 3"), customerSpot.position, transform.rotation);
            Mon.gameObject.name = ("Someone");
            Mon.gameObject.tag = ("Monster");
            namming.text = Mon.gameObject.name;
            peoplepicker = 0;
        }
        else if (peoplepicker == 4)
        {
            Mon = Instantiate(GameObject.Find("Person 4"), customerSpot.position, transform.rotation);
            Mon.gameObject.name = ("Buyer");
            Mon.gameObject.tag = ("Monster");
            namming.text = Mon.gameObject.name;
            peoplepicker = 0;
        }

        dialogueStuff.choosing();
    }
}
