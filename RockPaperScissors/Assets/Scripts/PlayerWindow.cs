using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerWindow : MonoBehaviour
{
    public GameObject panelArmory;
    public GameObject panelPerks;
    private Animation anim;
    public Text btn1f1;
    public Button b1f2, b2f2; 


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


}
