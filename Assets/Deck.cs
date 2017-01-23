using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Deck : MonoBehaviour {

	public string testString = "SDFSDFSDF";
	public int maxDeckSize = 40;
	public int currentDeckSize;
	public Card[] cardlist;
	public TextAsset cardData;
	int pointer = 0;
	// Use this for initialization
	void Start () {
		

	}

	void Awake() {
		currentDeckSize = maxDeckSize;

		if (cardData == null) {
			Debug.Log("Error: file empty or null\n");
		} else {
			cardlist = parseCards(cardData);
		}
	}


	Card[] parseCards(TextAsset ft) {
		string fs = ft.text;
		string[] flines = Regex.Split (fs, "\n");
		Card[] cards = new Card[maxDeckSize];
		int pointer = 0;
		for (int i = 0; i < flines.Length; i++) {
			string valueLine = flines [i];
			//Debug.Log (valueLine);
			string[] values = Regex.Split (valueLine, ";");
			Card newCard = new Card (values [0], values [1]);
			cards [pointer] = newCard;
			pointer++;
		}
		return cards;
	}

	public Card drawCard() {
		Card cardToDraw = cardlist [pointer];
		pointer++;
		currentDeckSize--;
		return cardToDraw;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
