using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionText : MonoBehaviour {

    public Text textField;
    public CanvasGroup cg;
    public Image imageFiled, LeftArrow, RightArrow;
    public Sprite[] sprites;
    public AudioSource AS;

    private int page = 0;
    private const int max_pages = 3;

    string[] text = new string[max_pages] {
        "Pred 180 leti, ko je bil svet še črno-bel, ko še niti niso poznali kamere ali fotoaparata, ko je bilo na svetu precej manj hiš kot danes, je skozi " +
        "Cerklje vodila še makedamska pot. Vodila je proti raju ... povsod naokrog visoke gore, širina polja in zelene lipe ...",

        "In po tej poti se je prišlo do Podjedovih, kjer je bilo tega dne - 9. novembra 1835 - vse narobe: moški so čakali zunaj, ženske so hitele po hiši ... " +
        "niti slučajno se niso zavedali, da se je pravkar rodil veliki skladatelj in pevovodja.",

        "Na svet je pokukal sin. \n Rekli so mu Martin. \n Skakal je, trgal hlače, rasel kot kopriva. \n In ko domača lipa ni bila več dovolj zanimiva, \n so ga starši poslali v svet: \n\n IN SEDAJ GREŠ LAHKO Z NJIM TUDI TI!"
    };

    private void Start()
    {
        LeftArrow.GetComponent<Image>().color = Color.clear;
        LoadPage();
    }

    public void NextPage()
    {
        page = Mathf.Min(page+1, max_pages-1);
        if (page == max_pages-1)
            RightArrow.GetComponent<Image>().color = Color.clear;
        else
            LeftArrow.GetComponent<Image>().color = new Color(255,255,255,255);
        LoadPage();
    }

    public void PrevPage()
    {
        page = Mathf.Max(page-1, 0);
        if (page == 0)
            LeftArrow.GetComponent<Image>().color = Color.clear;
        else
            RightArrow.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        LoadPage();
    }

    private void LoadPage()
    {
        if (page == 2 && !AS.isPlaying)
            AS.Play();
        textField.text = text[page];
        imageFiled.sprite = sprites[page];
        Hide_test.show_selected(cg);
    }

}
