using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DialogueStuff : MonoBehaviour
{

    public GameObject DPanel;
    public Text DText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;

    public GameObject contButton;
    public CameraScript cameraScript;
    public GameManaging gameManaging;
    public Ordering ordering;

    private bool start;
    public bool weird;
    public int tutorialend;

    public bool ending;

    public GameObject gameover;
    public TextMeshProUGUI Happy;
    public TextMeshProUGUI Mad;
    public Button restart;

    //public GameObject cam;
    //public GameObject here;

    public int ye;
    public int nah;

    // Start is called before the first frame update
    void Start()
    {
        //tutorialpause();
        start = true;
        weird = false;
        cameraScript = GameObject.Find("MainCamera").GetComponent<CameraScript>();
        gameManaging = GetComponent<GameManaging>();
        tutorialend = 0;

        ending = false;

        ye = 0;
        nah = 0;

        gameover.SetActive(false);
        //ordering = GameObject.Find("GameManager").GetComponent<Ordering>();
        

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            {
                Application.Quit();
            }
        }
        
        //ordering.menuNumber = 0;
        if (start)
        {
            dialogue[0] = "Hey.";
            dialogue[1] = "Make me an Ice Coffee, Witchling.";
            dialogue[2] = "Caffinated with Milk, Sugar and, of course, Ice. Right Click to restart if needed.";
            StartCoroutine(tutorialpause());
            start = false;
        }

        if (tutorialend == 1)
        {
            tutorialend = 0;
            dialogue[0] = "Hmmm";
            dialogue[1] = "Nope";
            dialogue[2] = "Try again. Caffinated, Milk, Sugar, Ice.";

            playdialogue();
        }
        else if (tutorialend == 2)
        {
            tutorialend = 0;
            dialogue[0] = "Mmmm!";
            dialogue[1] = "Perfect! You did well. I think you're ready for opening.";
            dialogue[2] = "The first customer is coming in now. Remember, even monsters need coffee!";
            endtut();
            tutorialend = 4;

        }
        else if(tutorialend == 5)
        {
            tutorialend = 0;
            gameManaging.namming.text = "Manager";
            dialogue[0] = "The day is over! You served enough customers.";
            dialogue[1] = "I'll be reviewing your work from today and I'll let you know if you can return.";
            dialogue[2] = "Until then, get some sleep, Witchling. The Brewery will always be here. <3";

            playdialogue();
            ending = true;
        }

        if(DText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    IEnumerator tutorialpause()
    {
        yield return new WaitForSeconds(2f);

        if(DPanel.activeInHierarchy)
        {
            zeroText();
        }
        else
        {
            DPanel.SetActive(true);
            StartCoroutine(typing());
        }
    }

    IEnumerator typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            DText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void playdialogue()
    {
        if (DPanel.activeInHierarchy)
        {
            zeroText();
        }
        else
        {
            DPanel.SetActive(true);
            StartCoroutine(typing());
        }
    } //gameManaging.tutorial = false;

    public void endtut()
    {
        if (DPanel.activeInHierarchy)
        {
            //gameManaging.tutorial = false;
            zeroText();
        }
        else
        {
            DPanel.SetActive(true);
            StartCoroutine(typing());
        }
    }

    public void zeroText() //keep in mind, might need it
    {
        //cam.transform.position = here.transform.position;
        if(gameManaging.go && !ending)
        {
            if (!weird)
            {
                cameraScript.make = true;
            }
            else
            {
                Debug.Log("Now weird");
                Happy.text = "Happy customers = " + ye;
                Mad.text = "Unhappy customers = " + nah;
                StartCoroutine(customerpause());
            }
            
        }
        else if (ending)
        {
            gameover.SetActive(true);
            Debug.Log("Game Ended!");
        }
        
        DText.text = "";
        index = 0;
        DPanel.SetActive(false);
    }

    IEnumerator customerpause()
    {
        if (cameraScript.customerCount < 10)
        {
            ordering.menuNumber = Random.Range(0, 10);
            Destroy(GameObject.FindGameObjectWithTag("Monster"));
            yield return new WaitForSeconds(1);
            gameManaging.delay = true;
            yield return new WaitForSeconds(3f);
            weird = false;
            //cameraScript.make = true;
        }
        else if (cameraScript.customerCount >= 10)
        {
            //end game scene
            tutorialend = 5;
            GameObject.FindGameObjectWithTag("Monster").transform.position = new Vector3(1000, 1000, 1000);

        }
    }


    public void nextLine()
    {
        //this is for before an order. Thenn there will be one for after an order.
        contButton.SetActive(false );

        if(index < dialogue.Length - 1)
        {
            index++;
            DText.text = "";
            StartCoroutine(typing());
        }
        else
        {
            zeroText();
        }
    }

    //Add a bunch of afermative and grossed out dialogue

    public void yesNo()
    {
        weird = true;
        if (ordering.correct)
        {
            ye++;
            int num;
            num = Random.Range(0, 5);
            switch (num)
            {
                case 0:
                    dialogue[0] = "Mhm,";
                    dialogue[1] = "This works,";
                    dialogue[2] = "Bye.";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 1:
                    dialogue[0] = "Tastes like a person!";
                    dialogue[1] = "A very tasty person";
                    dialogue[2] = "Thanks!";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 2:
                    dialogue[0] = "Love!";
                    dialogue[1] = "Love love!";
                    dialogue[2] = "I'll be back for sure!!";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 3:
                    dialogue[0] = "...";
                    dialogue[1] = ".......";
                    dialogue[2] = "Thank you.";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 4:
                    dialogue[0] = "Mmmm!!";
                    dialogue[1] = "I could totally mix blood with this and eat it for dinner.";
                    dialogue[2] = "Thank you.";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 5:
                    dialogue[0] = "Yes,";
                    dialogue[1] = "This is what I needed.";
                    dialogue[2] = "...bye";
                    cameraScript.make = false;
                    playdialogue();
                    break;
            }
        }
        else if(!ordering.correct)
        {
            nah++;
            int num;
            num = Random.Range(0, 5);
            switch (num)
            {
                case 0:
                    dialogue[0] = "Bleh";
                    dialogue[1] = "What?";
                    dialogue[2] = "Ugh...";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 1:
                    dialogue[0] = "Tastes like dirt!";
                    dialogue[1] = "A terrible start to my day.";
                    dialogue[2] = "Thanks.";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 2:
                    dialogue[0] = "Um...";
                    dialogue[1] = "...";
                    dialogue[2] = "...okay...";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 3:
                    dialogue[0] = "...";
                    dialogue[1] = ".......";
                    dialogue[2] = "No.";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 4:
                    dialogue[0] = "Wow!";
                    dialogue[1] = "Humans like this stuff?";
                    dialogue[2] = "Not for me.";
                    cameraScript.make = false;
                    playdialogue();
                    break;
                case 5:
                    dialogue[0] = "No,";
                    dialogue[1] = "Just no.";
                    dialogue[2] = "Bye";
                    cameraScript.make = false;
                    playdialogue();
                    break;
            }
        }
    }

    public void choosing()
    {
        Debug.Log("Going");
        switch (ordering.menuNumber)
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

    void icecoffee()
    {
        dialogue[0] = "Heeey!! You look so cute!";
        dialogue[1] = "I think I want a normal ice! I need it if I'm dealing with humans";
        dialogue[2] = "Caff, Milk, Sugar, Ice! Yeah!";

        playdialogue();
    }

    void PumpkinIce()
    {
        dialogue[0] = "I need something to replace blood this morning";
        dialogue[1] = "What do you got? Pumpkin? Sure.";
        dialogue[2] = "Caffine, Cream, Sugar, Pumpkin, Ice...";

        playdialogue();
    }

    void HotCoffee()
    {
        dialogue[0] = "I want to know why these humans like these beans so much.";
        dialogue[1] = "Get me something normal... Like a normal coffee!";
        dialogue[2] = "Yeah, Caffine I think. With cream and sugar.";

        playdialogue();
    }

    void DecafBlack()
    {
        dialogue[0] = "Black...";
        dialogue[1] = "But without energy...";
        dialogue[2] = "Decaf... and Black";

        playdialogue();
    }

    void CaffBlack()
    {
        dialogue[0] = "I'm in a rush and didn't get any prey.";
        dialogue[1] = "So just get me caffine and nothing else";
        dialogue[2] = "I mean it, nothing else! I need the energy!";

        playdialogue();
    }

    void CaramelIce()
    {
        dialogue[0] = "Caffinated...";
        dialogue[1] = "Milk...Sugar...Ice...";
        dialogue[2] = "Caramel...";

        playdialogue();
    }

    void VanillaDark()
    {
        dialogue[0] = "I'm trying to be cool by drinking black coffee!";
        dialogue[1] = "But I think it tastes so... bleck.";
        dialogue[2] = "So can you add Vanilla to that? Caffinated please!";

        playdialogue();
    }

    void justMilk()
    {
        dialogue[0] = "Please kind worker!";
        dialogue[1] = "As a normal human, I need sustinace!";
        dialogue[2] = "Give me milk!! Milk I say!";

        playdialogue();
    }

    void CaffDecaff()
    {
        dialogue[0] = "So I had a thought.";
        dialogue[1] = "If I get both Caffine and Decaf, then I'll probably be getting healthy coffee!";
        dialogue[2] = "So give me that! With cream please!";

        playdialogue();
    }

    void everythingCoffee()
    {
        dialogue[0] = "I can't decide! There's so much!";
        dialogue[1] = "I just want to eat everything, even the cup!";
        dialogue[2] = "Everything! Give me everything!!";

        playdialogue();
    }

    public void reloadingTheScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
