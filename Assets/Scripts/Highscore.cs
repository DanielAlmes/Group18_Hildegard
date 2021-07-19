using UnityEngine;
 
using System.Collections.Generic;
 
public static class Highscore {
    //number of entries the highscore has
    public const int EntryCount = 10;
 
    //creating custom "variable type"
    public struct ScoreEntry {
        public string name;
        public int score;
 
        //creating custom variable type
        public ScoreEntry(string name, int score) {
            this.name = name;
            this.score = score;
        }
    }
 
    //creating list to hold all (max 10) of the custom variable type
    private static List<ScoreEntry> entriesList;
 
    private static List<ScoreEntry> Entries {
        get {
            //if the list does not exist yet, create it
            if (entriesList == null) {
                //create list fillable with "ScoreEntry's"
                entriesList = new List<ScoreEntry>();
                //clear list and fill with saved entries
                LoadScores();
            }
            return entriesList;
        }
    }

    
    //key needed to save and retrive entries from player prefs 
    private const string Key = "highscore";
    
    //method sorts the highscore by value
    private static void SortScores() {
        entriesList.Sort((a, b) => b.score.CompareTo(a.score));
    }
 
    public static void LoadScores() {
        //create new list
        entriesList = new List<ScoreEntry>();
        
        //iterate from 0 till the number of entries
        for (int i = 0; i < EntryCount; ++i) {
            ScoreEntry entry;
            //if there is an entry, add it to the list
            //if there is none, add("None",0)
            entry.name = PlayerPrefs.GetString(Key + "[" + i + "].name", "None");
            entry.score = PlayerPrefs.GetInt(Key + "[" + i + "].score", 0);
            //save every entry in the list
            entriesList.Add(entry);
        }
        
        SortScores();
    }
 
    //...saves the score (in player prefs) 
    private static void SaveScores() {
        //iterate through list
        for (int i = 0; i < EntryCount; ++i) {

            var entry = entriesList[i];
            //save name in player preferences so it can still be accessed if game ends
            PlayerPrefs.SetString(Key + "[" + i + "].name", entry.name);
            //save score
            PlayerPrefs.SetInt(Key + "[" + i + "].score", entry.score);
        }
    }
 
    //returns entry at pos index
    public static ScoreEntry GetEntry(int index) {
        return Entries[index];
    }
 
    //saves name and score in the playerprefs
    public static void Record(string name, int score) {
        //add new entry
        Entries.Add(new ScoreEntry(name, score));
        //sort them highest to lowest
        SortScores();
        //remove the last (lowest) entry
        Entries.RemoveAt(Entries.Count - 1);
        SaveScores();
    }
    
    //checks if a given new score needs to be added to highscore
    public static bool CheckScore(int currentScore) {
        //iterate through every entry to see if one is lower
        for (int i = 0; i < EntryCount; ++i) {
            if(Entries[i].score < currentScore)
            {
                return true;
            }
        }
        return false;
    }
}
