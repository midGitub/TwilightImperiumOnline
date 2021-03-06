﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player {
	
	// Variables for logical use
	private const int TIGameProperties = 3;
	private bool[] isLocked;
	
	[SerializeField]
	private Treaty[] treaties;
	public Treaty[] Treaties { get { return treaties; } set { if (!isLocked[0]) { treaties = value; isLocked[0] = true; } else { Debug.Log("Player: Attempted to set locked property Treaties."); } } }
	[SerializeField]
	private PromissoryNote[] notes;
	public PromissoryNote[] Notes { get { return notes; } set { if (!isLocked[1]) { notes = value; isLocked[1] = true; } else { Debug.Log("Player: Attempted to set locked property Notes."); } } }
	private ArrayList hiddenObjectives = new ArrayList();
	public ArrayList HiddenObjectives { get { return hiddenObjectives; } set { if (!isLocked[2]) { hiddenObjectives = value; isLocked[2] = true; } else { Debug.Log("Player: Attempted to set locked property HiddenObjectives."); } } }
	[SerializeField]
	private string id;
	public string Id { get { return id; } }// set { if (!isLocked[3]) { id = value; isLocked[3] = true; } else { Debug.Log("Player: Attempted to set locked property Id."); } } }
	[SerializeField]
	private Race race;
	public Race Race { get { return race; } }// set { if (!isLocked[4]) { race = value; isLocked[4] = true; } else { Debug.Log("Player: Attempted to set locked property Race."); } } }
	[SerializeField]
	private Color color;
	public Color Color { get { return color; } }
	
	public Player(string idString, Race pRace, Color pColor) {
		isLocked = new bool[TIGameProperties];
		for (int i=0; i<TIGameProperties; i++) {
			isLocked[i] = false;
		}
		
		id = idString;
		race = pRace;
		color = pColor;
	}
}