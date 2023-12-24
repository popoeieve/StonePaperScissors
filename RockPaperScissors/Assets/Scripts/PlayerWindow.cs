using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerWindow : MonoBehaviour
{
    public GameObject panelArmory;
    public GameObject panelPerks;
    private Animation anim;
    public TextMeshProUGUI perkPoints;
    public Text btn1f1, btn2f2, btn1f2, btn1f3, btn2f3, btn3f3, btn4f3, btn1f4, btn2f4, btn3f4, btn4f4,btn1f5,btn2f5;
    public Button b1f2,b2f2,b1f3,b2f3,b3f3,b4f3,b1f4,b2f4,b3f4,b4f4,b1f5,b2f5;


    // Start is called before the first frame update
    void Start()
    {
        anim = panelPerks.GetComponent<Animation>();
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

    public void openStartWindow() 
    {
        SceneManager.LoadScene("StartWindow");
    }

    public void startBattle() 
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ButtonCounter()
    {
        int contador = int.Parse(btn1f1.text);
        if (contador < 5)
        {            
            contador++;
            btn1f1.text = contador.ToString();
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
            contador++;
            btn1f2.text = contador.ToString();
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
            contador++;
            btn2f2.text = contador.ToString();
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
            contador++;
            btn1f3.text = contador.ToString();
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
            contador++;
            btn2f3.text = contador.ToString();
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
            contador++;
            btn1f4.text = contador.ToString();
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
            contador++;
            btn2f4.text = contador.ToString();
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
            contador++;
            btn1f5.text = contador.ToString();
        }
    }

    public void ButtonCounterb3f3()
    {
        int contador = int.Parse(btn3f3.text);
        if (contador < 5)
        {
            contador++;
            btn3f3.text = contador.ToString();
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
            contador++;
            btn4f3.text = contador.ToString();
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
            contador++;
            btn3f4.text = contador.ToString();
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
            contador++;
            btn4f4.text = contador.ToString();
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
            contador++;
            btn2f5.text = contador.ToString();
        }
    }

    public void createPlayer() 
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Health", 1);
        PlayerPrefs.SetInt("Strength", 1);
        PlayerPrefs.SetInt("Defense", 1);
        PlayerPrefs.SetInt("Dextry", 1);
        PlayerPrefs.SetInt("PlayerHealth", 1);
        PlayerPrefs.SetInt("Charisma", 1);
        PlayerPrefs.SetInt("Experience", 1);

    }

    public void updatePlayer(int experienceEarned) 
    {
        PlayerPrefs.SetInt("Experience", PlayerPrefs.GetInt("Experience")+experienceEarned);
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
    }




}
