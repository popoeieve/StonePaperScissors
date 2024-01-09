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
    public GameObject MoreStrengthBtn;
    public GameObject MoreDexBtn;
    public GameObject MoreDefBtn;
    public GameObject MoreCharBtn;

    // Start is called before the first frame update
    void Start()
    {
        rechargeStats();
        Debug.Log("Se ha iniciado el panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moreStrength() 
    {
        PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength",0)+1);
        PlayerPrefs.SetInt("ExtraStatPoints", PlayerPrefs.GetInt("ExtraStatPoints", 0)-1);
        rechargeStats();
    }

    public void moreDex()
    {
        PlayerPrefs.SetInt("Dextry", PlayerPrefs.GetInt("Dextry", 0) + 1);
        PlayerPrefs.SetInt("ExtraStatPoints", PlayerPrefs.GetInt("ExtraStatPoints", 0) - 1);
        rechargeStats();
    }

    public void moreDef()
    {
        PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense", 0) + 1);
        PlayerPrefs.SetInt("ExtraStatPoints", PlayerPrefs.GetInt("ExtraStatPoints", 0) - 1);
        rechargeStats();
    }

    public void moreChar()
    {
        PlayerPrefs.SetInt("Charisma", PlayerPrefs.GetInt("Charisma", 0) + 1);
        PlayerPrefs.SetInt("ExtraStatPoints", PlayerPrefs.GetInt("ExtraStatPoints", 0) - 1);
        rechargeStats();
    }

    public void rechargeStats() 
    {
        Level.text = "Level: " + PlayerPrefs.GetInt("Level", 0).ToString();
        Experience.text = PlayerPrefs.GetInt("Experience", 0).ToString();
        NextLevel.text = (PlayerPrefs.GetInt("Level", 0) * 25 + 75).ToString();
        AvaiablePoints.text = PlayerPrefs.GetInt("ExtraStatPoints", 0).ToString();
        Strength.text = PlayerPrefs.GetInt("Strength", 0).ToString();
        Defense.text = PlayerPrefs.GetInt("Defense", 0).ToString();
        Dextry.text = PlayerPrefs.GetInt("Dextry", 0).ToString();
        Charisma.text = PlayerPrefs.GetInt("Charisma", 0).ToString();
        if (PlayerPrefs.GetInt("ExtraStatPoints", 0) > 0)
        {
            MoreStrengthBtn.SetActive(true);
            MoreDexBtn.SetActive(true);
            MoreDefBtn.SetActive(true);
            MoreCharBtn.SetActive(true);
        }
        else 
        {
            MoreStrengthBtn.SetActive(false);
            MoreDexBtn.SetActive(false);
            MoreDefBtn.SetActive(false);
            MoreCharBtn.SetActive(false);
        }
    }
}
