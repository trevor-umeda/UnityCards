using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour {

	public GameObject deckObject;
	public Deck deck;
	public GameObject cardPrefab;
	// Use this for initialization
	void Start () {
		deck = deckObject.GetComponent<Deck> ();
		Debug.Log ("Deck test pulling inf0 " + deck.testString);
		Draw ();
	}

	public void Draw() {
		Debug.Log ("DRAWING A CARD");
		GameObject card = (GameObject)Instantiate(cardPrefab);
		Card drawnCard = deck.drawCard ();
		foreach(Text texts in card.GetComponentsInChildren<Text>()) 
		{
			if (texts.name == "Card Title") {
				texts.text = drawnCard.title;
			}
			if (texts.name == "Card Description") {
				texts.text = drawnCard.description;
			}
		}
		card.transform.SetParent (this.transform);
	}

	// Update is called once per frame
	void Update () {


	}
}
