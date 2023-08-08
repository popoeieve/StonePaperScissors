using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlStartWindow : MonoBehaviour
{
    public GameObject panelConf;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = panelConf.GetComponent<Animation>();
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
        panelConf.GetComponent<Animation>().clip = panelConf.GetComponent<Animation>().GetClip("ConfPanelAnimExit");
        panelConf.GetComponent<Animation>().Play();
    }

    public void continueButton() 
    {
        SceneManager.LoadScene("PlayerScene");
    }


}
