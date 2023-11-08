using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ordering : MonoBehaviour
{
    private DrinkMaking drinkMaking;
    private GameManaging gameManaging;
    private bool request;

    public int menuNumber;

    public bool correct;
    // Start is called before the first frame update
    void Start()
    {
        gameManaging = GameObject.Find("GameManager").GetComponent<GameManaging>();
        menuNumber = Random.Range(0, 10); 
        Debug.Log(menuNumber);

        correct = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Starting squence
        if (gameManaging.tutorial)
        {
            menuNumber = 0;
        }

        //9 customers in a day
        drinkMaking = GameObject.Find("Potion").GetComponent<DrinkMaking>();

        /*if(gameObject.tag == "Human")
        {
            //add switch case for different drinks. This is just an example
            if (request)
            {
                menuNumber = Random.Range(0, 10);
                randomOrder();

                request = false;
            }
            
        }*/

    }

    public void randomOrder()
    {
        //add switchcase here. About 20
        switch (menuNumber)
        {
            case 0:
                icecoffee();
                break;
            case 1:
                PumpkinIce();
                break;
            case 2:
                HotCoffee();
                break;
            case 3:
                DecafBlack();
                break;
            case 4:
                CaffBlack();
                break;
            case 5:
                CaramelIce();
                break;
            case 6:
                VanillaDark();
                break;
            case 7:
                justMilk();
                break;
            case 8:
                CaffDecaff();
                break;
            case 9:
                everythingCoffee();
                break;

            default: 
                break;
        }
    }

    public void icecoffee () //0
    {
        //Contains: Caffinated, Milk, sugar, ice
        if (drinkMaking.order.Contains("Caffinated"))
        {
            //move on
            if(drinkMaking.order.Contains("Milk"))
            {
                //continue
                if(drinkMaking.order.Contains("Sugar"))
                {
                    //contiue
                    if(drinkMaking.order.Contains("Ice"))
                    {
                        correct = true;
                        Debug.Log("Correct");
                    }
                    else if (!drinkMaking.order.Contains("Ice"))
                    {
                        //wrong
                        correct = false;
                        Debug.Log("Wrong");
                    }
                }
                else if(!drinkMaking.order.Contains("Sugar"))
                {
                    //wrong
                    correct = false;
                    Debug.Log(message: "Wrong");
                }
            }
            else if (!drinkMaking.order.Contains("Milk"))
            {
                //wrong
                correct = false;
                Debug.Log("Wrong");
            }
        }
        else if (!drinkMaking.order.Contains("Caffinated") || drinkMaking.order.Contains("Decaffinated"))
        {
            Debug.Log("Wrong");
            correct = false;
            //wrong
        }

        if(drinkMaking.order.Contains("Cream") || drinkMaking.order.Contains("Caramel") || drinkMaking.order.Contains("Pumpkin") || drinkMaking.order.Contains("Vanilla"))
        {
            //wrong
            correct = false;
            Debug.Log("Wrong");
        }

        //if statement that checks if there's potion ingredients as well. Super wrong or mission purposes
    }

    public void PumpkinIce() //1
    {
        //Contains: Caffinated, cream, sugar, pumpkin, ice
        if (drinkMaking.order.Contains("Caffinated"))
        {
            //move on
            if (drinkMaking.order.Contains("Cream"))
            {
                //continue
                if (drinkMaking.order.Contains("Sugar"))
                {
                    //contiue
                    if (drinkMaking.order.Contains("Ice"))
                    {
                        //continue
                        if (drinkMaking.order.Contains("Pumpkin"))
                        {
                            //right
                            correct = true;
                            Debug.Log("Correct");
                        }
                        else if (!drinkMaking.order.Contains("Pumpkin"))
                        {
                            correct = false;
                            Debug.Log("Wrong");
                        }
                    }
                    else if (!drinkMaking.order.Contains("Ice"))
                    {
                        //wrong
                        correct = false;
                        Debug.Log("Wrong");
                    }
                }
                else if (!drinkMaking.order.Contains("Sugar"))
                {
                    //wrong
                    correct = false;
                    Debug.Log("Wrong");
                }
            }
            else if (!drinkMaking.order.Contains("Cream"))
            {
                //wrong
                correct = false;
                Debug.Log("Wrong");
            }
        }
        else if (!drinkMaking.order.Contains("Caffinated") || drinkMaking.order.Contains("Decaffinated"))
        {
            Debug.Log("Wrong");
            correct = false;
            //wrong
        }

        if (drinkMaking.order.Contains("Milk") || drinkMaking.order.Contains("Caramel") || drinkMaking.order.Contains("Vanilla"))
        {
            //wrong
            correct = false;
            Debug.Log("Wrong");
        }

        //if statement that checks if there's potion ingredients as well. Super wrong or mission purposes
    }

    public void HotCoffee() //2
    {
        //Contains: Caffinated, Cream, sugar
        if (drinkMaking.order.Contains("Caffinated"))
        {
            //move on
            if (drinkMaking.order.Contains("Cream"))
            {
                //continue
                if (drinkMaking.order.Contains("Sugar"))
                {
                    //right
                    correct = true;
                    Debug.Log("Correct");
                }
                else if (!drinkMaking.order.Contains("Sugar"))
                {
                    //wrong
                    correct = false;
                    Debug.Log("Wrong");
                }
            }
            else if (!drinkMaking.order.Contains("Cream"))
            {
                //wrong
                correct = false;
                Debug.Log("Wrong");
            }
        }
        else if (!drinkMaking.order.Contains("Caffinated") || drinkMaking.order.Contains("Decaffinated"))
        {
            Debug.Log("Wrong");
            //wrong
            correct = false;
        }

        if (drinkMaking.order.Contains("Milk") || drinkMaking.order.Contains("Ice") || drinkMaking.order.Contains("Caramel") || drinkMaking.order.Contains("Pumpkin") || drinkMaking.order.Contains("Vanilla"))
        {
            //wrong
            correct = false;
            Debug.Log("Wrong");
        }

        //if statement that checks if there's potion ingredients as well. Super wrong or mission purposes
    }

    public void DecafBlack() //3
    {
        if(drinkMaking.order.Contains("Decaffinated"))
        {

            if (drinkMaking.order.Contains("Caffinated") || drinkMaking.order.Contains("Sugar") || drinkMaking.order.Contains("Cream") || drinkMaking.order.Contains("Milk") || drinkMaking.order.Contains("Ice") || drinkMaking.order.Contains("Caramel") || drinkMaking.order.Contains("Pumpkin") || drinkMaking.order.Contains("Vanilla"))
            {
                //wrong
                correct = false;
                Debug.Log("Wrong");
            }
            else
            {
                //right
                correct = true;
                Debug.Log("Correct");
            }
        }
        else
        {
            correct = false;
            Debug.Log("Wrong");
        }
    }

    public void CaffBlack() //4
    {
        if (drinkMaking.order.Contains("Caffinated"))
        {
            if (drinkMaking.order.Contains("Decaffinated") || drinkMaking.order.Contains("Sugar") || drinkMaking.order.Contains("Cream") || drinkMaking.order.Contains("Milk") || drinkMaking.order.Contains("Ice") || drinkMaking.order.Contains("Caramel") || drinkMaking.order.Contains("Pumpkin") || drinkMaking.order.Contains("Vanilla"))

            {
                correct = false;
                //wrong
                Debug.Log("Wrong");
            }
            else
            {
                correct = true;
                //right
                Debug.Log("Correct");
            }
        }
        else
        {
            correct = false;
            Debug.Log("Wrong");
        }
    }

    public void CaramelIce() //5
    {
        //Contains: Caffinated, Milk, sugar, Caramel, ice
        if (drinkMaking.order.Contains("Caffinated"))
        {
            //move on
            if (drinkMaking.order.Contains("Milk"))
            {
                //continue
                if (drinkMaking.order.Contains("Sugar"))
                {
                    //contiue
                    if (drinkMaking.order.Contains("Ice"))
                    {
                        //continue
                        if (drinkMaking.order.Contains("Caramel"))
                        {
                            //right
                            correct = true;
                            Debug.Log("Correct");
                        }
                        else if (!drinkMaking.order.Contains("Caramel"))
                        {
                            correct = false;
                            Debug.Log("Wrong");
                        }
                    }
                    else if (!drinkMaking.order.Contains("Ice"))
                    {
                        //wrong
                        correct = false;
                        Debug.Log("Wrong");
                    }
                }
                else if (!drinkMaking.order.Contains("Sugar"))
                {
                    //wrong
                    correct = false;
                    Debug.Log("Wrong");
                }
            }
            else if (!drinkMaking.order.Contains("Milk"))
            {
                //wrong
                correct = false;
                Debug.Log("Wrong");
            }
        }
        else if (!drinkMaking.order.Contains("Caffinated") || drinkMaking.order.Contains("Decaffinated"))
        {
            Debug.Log("Wrong");
            correct = false;
            //wrong
        }

        if (drinkMaking.order.Contains("Cream") || drinkMaking.order.Contains("Pumpkin") || drinkMaking.order.Contains("Vanilla"))
        {
            //wrong
            correct = false;
            Debug.Log("Wrong");
        }

        //if statement that checks if there's potion ingredients as well. Super wrong or mission purposes
    }

    public void VanillaDark() //6
    {
        if(drinkMaking.order.Contains("Caffinated") && drinkMaking.order.Contains("Vanilla"))
        {
            if (drinkMaking.order.Contains("Decaffinated") || drinkMaking.order.Contains("Sugar") || drinkMaking.order.Contains("Cream") || drinkMaking.order.Contains("Milk") || drinkMaking.order.Contains("Ice") || drinkMaking.order.Contains("Caramel") || drinkMaking.order.Contains("Pumpkin"))
            {
                Debug.Log("Wrong");
                correct = false;
            }
            else
            {
                Debug.Log("Correct");
                correct = true;
            }
        }
        else
        {
            correct = false;
            Debug.Log("Wrong");
        }
    }

    public void justMilk() //7
    {
        if (drinkMaking.order.Contains("Milk"))
        {
            if (drinkMaking.order.Contains("Decaffinated") || drinkMaking.order.Contains("Sugar") || drinkMaking.order.Contains("Cream") || drinkMaking.order.Contains("Caffinated") || drinkMaking.order.Contains("Ice") || drinkMaking.order.Contains("Caramel") || drinkMaking.order.Contains("Pumpkin") || drinkMaking.order.Contains("Vanilla"))
            {
                Debug.Log("Wrong");
                correct = false;
            }
            else
            {
                //right
                correct = true;
                Debug.Log("Correct");
            }
        }
        else
        {
            //wrong
            correct = false;
            Debug.Log("Wrong");
        }
    }

    public void CaffDecaff() //8
    {
        if (drinkMaking.order.Contains("Caffinated") && drinkMaking.order.Contains("Decaffinated") && drinkMaking.order.Contains("Cream"))
        {
            if (drinkMaking.order.Contains("Sugar") || drinkMaking.order.Contains("Vanilla") || drinkMaking.order.Contains("Milk") || drinkMaking.order.Contains("Ice") || drinkMaking.order.Contains("Caramel") || drinkMaking.order.Contains("Pumpkin"))
            {
                Debug.Log("Wrong");
                correct = false;
            }
            else
            {
                correct = true;
                Debug.Log("Correct");
            }
        }
        else
        {
            correct = false;
            Debug.Log("Wrong");
        }
    }

    public void everythingCoffee() //9
    {
        if (drinkMaking.order.Contains("Decaffinated") && drinkMaking.order.Contains("Milk") && drinkMaking.order.Contains("Sugar") && drinkMaking.order.Contains("Cream") && drinkMaking.order.Contains("Caffinated") && drinkMaking.order.Contains("Ice") && drinkMaking.order.Contains("Caramel") && drinkMaking.order.Contains("Pumpkin") && drinkMaking.order.Contains("Vanilla"))
        {
            correct = true;
            Debug.Log("Correct");
        }
        else
        {
            //wrong
            correct = false;
            Debug.Log("Wrong");
        }
    }
}


