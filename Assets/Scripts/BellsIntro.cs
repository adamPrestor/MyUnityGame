using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellsIntro : MonoBehaviour {
    
    Hide_test ht;

    bool switch1 = false;
    bool switch2 = false;


	// Use this for initialization
	void Start () {

        ht = this.GetComponent<Hide_test>();

        StartCoroutine(DialogHandler());
        
	}

    public bool isTrue()
    {
        return switch2;
    }

    public void JozefClick()
    {
        if (switch1)
            switch2 = true;
    }
	
    IEnumerator DialogHandler()
    {
        ht.requestDialog("Cankar", "V tem času je pravice in želje mnogih evropskih narodov prekrival led, ki ga politične oblasti niso hotele odtajati.");

        yield return new WaitForSeconds(3.0f);

        ht.requestDialog("Jozef", "Jaz takrat še nisem bil na oblasti. Z miško me pocukaj za brke, če meniš, da moram jaz prevzeti prestol.");

        switch1 = true;

        yield return new WaitUntil(isTrue);

        ht.requestDialog("Cankar", "A leta 1848 so se mnogi temu uprli. Led so skušali razbiti in več veljave pridobiti! Zato to leto imenujemo POMLAD NARODOV.");

        
    }

}
