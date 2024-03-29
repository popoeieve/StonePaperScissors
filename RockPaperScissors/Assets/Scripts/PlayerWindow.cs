using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerWindow : MonoBehaviour
{
    public GameObject panelArmory;
    public GameObject panelPerks;
    public GameObject panelStats;
    public GameObject panelPerkDescription;
    public GameObject PerkController;
    private Animation anim;
    public Image descriptionImage;
    public TextMeshProUGUI perkPoints,descriptionNamePerk,descriptionTxt;
    public TextMeshProUGUI btn1f1, btn2f2, btn1f2, btn1f3, btn2f3, btn3f3, btn4f3, btn1f4, btn2f4, btn3f4, btn4f4,btn1f5,btn2f5;
    public Button b1f2,b2f2,b1f3,b2f3,b3f3,b4f3,b1f4,b2f4,b3f4,b4f4,b1f5,b2f5;
    public Button[] PerksBtn;

    // Start is called before the first frame update
    void Start()
    {    
        foreach (Button btn in PerksBtn)
        {
            btn.gameObject.AddComponent<holdBtn>();
        }
        if (PlayerPrefs.GetInt("Level",1)==1)
        {
            createPlayer();
        }
        anim = panelPerks.GetComponent<Animation>();
        perkPoints.text = PlayerPrefs.GetInt("ExtraPerkPoints", 0).ToString();
        ChargePerks();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openConfPanel()
    {
        anim.clip = anim.GetClip("ConfPanelAnim");
        anim.Play();
    }

    public void closeConfPanel()
    {
        panelPerks.GetComponent<Animation>().clip = panelPerks.GetComponent<Animation>().GetClip("ConfPanelAnimExit");
        panelPerks.GetComponent<Animation>().Play();
        updatePlayer();
    }

    void ChargePerks()
    {
        for (int i = 0; i < PerksBtn.Length; i++)
        {            
            string nameButton = PerksBtn[i].name;
            if (nameButton == "Perk1-1")
            {
                btn1f1.text=PlayerPrefs.GetInt("BeyondLimits",0).ToString();
            }
            else if(nameButton == "Perk2-1")
            {
                if (PlayerPrefs.GetInt("ExterminatusDeities", 0) != 0)
                {
                    PerksBtn[i].interactable = true;
                    Debug.Log("El bot�n es ahora interactable");
                }
                btn1f2.text = PlayerPrefs.GetInt("ExterminatusDeities", 0).ToString();                
            }
            else if (nameButton == "Perk2-2")
            {
                if (PlayerPrefs.GetInt("Tenacity", 0) != 0)
                {
                    PerksBtn[i].interactable = true;
                    Debug.Log("El bot�n es ahora interactable");
                }
                btn2f2.text = PlayerPrefs.GetInt("Tenacity", 0).ToString();
            }
            else if (nameButton == "Perk1-3")
            {
                btn1f3.text = PlayerPrefs.GetInt("SupremacyStrongest", 0).ToString();
            }
            else if (nameButton == "Perk2-3")
            {
                btn2f3.text = PlayerPrefs.GetInt("Exasperation", 0).ToString();
            }
            else if (nameButton == "Perk3-3")
            {
                btn3f3.text = PlayerPrefs.GetInt("UnrivalledDefense", 0).ToString();
            }
            else if (nameButton == "Perk4-3")
            {
                btn4f3.text = PlayerPrefs.GetInt("TheBeginingLegacy", 0).ToString();
            }
            else if (nameButton == "Perk1-4")
            {
                btn1f4.text = PlayerPrefs.GetInt("ExemplaryConcentration", 0).ToString();
            }
            else if (nameButton == "Perk2-4")
            {
                btn2f4.text = PlayerPrefs.GetInt("FallOfWeak", 0).ToString();
            }
            else if (nameButton == "Perk3-4")
            {
                btn3f4.text = PlayerPrefs.GetInt("KnightInsight", 0).ToString();
            }
            else if (nameButton == "Perk4-4")
            {
                btn4f4.text = PlayerPrefs.GetInt("DiligenceUnknown", 0).ToString();
            }
            else if (nameButton == "Perk5-1")
            {
                btn1f5.text = PlayerPrefs.GetInt("RecklessHero", 0).ToString();
            }
            else if (nameButton == "Perk5-2")
            {
                btn2f5.text = PlayerPrefs.GetInt("TheOne", 0).ToString();
            }                            
        }
        PlayerPrefs.Save();
    }

    public void openLeftPanel()
    {
        panelArmory.GetComponent<Animation>().clip = panelArmory.GetComponent<Animation>().GetClip("leftPanelEnter");
        panelArmory.GetComponent<Animation>().Play();
    }

    public void closeLeftPanel()
    {
        panelArmory.GetComponent<Animation>().clip = panelArmory.GetComponent<Animation>().GetClip("leftPanelExit");
        panelArmory.GetComponent<Animation>().Play();
    }

    public void openStatsPanel()
    {
        panelStats.SetActive(true);
    }

    public void closeStatsPanel()
    {
        panelStats.SetActive(false);
    }

    public void openStartWindow() 
    {
        SceneManager.LoadScene("StartWindow");
    }

    public void startBattle() 
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void perkSelected() 
    {
        PlayerPrefs.SetInt("ExtraPerkPoints", PlayerPrefs.GetInt("ExtraPerkPoints", 0) - 1);
        perkPoints.text = PlayerPrefs.GetInt("ExtraPerkPoints", 0).ToString();
    }
    public void ButtonCounter()
    {
        int contador = int.Parse(btn1f1.text);
        if (contador < 5) // Could be reduced------------------
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn1f1.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b1f2.interactable = true;
            b2f2.interactable = true;
        }        
    }

    public void ButtonCounterb1f2()
    {
        int contador = int.Parse(btn1f2.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn1f2.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b1f3.interactable = true;
            b2f3.interactable = true;
        }
    }

    public void ButtonCounterb2f2()
    {
        int contador = int.Parse(btn2f2.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn2f2.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b3f3.interactable = true;
            b4f3.interactable = true;
        }
    }

    public void ButtonCounterb1f3()
    {
        int contador = int.Parse(btn1f3.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn1f3.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b1f4.interactable = true;
            b2f4.interactable = true;
        }
    }

    public void ButtonCounterb2f3()
    {
        int contador = int.Parse(btn2f3.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn2f3.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b1f4.interactable = true;
            b2f4.interactable = true;
        }
    }

    public void ButtonCounterb1f4()
    {
        int contador = int.Parse(btn1f4.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn1f4.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b1f5.interactable = true;
        }
    }

    public void ButtonCounterb2f4()
    {
        int contador = int.Parse(btn2f4.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn2f4.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b1f5.interactable = true;
        }
    }

    public void ButtonCounterb1f5()
    {
        int contador = int.Parse(btn1f5.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn1f5.text = contador.ToString();
                perkSelected();
            }
        }
    }

    public void ButtonCounterb3f3()
    {
        int contador = int.Parse(btn3f3.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn3f3.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b3f4.interactable = true;
            b4f4.interactable = true;
        }
    }

    public void ButtonCounterb4f3()
    {
        int contador = int.Parse(btn4f3.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn4f3.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b3f4.interactable = true;
            b4f4.interactable = true;
        }
    }

    public void ButtonCounterb3f4()
    {
        int contador = int.Parse(btn3f4.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn3f4.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b2f5.interactable = true;
        }
    }

    public void ButtonCounterb4f4()
    {
        int contador = int.Parse(btn4f4.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn4f4.text = contador.ToString();
                perkSelected();
            }
        }
        if (contador >= 5)
        {
            b2f5.interactable = true;
        }
    }

    public void ButtonCounterb2f5()
    {
        int contador = int.Parse(btn2f5.text);
        if (contador < 5)
        {            
            if (PlayerPrefs.GetInt("ExtraPerkPoints", 0) != 0)
            {
                contador++;
                btn2f5.text = contador.ToString();
                perkSelected();
            }
        }
    }

    public void createPlayer() 
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Health", 1);
        PlayerPrefs.SetInt("Strength", 1);
        PlayerPrefs.SetInt("Defense", 1);
        PlayerPrefs.SetInt("Dextry", 1);
        PlayerPrefs.SetInt("Charisma", 1);
        PlayerPrefs.SetInt("Experience", 20);
        PlayerPrefs.SetInt("ExtraPerkPoints", 25);
        PlayerPrefs.SetInt("ExtraStatPoints", 10);
        PlayerPrefs.SetString("PlayerName", "Nombre");
        PlayerPrefs.SetString("Stage", "Stage");
        PlayerPrefs.SetInt("Cash",100);
        PlayerPrefs.Save();


    }

    public void updatePlayer() 
    {
        PlayerPrefs.SetInt("BeyondLimits", int.Parse(btn1f1.text));
        PlayerPrefs.SetInt("ExterminatusDeities", int.Parse(btn1f2.text));
        PlayerPrefs.SetInt("SupremacyStrongest", int.Parse(btn1f3.text));
        PlayerPrefs.SetInt("ExemplaryConcentration", int.Parse(btn1f4.text));
        PlayerPrefs.SetInt("RecklessHero", int.Parse(btn1f5.text));
        PlayerPrefs.SetInt("Tenacity", int.Parse(btn2f2.text));
        PlayerPrefs.SetInt("Exasperation", int.Parse(btn2f3.text));
        PlayerPrefs.SetInt("FallOfWeak", int.Parse(btn2f4.text));
        PlayerPrefs.SetInt("TheOne", int.Parse(btn2f5.text));
        PlayerPrefs.SetInt("UnrivalledDefense", int.Parse(btn3f3.text));
        PlayerPrefs.SetInt("KnightInsight", int.Parse(btn3f4.text));
        PlayerPrefs.SetInt("TheBeginingLegacy", int.Parse(btn4f3.text));
        PlayerPrefs.SetInt("DiligenceUnknown", int.Parse(btn4f4.text));
        PlayerPrefs.Save();
    }

}
