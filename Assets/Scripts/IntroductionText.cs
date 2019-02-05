using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionText : MonoBehaviour {

    public Text textField;
    public CanvasGroup cg;
    public Image imageFiled;
    public Sprite[] sprites;

    private int page = 0;
    private const int max_pages = 3;

    string[] text = new string[max_pages] {
        "Pred 180 leti, ko je bil svet še črno-bel, ko še niti niso poznali kamere ali fotoaparata, ko je bilo na svetu precej manj hiš kot danes, je skozi" +
        "Cerklje vodila še makedamska pot. Vodila je proti raju ... povsod naokrog visoke gore, širina polja in zelene lipe ...",

        "In po tej poti se je prišlo do Podjedovih, kjer je bilo tega dne - 9. novembra 1835 - vse narobe: moški so čakali zunaj, ženske so hitele po hiši ... " +
        "niti slučajno se niso zavedali, da se je pravkar rodil velik skladatelj in pevovodja.",

        "Na svet je pokukal sin. Rekli so mu Martin. \n Skakal je, trgal hlače, rasel kot kopriva. In ko domača lipa ni bila več dovolj zanimiva, so ga starši poslali v svet."
    };

    private void Start()
    {
        print(text.Length);
        LoadPage();
    }

    public void NextPage()
    {
        page = Mathf.Min(page+1, max_pages-1);
        LoadPage();
    }

    public void PrevPage()
    {
        page = Mathf.Max(page-1, 0);
        LoadPage();
    }

    private void LoadPage()
    {
        textField.text = text[page];
        imageFiled.sprite = sprites[page];
        Hide_test.show_selected(cg);
    }

}
