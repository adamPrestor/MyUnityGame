using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageMove : MonoBehaviour
{

    public Row[] road;

    public Vector2 startingPosition = new Vector2(0, 4);
    private Vector2 currentPosition;

    private bool notFinished = true;

    public GameObject go;
    public CanvasGroup cg;

    public string comment;
    public bool enablePlay = true;

    private void Start()
    {
        currentPosition = startingPosition;
        notFinished = true;
    }

    private bool CheckRoad()
    {
        return road[(int)currentPosition.x].getTile((int)currentPosition.y);
    }

    private bool CheckFinish()
    {
        if (currentPosition.x == road.Length-1)
        {
            notFinished = false;
            Hide_test.StaticLoadNextLevel();
            return true;
        }
        return false;
    }

    private bool isWithin()
    {
        return currentPosition.x < road.Length && currentPosition.x >= 0 && currentPosition.y >= 0 && currentPosition.y < 8;
    }

    // Update is called once per frame
    void Update () {

        if (!enablePlay)
            return;

        bool move = false;
        Vector2 moveTo = new Vector2(0, 0);
        Vector3 moveMade = new Vector3();

        // klasicno premikanje: wasd + arrow keys
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.Translate(new Vector3(0, 0, -1));
            moveMade = new Vector3(0, 0, -1);
            move = true;
            moveTo.x += 1;
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.Translate(new Vector3(0, 0, 1));
            moveMade = new Vector3(0, 0, 1);
            move = true;
            moveTo.x -= 1;
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.Translate(new Vector3(1, 0));
            moveMade = new Vector3(1, 0);
            move = true;
            moveTo.y -= 1;
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
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
            
            if (isWithin() && CheckRoad())
            {
                CheckFinish();
            } else
            {
                StartCoroutine(ResetRun());
            }
        }
    }

    IEnumerator ResetRun()
    {
        go.GetComponent<Hide_test>().requestDialogJenko(string.Format(comment, VariableBase.PlayerName));
        enablePlay = false;

        yield return new WaitForSeconds(3.0f);

        transform.Translate(new Vector3(currentPosition.y - startingPosition.y, 0, currentPosition.x - startingPosition.x));
        currentPosition = startingPosition;
        go.GetComponent<Hide_test>().dialogHandle.hideAllDialogs();
        enablePlay = true;
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
