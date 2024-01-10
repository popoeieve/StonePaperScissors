using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmoryScript : MonoBehaviour
{
    public TextMeshProUGUI currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        currentMoney.text = PlayerPrefs.GetInt("Cash", 100).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
