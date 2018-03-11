using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour, IHasChanged  {
	public Transform slots;
    public GameObject levelManager;
	private string inventoryText;
    public CanvasGroup cg;

	void start () { 
		HasChanged ();
	}

	public void HasChanged()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();
        int number = 0;
		foreach (Transform slotTransform in slots)
        {
			GameObject item = slotTransform.GetComponent<Slot> ().item;
			if (item)
            {
				builder.Append (item.name);
                number++;
			}
		}
		inventoryText = builder.ToString ();

        if (number == 5)
        {
            if (inventoryText.Equals("KRANJ"))
            {
                SceneManager.LoadScene(VariableBase.LevelNumber);
            }
            else
            {
                Hide_test.hide_selected(cg);
                levelManager.GetComponent<Hide_test>().requestDialog("Jenko", "Nočem v šolo! Raje bi - tako kot ti - po dvorišču vozil gnoj s karjolo!");
            }
        }
	}
	
}