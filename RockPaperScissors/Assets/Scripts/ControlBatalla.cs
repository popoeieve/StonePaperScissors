using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlbatalla : MonoBehaviour
{
    public Button Rock, Paper, Scissor;
    public GameObject TiePanel;
    public int PlayerLife;
    public int EnemyLife;
    


    // Start is called before the first frame update
    void Start()
    {
        
        CardDraw();
        CardDraw();
        CardDraw();
        CardDraw();
        PlayerLife = 20; 
        EnemyLife = 20;
       
       
        

    }


    // Update is called once per frame
    void Update()
    {

    }

    void Combat(Card PlayerCard, Card EnemyCard, float DamageMultiplier, float DefenseMultiplier, float CombatEffects)
    {
        if (PlayerCard.CardType == EnemyCard.CardType && (PlayerCard.CardType != "Block" || PlayerCard.CardType != "Counter"))
        {
            TiePanel.SetActive(true);


            
        }
        else if (PlayerCard.CardType == "Slash" && (EnemyCard.CardType == "Counter" || EnemyCard.CardType == "Heavy"))
        {
            // Hace Daño al enemigo
        }
        else if (PlayerCard.CardType == "Heavy" && EnemyCard.CardType == "Block")
        {
            // Hace daño heavy a block
        }
        else if (PlayerCard.CardType == "Block" && PlayerCard.CardType == "Slash")
        {
            // El enemigo pierde el turno
        }
        else if (PlayerCard.CardType == "Counter" && EnemyCard.CardType == "Heavy")
        {
            // Devueve el daño de Heavy
        }
        else if (EnemyCard.CardType == "Slash" && (PlayerCard.CardType == "Counter" || PlayerCard.CardType == "Heavy"))
        {
            // Hace Daño al enemigo
        }
        else if (EnemyCard.CardType == "Heavy" && PlayerCard.CardType == "Block")
        {
            // Hace daño heavy a block
        }
        else if (EnemyCard.CardType == "Block" && PlayerCard.CardType == "Slash")
        {
            // El enemigo pierde el turno
        }
        else if (EnemyCard.CardType == "Counter" && PlayerCard.CardType == "Heavy")
        {
            // Devueve el daño de Heavy
        }
    }
    public void TieSelection ()
    {
        int numeroAleatorio = Random.Range(1, 4);
        switch (numeroAleatorio)
        {
           
            case 1:
                //Ganas
                Debug.Log("win");
                break;
            case 2:
                //Pierdes
                Debug.Log("pierdes");
                break;
            case 3:
                //Empatas
                Debug.Log("tie");

                break;
           
        }
      
    }
  
    public Card CardDraw()
    {
        int numeroAleatorio = Random.Range(1, 5);
        Card CardDrawed = null;
        switch (numeroAleatorio)
        {
            case 1:
                CardDrawed = new Card(5, "Slash");
                break;
            case 2:
                CardDrawed = new Card(10, "Heavy");
                break;
            case 3:
                CardDrawed = new Card(0, "Block");
                break;
            case 4:
                CardDrawed = new Card(0, "Counter");
                break;

        }
        return CardDrawed;
        
    }
    
    public void CardSelector(Card SelectedCard)
    {
        Card EnemyCard = null;
        EnemyCard = CardDraw();

    }

}
public class Card: MonoBehaviour
{
    public int CardDamage;
    public string CardType;
    public Card (int CardDamage_, string CardType_)
    {
        this.CardDamage = CardDamage_;
        this.CardType = CardType_;
    }
}

