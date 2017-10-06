using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageMove : MonoBehaviour
{

    public Row[] road;

    public Vector2 startingPosition = new Vector2(0, 4);
    private Vector2 currentPosition;

    private bool notFinished = true;

    public CanvasGroup cg;

    private void Start()
    {
        currentPosition = startingPosition;
        notFinished = true;
    }

    private bool checkRoad()
    {
        return road[(int)currentPosition.x].getTile((int)currentPosition.y);
    }

    private bool checkFinish()
    {
        if (currentPosition.x == road.Length-1)
        {
            notFinished = false;
            Hide_test.show_selected(cg);
            return true;
        }
        return false;
    }

    private void resetRun()
    {
        Debug.Log("Present.");
        transform.Translate(new Vector3(currentPosition.y-startingPosition.y, 0, currentPosition.x-startingPosition.x));
        currentPosition = startingPosition;
    }

    private bool isWithin()
    {
        return currentPosition.x < road.Length && currentPosition.x >= 0;
    }

    // Update is called once per frame
    void Update () {

        bool move = false;
        Vector2 moveTo = new Vector2(0, 0);
        Vector3 moveMade = new Vector3();

        // klasicno premikanje: wasd
        if(Input.GetKeyDown("w"))
        {
            //transform.Translate(new Vector3(0, 0, -1));
            moveMade = new Vector3(0, 0, -1);
            move = true;
            moveTo.x += 1;
        } else if (Input.GetKeyDown("s"))
        {
            //transform.Translate(new Vector3(0, 0, 1));
            moveMade = new Vector3(0, 0, 1);
            move = true;
            moveTo.x -= 1;
        } else if (Input.GetKeyDown("a"))
        {
            //transform.Translate(new Vector3(1, 0));
            moveMade = new Vector3(1, 0);
            move = true;
            moveTo.y -= 1;
        } else if (Input.GetKeyDown("d"))
        {
            //transform.Translate(new Vector3(-1, 0));
            moveMade = new Vector3(-1, 0);
            move = true;
            moveTo.y += 1;
        }

        if (move && notFinished)
        {
            
            currentPosition += moveTo;
            transform.Translate(moveMade);

            Debug.Log(isWithin());

            if (isWithin() && checkRoad())
            {
                checkFinish();
            } else
            {
                resetRun();
            }
        }
    }
}

[System.Serializable]
public class Row
{
    public bool[] tiles;

    public Row()
    {
        this.tiles = new bool[8];
    }

    public bool getTile(int i)
    {
        return tiles[i];
    }
}
