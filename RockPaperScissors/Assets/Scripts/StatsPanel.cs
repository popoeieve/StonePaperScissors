using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    public TextMeshProUGUI Level;
    public TextMeshProUGUI AvaiablePoints; //From "ExtraPoints" playerPref
    public TextMeshProUGUI Strength;
    public TextMeshProUGUI Defense;
    public TextMeshProUGUI Dextry;
    public TextMeshProUGUI Charisma;
    public TextMeshProUGUI Experience;
    public TextMeshProUGUI NextLevel;

    // Start is called before the first frame update
    void Start()
    {
        Level.text = "Level: " + PlayerPrefs.GetInt("Level", 0).ToString();
        Experience.text = PlayerPrefs.GetInt("Experience", 0).ToString();
        NextLevel.text = (PlayerPrefs.GetInt("Level", 0) * 25 + 75).ToString();
        AvaiablePoints.text = PlayerPrefs.GetInt("ExtraPoints", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
