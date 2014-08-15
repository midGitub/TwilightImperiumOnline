﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Expansion {Vanilla, ShatteredEmpire, ShardsOfTheThrone};
public enum Option {DistantSuns, TheFinalFrontier, TheLongWar, AgeOfEmpire, Leaders, SabotageRuns, SEObjectives, AllObjectives, RaceSpecificTechnologies, Artifacts, ShockTroops, SpaceMines, WormholeNexus, Facilities, TacticalRetreats, TerritorialDistantSuns, CustodiansOfMecatolRex, VoiceOfTheCouncil, SimulatedEarlyTurns, PreliminaryObjectives, Flagships, MechanizedUnits, Mercenaries, PoliticalIntrigue, FallOfTheEmpire};

public class GameManager : TIOMonoBehaviour {

	private string language = "English";
	public string Language { get { return language; } }

	//TODO: May not need these dictionaries. Decide.
	private Dictionary<string, StrategyCard> strats = new Dictionary<string, StrategyCard> ();

	[SerializeField]
	//TODO: After finished, get rid of debug arrays.
	private Option[] activeOptionsDebug;
	private ArrayList activeOptions = new ArrayList ();
	[SerializeField]
	private StrategyCard[] strategyCardsDebug;
	private Dictionary<int, StrategyCard> strategyCards = new Dictionary<int, StrategyCard> ();

	private bool first = true;

	// Use this for initialization
	void Start () {
		Activate (Option.AllObjectives);
		Activate (Option.PreliminaryObjectives);
		Activate (Option.Artifacts);
		Activate (Option.WormholeNexus);
	}
	
	// Update is called once per frame
	void Update () {
		if (first) {
			first = false;
			readStrategyCards ();
			StrategyCard[] replacements = new StrategyCard[2]{strats["Technology II"],strats["Trade III"]};
			prepStrategyCards (StrategySet.FallOfTheEmpire, replacements);
		}

		activeOptionsDebug = (Option[])activeOptions.ToArray (typeof(Option));
		strategyCards.Values.CopyTo(strategyCardsDebug,0);
	}

	public void Activate(Option option) {
		if (!Active (option)){
			activeOptions.Add (option);
		}
	}

	public bool Active(Option option) {
		return activeOptions.Contains(option);
	}

	public void Deactivate(Option option) {
		if (Active (option)){
			activeOptions.Remove(option);
		}
	}

	private void readStrategyCards(){
		foreach (StrategyCard strat in GetComponent<FileManager>().ReadStrategyFile()) {
			strats[strat.Name] = strat;
		}
	}

	private void prepStrategyCards(StrategySet set) {
		foreach (StrategyCard strategyCard in strats.Values){
			if (strategyCard.Set == set) {
				strategyCards[strategyCard.Initiative] = strategyCard;
			}
		}

		if (strategyCards.Values.Count < 8) {
			//Set is incomplete (Fall of the Empire). Fill in with original strategy cards
			foreach (StrategyCard strategyCard in strats.Values){
				if (strategyCard.Set == StrategySet.Vanilla && !strategyCards.ContainsKey (strategyCard.Initiative)) {
					strategyCards[strategyCard.Initiative] = strategyCard;
				}
			}
		}

		strategyCardsDebug = new StrategyCard[8];
	}

	private void prepStrategyCards(StrategySet set, StrategyCard[] replacements) {
		//Prepare set
		prepStrategyCards (set);

		foreach (StrategyCard replacementCard in replacements) {
			strategyCards[replacementCard.Initiative] = replacementCard;
		}
	}

	public StrategyCard ChooseStrategyCard(int initiative) {
		return strategyCards [initiative];
	}
}
