using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public GameObject correctForm;
    public bool moving;
    private bool finish;
    static bool potionReady;
    public bool transfer;

    private float startposX, startposY;
    private float missDistance = 2f;

    private Vector3 restartStartPos;

    private SpriteRenderer rnderer;

    // Start is called before the first frame update
    void Start()
    {
        restartStartPos = this.transform.localPosition;
        finish = false;
        potionReady = false;
        transfer = false;

        rnderer = GetComponent<SpriteRenderer>();

        if (this.gameObject.name == "Potion")
        {
            correctForm = GameObject.Find("Potion Placement");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.name != "Potion")
        {
            correctForm = GameObject.Find("Potion");
        }

        if (finish == false)
        {
            if (moving)
            {
                if (this.gameObject.name == "Potion")
                {
                    /*Vector3 mousepos;
                    mousepos = Input.mousePosition;
                    mousepos = Camera.main.ScreenToWorldPoint(mousepos);

                    this.gameObject.transform.localPosition =
                        new Vector3(mousepos.x - startposX, mousepos.y - startposY, this.gameObject.transform.localPosition.z);*/

                    this.transform.localPosition = correctForm.transform.localPosition;
                }
                else
                {
                    if(GameObject.Find("Potion").GetComponent<MovementSystem>().transfer)
                    {
                        Vector3 mousepos;
                        mousepos = Input.mousePosition;
                        mousepos = Camera.main.ScreenToWorldPoint(mousepos);

                        this.gameObject.transform.localPosition =
                            new Vector3(mousepos.x - startposX, mousepos.y - startposY, this.gameObject.transform.localPosition.z);
                    }
                }
            }
        }

        if(potionReady)
        {
            transfer = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= missDistance && 
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= missDistance)
        {
            this.transform.localPosition = 
                new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            finish = true;
            potionReady = true;

            if(gameObject.name != "Potion")
            {
                StartCoroutine(delay());
            }
        }
        else
        {
            this.transform.localPosition =
                new Vector3(restartStartPos.x, restartStartPos.y, restartStartPos.z);
        }
        
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            startposX = mousepos.x - this.transform.localPosition.x;
            startposY = mousepos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    IEnumerator delay ()
    {
        yield return new WaitForSeconds(0.02f); //number might have to be adjusted if there are multiple being added

        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
        //rnderer.color = new Color(1f, 1f, 1f, 0f);
    }
}
