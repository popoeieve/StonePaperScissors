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
    public Text btn1f1, btn2f2, btn1f2, btn1f3, btn2f3, btn3f3, btn4f3, btn1f4, btn2f4, btn3f4, btn4f4;
    public Button b1f2,b2f2,b1f3,b2f3,b3f3,b4f3,b1f4,b2f4,b3f4,b4f4;


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


}
