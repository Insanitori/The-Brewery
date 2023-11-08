using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMaking : MonoBehaviour
{
    private SpriteRenderer mainDrink;
    private Color gottaSip;

    public int milk, Caff, Decaf, Cream, pump, Carm, Vanilla, Sugar, Ice;
    private int mill, CA, DE, cre, kin, mm, Vill, Sweet, nice;

    public List<string> order = new List<string>();

    /*Color Manager
    public float r;
    public float g;
    public float b;
    public float a;*/

    /* Drink Colors
     Caffinated = 0.3, 0.2, 0.1, 1
     Decaffinated = 0.36, 0.2, 0.1, 1
    Cream = 1, 1, 0.7, 1
    Milk = 1, 1, 1, 1
    Pumpkin = 1, 0.4, 0.1, 1
    Caramel = 0.74, 0.26, 0.21,1  
    Vanilla = 1, 0.7, 0.2, 1
     */

    // This is for combining the drinks and stuff
    void Start()
    {
        mainDrink = GetComponent<SpriteRenderer>();
        gottaSip = Color.white;

        milk = 0;
        Caff = 0;
        Decaf = 0;
        Cream = 0;
        pump = 0;
        Carm = 0;
        Vanilla = 0;
        Sugar = 0;
        Ice = 0;

        mill = 1;
        CA = 1;
        DE = 1;
        cre = 1;
        kin = 1;
        mm = 1;
        Vill = 1;
        Sweet = 1;
        nice = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Coffee Types
        if (Caff == CA)
        {
            if (milk <= 0 && Cream <= 0 && pump <= 0 && Carm <= 0 && Vanilla <= 0)
            {
                gottaSip = new Color(0.3f, 0.2f, 0.1f, 1);
                CA++;
            }
            else
            {
                gottaSip = (gottaSip + new Color(0.3f, 0.2f, 0.1f, 1)) / 2;
                CA++;
            }
        }

        if (Decaf == DE)
        {
            if (milk <= 0 && Cream <= 0 && pump <= 0 && Carm <= 0 && Vanilla <= 0)
            {
                gottaSip = new Color(0.36f, 0.2f, 0.1f, 1);
                DE++;
            }
            else
            {
                gottaSip = (gottaSip + new Color(0.36f, 0.2f, 0.1f, 1)) / 2;
                DE++;
            }
        }

        //Coffee Ingredients 

        if (milk == mill)
        {
            gottaSip = (gottaSip + new Color(1, 1, 1, 1)) / 2;
            mill++;
        }

        if (Cream == cre)
        {
            gottaSip = (gottaSip + new Color(1, 1, 0.7f, 1)) / 2;
            cre++;
        }

        if (pump == kin)
        {
            gottaSip = (gottaSip + new Color(1, 0.4f, 0.1f, 1)) / 2;
            kin++;
        }

        if (Carm == mm)
        {
            gottaSip = (gottaSip + new Color(0.74f, 0.26f, 0.21f, 1)) / 2;
            mm++;
        }

        if (Vanilla == Vill)
        {
            gottaSip = (gottaSip + new Color(1, 0.7f, 0.2f, 1)) / 2;
            Vill++;
        }

        if (Sugar == Sweet)
        {
            //Sugar sound, like sand or something
            Sweet++;
        }

        if (Ice == nice)
        {
            //ice sounds Falling into glass cup
            nice++;
        }


        //Drink itself
        mainDrink.color = gottaSip;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Milk" && (GameObject.Find("Milk").GetComponent<MovementSystem>().moving == false))
        {
            milk++;
            order.Add("Milk");
            Debug.Log("Milk" + milk);
        }

        if (collision.gameObject.name == "Caffinated" && (GameObject.Find("Caffinated").GetComponent<MovementSystem>().moving == false))
        {
            Caff++;
            order.Add("Caffinated");
            Debug.Log("Caffinated" + Caff);
        }

        if (collision.gameObject.name == "Decaffinated" && (GameObject.Find("Decaffinated").GetComponent<MovementSystem>().moving == false))
        {
            Decaf++;
            order.Add("Decaffinated");
            Debug.Log("Decaffinated" + Decaf);
        }

        if (collision.gameObject.name == "Cream" && (GameObject.Find("Cream").GetComponent<MovementSystem>().moving == false))
        {
            Cream++;
            order.Add("Cream");
            Debug.Log("Cream" + Cream);
        }

        if (collision.gameObject.name == "Vanilla" && (GameObject.Find("Vanilla").GetComponent<MovementSystem>().moving == false))
        {
            Vanilla++;
            order.Add("Vanilla");
            Debug.Log("Vanilla" + Vanilla);
        }

        if (collision.gameObject.name == "Caramel" && (GameObject.Find("Caramel").GetComponent<MovementSystem>().moving == false))
        {
            Carm++;
            order.Add("Caramel");
            Debug.Log("Caramel" + Carm);
        }

        if (collision.gameObject.name == "Pumpkin" && (GameObject.Find("Pumpkin").GetComponent<MovementSystem>().moving == false))
        {
            pump++;
            order.Add("Pumpkin");
            Debug.Log("Pumpkin" + pump);
        }

        if (collision.gameObject.name == "Sugar" && (GameObject.Find("Sugar").GetComponent<MovementSystem>().moving == false))
        {
            Sugar++;
            order.Add("Sugar");
            Debug.Log("Sugar" + Sugar);
        }

        if (collision.gameObject.name == "Ice" && (GameObject.Find("Ice").GetComponent<MovementSystem>().moving == false))
        {
            Ice++;
            order.Add("Ice");
            Debug.Log("Ice" + Ice);
        }
    }

}
