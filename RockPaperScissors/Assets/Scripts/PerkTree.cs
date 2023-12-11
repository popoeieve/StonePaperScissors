using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkTree : MonoBehaviour
{
    public Button[] Buttons
    public GameObject[] Perks;
    public bool PerkStatusChecked = false;
    public float DmgPerk, LifePerk, ArmorPerk;
    // Start is called before the first frame update
    public void PerkTreeSelected(int index) { 
        foreach GameObject Object in perks 
    {
        Object.SetActive(false);
     }

    Perks[index].SetActive(true); 
 }
}
