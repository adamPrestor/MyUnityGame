using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeStringByLetter : MonoBehaviour {

    public Text textArea;
    public string[] textArr;
    private string text2;
    public float waitTime;
    public CanvasGroup cg;
    public Image imageTemp;
    public Sprite[] images;

    string text;
    bool cont = false;
    bool canPress = false;
    float readTime = 1.0f;

    int i = 0;

    void changeImage(int k)
    {
        imageTemp.sprite = images[k];
    } 

    void setText2()
    {
        text2 = "";
        for(int j = 0; j<text.Length; j++)
        {
            text2 += " ";
        }
    }

    void deprecateText2()
    {
        text2 = text2.Substring(0, text2.Length - 1);
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(Typer());
    }


    IEnumerator Typer()
    {
        int k = 0;
        for (k = 0; k < textArr.Length; k++)
        {
            changeImage(k);
                
            canPress = true;

            text = textArr[k];
            setText2();

            while (i < text.Length)
            {

                yield return new WaitForSeconds(waitTime);
                textArea.text = text.Substring(0, i + 1);
                deprecateText2();
                textArea.text += text2;
                i++;
            }

            Debug.Log(readTime);
            yield return new WaitForSeconds(readTime);

            canPress = true;
            cont = false;

            while (!cont)
            {
                yield return new WaitForSeconds(0.1f);
            }

            i = 0;

        }

        Hide_test.show_selected(cg);

    }

    void Update()
    {
        if (Input.anyKey)
        {
            if (i < text.Length - 1)
            {
                i = text.Length - 1;
                canPress = false;
            }
            else
            {
                cont = true;
                canPress = false;
            }

        }
        
    }

}
