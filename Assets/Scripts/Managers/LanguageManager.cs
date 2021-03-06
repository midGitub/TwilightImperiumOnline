﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class LocalizationException : System.Exception, ISerializable
{
	public LocalizationException()
		: base() { }
	public LocalizationException(string message)
		: base(message) { }
	public LocalizationException (string message, System.Exception inner)
		: base(message, inner) { }
	protected LocalizationException (SerializationInfo info, StreamingContext context)
		: base(info, context) { }
	public LocalizationException(string languageString, string englishString) 
		: base(string.Format ("LocalizationException: {0}: Unrecognized identifier {1}",languageString,englishString)) { }
}


public class LanguageManager : TIOMonoBehaviour {

	private GameManager gameManager;
	public string Language;

	//String to _____ dicts
	private Dictionary<string,int> toNumber = new Dictionary<string,int>();
	private Dictionary<string,bool> toBoolean = new Dictionary<string,bool>();
	private Dictionary<string,TPrereqMode> toTPrereqMode = new Dictionary<string,TPrereqMode>();
	private Dictionary<string,string> toDataType = new Dictionary<string,string>();
	private Dictionary<string,Expansion> toExpansion = new Dictionary<string,Expansion>();
	private Dictionary<string,UType> toUType = new Dictionary<string,UType>();
	private Dictionary<string,UAbility> toUAbility = new Dictionary<string,UAbility>();
	private Dictionary<string,TType> toTType = new Dictionary<string,TType>();
	private Dictionary<string,string> toSTag = new Dictionary<string,string>();
	private Dictionary<string,SType> toSType = new Dictionary<string,SType>();
	private Dictionary<string,OType> toOType = new Dictionary<string,OType>();
	private Dictionary<string,OReward> toOReward = new Dictionary<string,OReward>();
	private Dictionary<string,StrategySet> toStrategySet = new Dictionary<string,StrategySet>();
	private Dictionary<string,EType> toEType = new Dictionary<string,EType>();
	private Dictionary<string,RType> toRType = new Dictionary<string,RType>();
	private Dictionary<string,Option> toOption = new Dictionary<string,Option>();
	private Dictionary<string,LType> toLType = new Dictionary<string,LType>();
	private Dictionary<string,Scenario> toScenario = new Dictionary<string,Scenario>();
	
	//______ to string dicts
	private Dictionary<int,string> numberTo = new Dictionary<int,string>();
	private Dictionary<bool,string> booleanTo = new Dictionary<bool,string>();
	private Dictionary<TPrereqMode,string> tPrereqModeTo = new Dictionary<TPrereqMode,string>();
	private Dictionary<Expansion,string> expansionTo = new Dictionary<Expansion,string>();
	private Dictionary<UType,string> uTypeTo = new Dictionary<UType,string>();
	private Dictionary<UAbility,string> uAbilityTo = new Dictionary<UAbility,string>();
	private Dictionary<TType,string> tTypeTo = new Dictionary<TType,string>();
	private Dictionary<string,string> sTagTo = new Dictionary<string,string>();
	private Dictionary<SType,string> sTypeTo = new Dictionary<SType, string>();
	private Dictionary<OType,string> oTypeTo = new Dictionary<OType, string>();
	private Dictionary<OReward,string> oRewardTo = new Dictionary<OReward,string>();
	private Dictionary<StrategySet,string> strategySetTo = new Dictionary<StrategySet, string>();
	private Dictionary<EType,string> eTypeTo = new Dictionary<EType,string>();
	private Dictionary<RType,string> rTypeTo = new Dictionary<RType,string>();
	private Dictionary<Option,string> optionTo = new Dictionary<Option,string>();
	private Dictionary<LType,string> lTypeTo = new Dictionary<LType,string>();
	private Dictionary<Scenario,string> scenarioTo = new Dictionary<Scenario,string>();

	// Use this for initialization
	void Start () {
		gameManager = GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Initialize() {
		gameManager.FileMgr.ReadLanguageFile ();
	}

	//StringTo_____ functions
	public int StringToNumber(string numberString) { return toNumber [numberString.ToLower ()]; }
	public bool StringToBoolean(string boolString) { return toBoolean [boolString.ToLower ()]; }
	public TPrereqMode StringToTPrereqMode(string prereqString) { return toTPrereqMode [prereqString.ToLower ()]; }
	public string StringToDataType(string dataTypeString) { 
		if (!toDataType.ContainsKey (dataTypeString.ToLower())) {
			Debug.Log ("DTS:" + dataTypeString);
			foreach(string key in toDataType.Keys) {
				Debug.Log ("DTS key:" + dataTypeString);
			}
		} 
		return toDataType [dataTypeString.ToLower ()]; 
	}
	public Expansion StringToExpansion(string expansionString) { return toExpansion [expansionString.ToLower ()]; }
	public UType StringToUType(string uTypeString) { return toUType [uTypeString.ToLower ()]; }
	public UAbility StringToUAbility(string uAbilityString) { return toUAbility [uAbilityString.ToLower ()]; }
	public TType StringToTType(string tTypeString) { return toTType [tTypeString.ToLower ()]; }
	public string StringToSTag(string sTagString) { return toSTag [sTagString.ToLower ()]; }
	public SType StringToSType(string sTypeString) { return toSType [sTypeString.ToLower ()]; } 
	public OType StringToOType(string oTypeString) { return toOType [oTypeString.ToLower ()]; }
	public OReward StringToOReward(string oRewardString) { return toOReward [oRewardString.ToLower ()]; }
	public EType StringToEType(string eTypeString) { return toEType[eTypeString.ToLower ()]; }
	public RType StringToRType(string rTypeString) { return toRType [rTypeString.ToLower ()]; }
	public Option StringToOption(string optionString) { return toOption [optionString.ToLower ()]; }
	public LType StringToLType(string lTypeString) { return toLType [lTypeString.ToLower ()]; }
	public StrategySet StringToStrategySet(string strategySetString) { 
		if (toStrategySet.ContainsKey(strategySetString.ToLower ())) {
			return toStrategySet [strategySetString.ToLower ()]; 
		} else {
			return StrategySet.None;
		}
	}
	public Scenario StringToScenario(string scenarioString) { return toScenario [scenarioString.ToLower ()]; }

	//______ToString functions
	public string NumberToString(int number) { return numberTo [number]; }
	public string BooleanToString(bool boolean) { return booleanTo [boolean]; }
	public string TPrereqModeToString(TPrereqMode prereq) { return tPrereqModeTo [prereq]; }
	public string ExpansionToString(Expansion expo) { return expansionTo [expo]; }
	public string UTypeToString(UType unitType) { return uTypeTo [unitType]; }
	public string UAbilityToString(UAbility unitAbility) { return uAbilityTo [unitAbility]; }
	public string TTypeToString(TType techType) { return tTypeTo [techType]; }
	public string STagToString(string systemTag) { return sTagTo [systemTag.ToLower ()]; }
	public string STypeToString(SType systemType) { return sTypeTo [systemType]; }
	public string OTypeToString(OType objectiveType) { return oTypeTo [objectiveType]; }
	public string ORewardToString(OReward objectiveReward) { return oRewardTo [objectiveReward]; }
	public string ETypeToString(EType electionType) { return eTypeTo [electionType]; }
	public string RTypeToString(RType repType) { return rTypeTo [repType]; }
	public string OptionToString(Option opt) { return optionTo [opt]; }
	public string LTypeToString(LType leaderType) { return lTypeTo [leaderType]; }
	public string StrategySetToString(StrategySet strategySet) { return strategySetTo [strategySet]; }
	public string ScenarioToString(Scenario scenario) { return scenarioTo[scenario]; }


	//Dictionary-filling functions

	public void AddNumber (string languageString) {
		AddNumber (languageString, languageString);
	}
	public void AddNumber (string languageString, string englishString) {
		int value;
		if (englishString.ToLower().Trim() == "two") {
			value = 2;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		numberTo [value] = languageString;
		toNumber [languageString.ToLower ().Trim()] = value;
	}

	public void AddBoolean(string languageString) {
		AddBoolean (languageString, languageString);
	}
	public void AddBoolean(string languageString, string englishString) {
		bool value;
		if (englishString.ToLower ().Trim() == "true") {
			value = true;
		} else  if (englishString.ToLower ().Trim() == "false") {
			value = false;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		booleanTo [value] = languageString;
		toBoolean [languageString.ToLower ().Trim()] = value;
	}

	public void AddTPrereqMode(string languageString) {
		AddTPrereqMode (languageString, languageString);
	}
	public void AddTPrereqMode(string languageString, string englishString) {
		TPrereqMode value;
		if (englishString.ToLower ().Trim() == "and") {
			value = TPrereqMode.AND;
		} else  if (englishString.ToLower ().Trim() == "or") {
			value = TPrereqMode.OR;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		tPrereqModeTo [value] = languageString;
		toTPrereqMode [languageString.ToLower ().Trim()] = value;
	}

	public void AddDataType(string languageString) {
		AddDataType (languageString, languageString);
	}
	public void AddDataType(string languageString, string englishString) {
		toDataType [languageString.ToLower ().Trim()] = englishString;
	}

	public void AddExpansion(string languageString) {
		AddExpansion (languageString, languageString);
	}
	public void AddExpansion(string languageString, string englishString) {
		Expansion value;
		if (englishString.ToLower().Trim() == "vanilla") {
			value = Expansion.Vanilla;
		} else  if (englishString.ToLower ().Trim() == "shattered empire") {
			value = Expansion.ShatteredEmpire;
		} else if (englishString.ToLower ().Trim() == "shards of the throne") {
			value = Expansion.ShardsOfTheThrone;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		expansionTo [value] = languageString;
		toExpansion [languageString.ToLower ().Trim()] = value;
	}

	public void AddUType(string languageString) {
		AddUType (languageString, languageString);
	}
	public void AddUType(string languageString, string englishString) {
		UType value;
		if (englishString.ToLower ().Trim() == "carrier" || englishString.ToLower ().Trim() == "carriers") {
			value = UType.Carrier;
		} else  if (englishString.ToLower ().Trim() == "cruiser" || englishString.ToLower ().Trim() == "cruisers") {
			value = UType.Cruiser;
		} else if (englishString.ToLower ().Trim() == "destroyer" || englishString.ToLower ().Trim() == "destroyers") {
			value = UType.Destroyer;
		} else if (englishString.ToLower ().Trim() == "dreadnought" || englishString.ToLower ().Trim() == "dreadnoughts") {
			value = UType.Dreadnought;
		} else if (englishString.ToLower ().Trim() == "fighter" || englishString.ToLower().Trim() == "fighters") {
			value = UType.Fighter;
		} else if (englishString.ToLower ().Trim() == "flagship" || englishString.ToLower ().Trim() == "flagships") {
			value = UType.Flagship;
		} else if (englishString.ToLower().Trim() == "ground force" || englishString.ToLower().Trim() == "ground forces") {
			value = UType.GroundForce;
		} else if (englishString.ToLower ().Trim() == "mechanized unit" || englishString.ToLower ().Trim() == "mechanized units") {
			value = UType.MechanizedUnit;
		} else if (englishString.ToLower ().Trim() == "pds" || englishString.ToLower ().Trim() == "pdss") {
			value = UType.PDS;
		} else if (englishString.ToLower ().Trim() == "space dock" || englishString.ToLower ().Trim() == "space docks") {
			value = UType.SpaceDock;
		} else if (englishString.ToLower ().Trim() == "war sun" || englishString.ToLower ().Trim() == "war suns") {
			value = UType.WarSun;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		uTypeTo [value] = languageString;
		toUType [languageString.ToLower ().Trim()] = value;
	}

	public void AddUAbility(string languageString) {
		AddUAbility (languageString, languageString);
	}
	public void AddUAbility(string languageString, string englishString) {
		UAbility value;
		if (englishString.ToLower ().Trim() == "anti-fighter barrage") {
			value = UAbility.AntiFighterBarrage;
		} else  if (englishString.ToLower ().Trim() == "bombard") {
			value = UAbility.Bombardment;
		} else if (englishString.ToLower ().Trim() == "planetary shield") {
			value = UAbility.PlanetaryShield;
		} else if (englishString.ToLower ().Trim() == "production") {
			value = UAbility.Production;
		} else if (englishString.ToLower ().Trim() == "sustain damage") {
			value = UAbility.SustainDamage;
		} else if (englishString.ToLower ().Trim() == "build capacity 5") {
			value = UAbility.BuildCapacity5;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		uAbilityTo [value] = languageString;
		toUAbility [languageString.ToLower ().Trim()] = value;
	}

	public void AddTType(string languageString) {
		AddTType (languageString, languageString);
	}
	public void AddTType(string languageString, string englishString) {
		TType value;
		if (englishString.ToLower ().Trim() == "blue") {
			value = TType.Blue;
		} else  if (englishString.ToLower ().Trim() == "green") {
			value = TType.Green;
		} else if (englishString.ToLower ().Trim() == "racial") {
			value = TType.Racial;
		} else if (englishString.ToLower () == "red") {
			value = TType.Red;
		} else if (englishString.ToLower ().Trim() == "yellow") {
			value = TType.Yellow;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		tTypeTo [value] = languageString;
		toTType [languageString.ToLower ().Trim()] = value;
	}

	public void AddSTag(string languageString) {
		AddSTag (languageString, languageString);
	}
	public void AddSTag(string languageString, string englishString) {
		sTagTo [englishString.ToLower ().Trim()] = languageString;
		toSTag [languageString.ToLower ().Trim()] = englishString;
	}

	public void AddSType(string languageString) {
		AddSType (languageString, languageString);
	}
	public void AddSType(string languageString, string englishString) {
		SType value;
		if (englishString.ToLower ().Trim() == "special") {
			value = SType.Special;
		} else  if (englishString.ToLower ().Trim() == "home") {
			value = SType.Home;
		} else if (englishString.ToLower ().Trim() == "unattached") {
			value = SType.Unattached;
		} else if (englishString.ToLower ().Trim() == "fixed") {
			value = SType.Fixed;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		sTypeTo [value] = languageString;
		toSType [languageString.ToLower ().Trim()] = value;
	}

	public void AddOType(string languageString) {
		AddOType (languageString, languageString);
	}
	public void AddOType(string languageString, string englishString) {
		OType value;
		if (englishString.ToLower ().Trim() == "public stage i") {
			value = OType.PublicStageI;
		} else  if (englishString.ToLower ().Trim() == "public stage ii") {
			value = OType.PublicStageII;
		} else if (englishString.ToLower ().Trim() == "preliminary") {
			value = OType.Preliminary;
		} else if (englishString.ToLower ().Trim() == "secret") {
			value = OType.Secret;
		} else if (englishString.ToLower ().Trim() == "special") {
			value = OType.Special;
		} else if (englishString.ToLower ().Trim() == "lazax") {
			value = OType.Lazax;
		} else if (englishString.ToLower ().Trim() == "scenario") {
			value = OType.Scenario;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		oTypeTo [value] = languageString;
		toOType [languageString.ToLower ().Trim()] = value;
	}

	public void AddOReward(string languageString) {
		AddOReward (languageString, languageString);
	}
	public void AddOReward(string languageString, string englishString) {
		OReward value;
		if (englishString.ToLower ().Trim() == "i win the game") {
			value = OReward.WIN;
		} else  if (englishString.ToLower ().Trim() == "immediate victory") {
			value = OReward.INSTANTWIN;
		} else if (englishString.ToLower ().Trim() == "game over") {
			value = OReward.GAMEOVER;
		} else if (englishString.ToLower ().Trim() == "vp") {
			value = OReward.VP;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		oRewardTo [value] = languageString;
		toOReward [languageString.ToLower ().Trim()] = value;
	}

	public void AddStrategySet(string languageString) {
		AddStrategySet (languageString, languageString);
	}
	public void AddStrategySet(string languageString, string englishString) {
		StrategySet value;
		if (englishString.ToLower ().Trim() == "vanilla set") {
			value = StrategySet.Vanilla;
		} else  if (englishString.ToLower ().Trim() == "shattered empire set") {
			value = StrategySet.ShatteredEmpire;
		} else if (englishString.ToLower ().Trim() == "fall of the empire variants") {
			value = StrategySet.FallOfTheEmpire;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		strategySetTo [value] = languageString;
		toStrategySet [languageString.ToLower ().Trim()] = value;
	}

	public void AddEType(string languageString) {
		AddEType (languageString, languageString);
	}
	public void AddEType(string languageString, string englishString) {
		EType value;
		if (englishString.ToLower ().Trim() == "a special system") {
			value = EType.ASpecialSystem;
		} else if (englishString.ToLower ().Trim() == "current law") {
			value = EType.CurrentLaw;
		} else if (englishString.ToLower ().Trim() == "planet" || englishString.ToLower () == "planets") {
			value = EType.Planet;
		} else if (englishString.ToLower ().Trim() == "player" || englishString.ToLower () == "players") {
			value = EType.Player;
		} else if (englishString.ToLower ().Trim() == "public objective") {
			value = EType.PublicObjective;
		} else if (englishString.ToLower ().Trim() == "technology color") {
			value = EType.TechColor;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		eTypeTo [value] = languageString;
		toEType [languageString.ToLower ().Trim()] = value;
	}

	public void AddRType(string languageString) {
		AddRType (languageString, languageString);
	}
	public void AddRType(string languageString, string englishString) {
		RType value;
		if (englishString.ToLower ().Trim() == "bodyguard") {
			value = RType.Bodyguard;
		} else  if (englishString.ToLower ().Trim() == "councilor") {
			value = RType.Councilor;
		} else if (englishString.ToLower ().Trim() == "spy") {
			value = RType.Spy;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		rTypeTo [value] = languageString;
		toRType [languageString.ToLower ().Trim()] = value;
	}

	public void AddOption(string languageString) {
		AddOption (languageString, languageString);
	}
	public void AddOption(string languageString, string englishString) {
		Option value;
		if (englishString.ToLower ().Trim() == "distant suns") {
			value = Option.DistantSuns;
		} else  if (englishString.ToLower ().Trim() == "the final frontier") {
			value = Option.TheFinalFrontier;
		} else if (englishString.ToLower ().Trim() == "the long war") {
			value = Option.TheLongWar;
		} else if (englishString.ToLower ().Trim() == "age of empire") {
			value = Option.AgeOfEmpire;
		} else if (englishString.ToLower ().Trim() == "leaders") {
			value = Option.Leaders;
		} else if (englishString.ToLower ().Trim() == "sabotage runs") {
			value = Option.SabotageRuns;
		} else if (englishString.ToLower ().Trim() == "shattered empire objectives") {
			value = Option.SEObjectives;
		} else if (englishString.ToLower ().Trim() == "all objectives") {
			value = Option.AllObjectives;
		} else if (englishString.ToLower ().Trim() == "race-specific technologies") {
			value = Option.RaceSpecificTechnologies;
		} else if (englishString.ToLower ().Trim() == "artifacts") {
			value = Option.Artifacts;
		} else if (englishString.ToLower ().Trim() == "shock troops") {
			value = Option.ShockTroops;
		} else if (englishString.ToLower ().Trim() == "space mines") {
			value = Option.SpaceMines;
		} else if (englishString.ToLower ().Trim() == "wormhole nexus") {
			value = Option.WormholeNexus;
		} else if (englishString.ToLower ().Trim() == "facilities") {
			value = Option.Facilities;
		} else if (englishString.ToLower ().Trim() == "tactical retreats") {
			value = Option.TacticalRetreats;
		} else if (englishString.ToLower ().Trim() == "territorial distant suns") {
			value = Option.TerritorialDistantSuns;
		} else if (englishString.ToLower ().Trim() == "custodians of mecatol rex") {
			value = Option.CustodiansOfMecatolRex;
		} else if (englishString.ToLower ().Trim() == "voice of the council") {
			value = Option.VoiceOfTheCouncil;
		} else if (englishString.ToLower ().Trim() == "simulated early turns") {
			value = Option.SimulatedEarlyTurns;
		} else if (englishString.ToLower ().Trim() == "preliminary objectives") {
			value = Option.PreliminaryObjectives;
		} else if (englishString.ToLower ().Trim() == "flagships") {
			value = Option.Flagships;
		} else if (englishString.ToLower ().Trim() == "mechanized units") {
			value = Option.MechanizedUnits;
		} else if (englishString.ToLower ().Trim() == "mercenaries") {
			value = Option.Mercenaries;
		} else if (englishString.ToLower ().Trim() == "political intrigue") {
			value = Option.PoliticalIntrigue;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		optionTo [value] = languageString;
		toOption [languageString.ToLower ().Trim()] = value;
	}

	public void AddLType(string languageString) {
		AddLType (languageString, languageString);
	}
	public void AddLType(string languageString, string englishString) {
		LType value;
		if (englishString.ToLower ().Trim() == "admiral") {
			value = LType.Admiral;
		} else  if (englishString.ToLower ().Trim() == "agent") {
			value = LType.Agent;
		} else if (englishString.ToLower ().Trim() == "diplomat") {
			value = LType.Diplomat;
		} else if (englishString.ToLower ().Trim() == "general") {
			value = LType.General;
		} else if (englishString.ToLower ().Trim() == "scientist") {
			value = LType.Scientist;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		lTypeTo [value] = languageString;
		toLType [languageString.ToLower ().Trim()] = value;
	}

	public void AddScenario(string languageString) {
		AddScenario (languageString, languageString);
	}
	public void AddScenario(string languageString, string englishString) {
		Scenario value;
		if (englishString.ToLower ().Trim() == "standard game") {
			value = Scenario.StandardGame;
		} else if (englishString.ToLower ().Trim() == "fall of the empire") {
			value = Scenario.FallOfTheEmpire;
		} else {
			throw new LocalizationException(languageString, englishString);
		}
		scenarioTo[value] = languageString;
		toScenario [languageString.ToLower ().Trim()] = value;
	}
	
	// More complex dictionary fetching functions
	
	public EType ExtractEType(string[] languageStrings) {
		string accumulatedString = "";
		foreach(string languageString in languageStrings) {
			if (toEType.ContainsKey(languageString.ToLower ())) {
				return toEType[languageString.ToLower ().Trim()];
			}
			if (accumulatedString != "") {
				accumulatedString += " ";
			}
			accumulatedString += languageString;
		}
		if (toEType.ContainsKey(accumulatedString.ToLower())) {
			return toEType[accumulatedString.ToLower ().Trim()];
		}
		throw new LocalizationException (accumulatedString, accumulatedString);
	}
	
	
	// Dictionary checking functions
	
	public bool HasTPrereqMode(string languageString) {
		if (toTPrereqMode.ContainsKey(languageString)) {
			return true;
		} else {
			return false;
		}
	}
	
	public bool HasNumber(string languageString) {
		if (toNumber.ContainsKey(languageString)) {
			return true;
		} else {
			return false;
		}
	}
}