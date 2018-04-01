using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	// Only one selectedDefender variable exists in the whole game (static).
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Component[] spriteRendererArray;
    private Text priceLabel;

    // Use this for initialization
    void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		// Get all Sprite Renderers on the Game Object itself and on children (Star Trophy).
		spriteRendererArray = GetComponentsInChildren<SpriteRenderer> ();

		SetAllSpriteRendererColors (Color.black);
		// Set defender price labels.
        priceLabel = GetComponentInChildren <Text>();
		if (!priceLabel) { Debug.LogError(name + " has no Text component found in children."); }
        priceLabel.text = (defenderPrefab.GetComponent<Defender>().price.ToString()); 
    }
		
	void OnMouseDown () {
		// Set all buttons' and their childrens' Sprite Renderer colors the same.
		foreach (Button button in buttonArray) {
			button.SetAllSpriteRendererColors (Color.black);
		}
		// Set the current button's Sprite Renderer color.
		SetAllSpriteRendererColors (Color.white);

		// Set the selected defender to this gameObject's defender prefab.
		selectedDefender = defenderPrefab;
	}


	void SetAllSpriteRendererColors (Color color) {
		// Include Sprite Renderers on the gameObject and on childObjects.
		foreach (SpriteRenderer spriteRenderer in spriteRendererArray) {
			spriteRenderer.color = color;
		}
	}
}
