using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    public Transform target1;
    public Transform target2;
    public Transform target3;

    public float smoothing;
    public int customerCount;

    private GameObject currentDrink;
    public Transform targetDrink1;
    public Transform targetDrink2;
    public Transform targetDrink3;

    public bool brewingStation;
    public bool orderingStation;
    public bool coffeeStation;

    private MovementSystem movementSystem;
    private GameManaging gameManaging;
    private DialogueStuff dialogueStuff;
    private Ordering oder;
    
    public Button right;
    public Button left;
    public Button serve;
    public Button firstup;

    public bool make;
    // Start is called before the first frame update
    void Start()
    {
        make = false;
        brewingStation = false;
        coffeeStation = true;
        orderingStation = false;
        customerCount = 0;
        firstup.gameObject.SetActive(false);
        serve.gameObject.SetActive(false);
        gameManaging = GameObject.Find("GameManager").GetComponent<GameManaging>();
        dialogueStuff = GameObject.Find("GameManager").GetComponent<DialogueStuff>();
        oder = GameObject.Find("GameManager").GetComponent<Ordering>();
    }

    // Update is called once per frame

    private void Update()
    {
        currentDrink = GameObject.Find("Potion");
        movementSystem = GameObject.Find("Potion").GetComponent<MovementSystem>();

        if (Input.GetMouseButtonDown(1) && coffeeStation)
        {
            Destroy(GameObject.Find("Potion"));
        }

        if(!gameManaging.tutorial)
        {
            firstup.gameObject.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        if (movementSystem.transfer)
        {
            if (brewingStation)
            {
                serve.gameObject.SetActive(false);
                Vector3 targetPosition = new Vector3(target1.position.x, target1.position.y, -10f);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);

                Vector3 drinkpos = new Vector3(targetDrink3.position.x, targetDrink3.position.y, 0f);
                currentDrink.transform.position = Vector3.Lerp(currentDrink.transform.position, drinkpos, smoothing * Time.deltaTime);


                currentDrink.GetComponent<MovementSystem>().correctForm = GameObject.Find("Potion Placement (1)");
            }

            if (orderingStation)
            {
                serve.gameObject.SetActive(true);

                Vector3 targetPosition = new Vector3(target2.position.x, target2.position.y, -10f);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);

                Vector3 drinkpos = new Vector3(targetDrink2.position.x, targetDrink2.position.y, 0f);
                currentDrink.transform.position = Vector3.Lerp(currentDrink.transform.position, drinkpos, smoothing * Time.deltaTime);


                currentDrink.GetComponent<MovementSystem>().correctForm = GameObject.Find("Potion Placement (2)");
            }

            if (coffeeStation)
            {
                serve.gameObject.SetActive(false);
                Vector3 targetPosition = new Vector3(target3.position.x, target3.position.y, -10f);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);

                Vector3 drinkpos = new Vector3(targetDrink1.position.x, targetDrink1.position.y, 0f);
                currentDrink.transform.position = Vector3.Lerp(currentDrink.transform.position, drinkpos, smoothing * Time.deltaTime);


                currentDrink.GetComponent<MovementSystem>().correctForm = GameObject.Find("Potion Placement");
            }
        }
        else
        {
            //when you accept an order, it will automatically bring you to the coffee room. When the game begins, there will be a mini tutorial.
            //Make the manager the correct drink to continue.

            if (make)
            {
                brewingStation = false;
                coffeeStation = true;
                orderingStation = false;
                serve.gameObject.SetActive(false);
                Vector3 targetPosition = new Vector3(target3.position.x, target3.position.y, -10f);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
            }
        }
    }

    public void LeftClick()
    {
        if (movementSystem.transfer && coffeeStation && !orderingStation && !brewingStation)
        {
            orderingStation = true;
            coffeeStation = false;
        }
        else if (movementSystem.transfer && !orderingStation && !coffeeStation && brewingStation)
        {
            coffeeStation = true;
            brewingStation = false;
        }
    }

    public void RightClick()
    {
        /*if (movementSystem.transfer && coffeeStation && !orderingStation && !brewingStation)
        {
            brewingStation = true;
            coffeeStation = false;
        }
        else*/ if (movementSystem.transfer && orderingStation && !coffeeStation && !brewingStation)
        {
            coffeeStation = true;
            orderingStation = false;
        }
    }

    public void SeverCustomer()
    {
        if (gameManaging.tutorial)
        {
            //check if order is wrong.
            oder.randomOrder();
            if (oder.correct)
            {
                dialogueStuff.tutorialend = 2;
                gameManaging.tutorial = false;
                Destroy(currentDrink);
                /*coffeeStation = true;
                brewingStation = false;
                orderingStation = false;*/
            }
            else
            {
                dialogueStuff.tutorialend = 1;
            }

        }
        else
        {
            customerCount++;
            oder.randomOrder();
            dialogueStuff.yesNo();
            //if good, yay. If bad, bleh
            Destroy(currentDrink);
        }
    }

    public void game()
    {
        //first customer appears
        
        //Debug.Log("Fuck");
        oder.menuNumber = Random.Range(0, 10);
        gameManaging.go = true;
    }
}

