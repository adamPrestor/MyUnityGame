using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory1 : MonoBehaviour, IHasChanged
{
    public Transform slots1;
    public Transform slots2;
    public GameObject levelManager;
    private string inventoryText;
    public CanvasGroup cg;
    bool nameRight = false;
    bool surnameRight = false;

    void start()
    {
        HasChanged();
    }

    public void HasChanged()
    {
        System.Text.StringBuilder builderName = new System.Text.StringBuilder();
        System.Text.StringBuilder builderSurname = new System.Text.StringBuilder();
        string name, surname;
        int numberName = 0;
        int numberSurname = 0;

        foreach (Transform slotTransform in slots1)
        {
            GameObject item;
            try
            {
                item = slotTransform.GetComponent<Slot>().item;
            } catch (System.Exception)
            {
                if (slotTransform.name.Equals("Slot (1)"))
                {
                    builderName.Append("I");
                } else if (slotTransform.name.Equals("Slot (4)"))
                {
                    builderName.Append("N");
                }
                numberName++;
                continue;
            }
            
            if (item)
            {
                builderName.Append(item.name);
                numberName++;
            }
        }

        foreach (Transform slotTransform in slots2)
        {
            GameObject item;
            try
            {
                item = slotTransform.GetComponent<Slot>().item;
            }
            catch (System.Exception)
            {
                if (slotTransform.name.Equals("Slot (2)"))
                {
                    builderSurname.Append("N");
                }
                else if (slotTransform.name.Equals("Slot (4)"))
                {
                    builderSurname.Append("O");
                }
                numberSurname++;
                continue;
            }

            if (item)
            {
                builderSurname.Append(item.name);
                numberSurname++;
            }
        }

        name = builderName.ToString();
        surname = builderSurname.ToString();

        slots1.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        slots2.GetComponent<Image>().color = new Color32(255, 255, 255, 100);

        if (numberName == 5)
        {
            if (name.Equals("SIMON"))
            {
                slots1.GetComponent<Image>().color = new Color32(193, 230, 186, 200);
                nameRight = true;
            }
            else
            {
                levelManager.GetComponent<Hide_test>().requestDialog("Jenko", "Bolj se bos moral potruditi.");
                nameRight = false;
            }
        }

        if (numberSurname == 5)
        {
            if (surname.Equals("JENKO"))
            {
                slots2.GetComponent<Image>().color = new Color32(193, 230, 186, 200);
                surnameRight = true;
            }
            else
            {
                levelManager.GetComponent<Hide_test>().requestDialog("Jenko", "Bolj se bos moral potruditi.");   
                surnameRight = false;
            }
        }

        if (nameRight && surnameRight)
        {
            Hide_test.show_selected(cg);
        }
    }

}



namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}
