using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private Text display;
	private int starCredit = 100;

	// Use this for initialization
	void Start () {
		display = GetComponent <Text> ();
		UpdateDisplay ();
	}
	
	public void AddStars (int amount) {
        print (amount + " stars added to display");
		starCredit += amount;
		UpdateDisplay ();
    }

	public Status UseStars (int amount) {
		// If enough star credit available.
		if (starCredit >= amount) {
			starCredit -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		} 
		// If not enough star credit available.
		return Status.FAILURE;
	}

	void UpdateDisplay ()
	{
		display.text = starCredit.ToString ();
	}
}
