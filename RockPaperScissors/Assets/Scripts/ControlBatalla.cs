using System.Collections;
using UnityEngine.SceneManagement; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlbatalla : MonoBehaviour
{
    public Button Rock, Paper, Scissor;
    public GameObject TiePanel;
    public int PlayerLife;
    public int EnemyLife;
    public Image CardPanel;
    public GameObject CardPrefab;
    public Text PlayerLifeCounter;
    public Text EnemyLifeCounter;
    public Card LastCardDrawed;
    public Text EndBatlleText;
    public GameObject EndBattlePanel;
    public GameObject Hero;



    // Start is called before the first frame update
    void Start()
    {  
        LastCardDrawed = null;
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
        PlayerLifeCounter.text = PlayerLife+"";
        EnemyLifeCounter.text = EnemyLife+"";        
    }

    void Combat(Card PlayerCard, Card EnemyCard)
    {
        Hero.GetComponent<Animator>().SetTrigger("CardSelected");
        LastCardDrawed = PlayerCard; 
        Debug.Log("Se hace combate");
        if (PlayerCard.CardType == EnemyCard.CardType && (PlayerCard.CardType != "Block" || PlayerCard.CardType != "Counter"))
        {
            TiePanel.SetActive(true);      
        }
        else if (PlayerCard.CardType == "Slash" && (EnemyCard.CardType == "Counter" || EnemyCard.CardType == "Heavy"))
        {
            EnemyLife = EnemyLife - PlayerCard.CardDamage;
        }
        else if (PlayerCard.CardType == "Heavy" && EnemyCard.CardType == "Block")
        {
            EnemyLife = EnemyLife - PlayerCard.CardDamage;
        }
        else if (PlayerCard.CardType == "Block" && PlayerCard.CardType == "Slash")
        {
            // Causa estado Bloqueado en el Enemigo
        }
        else if (PlayerCard.CardType == "Counter" && EnemyCard.CardType == "Heavy")
        {
            EnemyLife = EnemyLife - EnemyCard.CardDamage;
        }
        else if (EnemyCard.CardType == "Slash" && (PlayerCard.CardType == "Counter" || PlayerCard.CardType == "Heavy"))
        {
            PlayerLife = PlayerLife - EnemyCard.CardDamage;
        }
        else if (EnemyCard.CardType == "Heavy" && PlayerCard.CardType == "Block")
        {
            PlayerLife = PlayerLife - EnemyCard.CardDamage;
        }
        else if (EnemyCard.CardType == "Block" && PlayerCard.CardType == "Slash")
        {
            // Causa estado Bloqueado en el Jugador
        }
        else if (EnemyCard.CardType == "Counter" && PlayerCard.CardType == "Heavy")
        {
            PlayerLife = PlayerLife - PlayerCard.CardDamage;
        }
        if (PlayerLife  <= 0 || EnemyLife <= 0)
        {
            EndBattle();
        }
    }
    
    public void TieSelection ()
    {
        int numeroAleatorio = Random.Range(1, 4);
        switch (numeroAleatorio)
        {           
            case 1:
                //Ganas
                EnemyLife = EnemyLife - LastCardDrawed.CardDamage;
                Debug.Log("win");
                break;
            case 2:
                //Pierdes
                PlayerLife = PlayerLife - LastCardDrawed.CardDamage; 
                Debug.Log("lose");
                break;
            case 3:
                //Empatas
                Debug.Log("tie");
                break;           
        }
        if (PlayerLife <= 0 || EnemyLife <= 0)
        {
            EndBattle();
        }
        TiePanel.SetActive(false);
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
        GameObject newCard = Instantiate(CardPrefab, CardPanel.transform);
        if (CardDrawed.CardDamage != 0)
        {
            newCard.transform.GetChild(1).GetComponent<Text>().text = CardDrawed.CardDamage + "";
        }
        newCard.transform.GetChild(2).GetComponent<Text>().text = CardDrawed.CardType;
        newCard.GetComponent<Button>().onClick.AddListener(delegate{Combat(CardDrawed,CardDraw());});
         
        return CardDrawed;
        
    }
    public void EndBattle()
    {
        Debug.Log("d");
        EndBattlePanel.SetActive(true);
        if ( PlayerLife > 0)
        {
            EndBatlleText.text = "VICTORY";
        }
        else
        {
            EndBatlleText.text = "DERROTA";
        }

        //Se crea un panel con mensaje que has ganado o perdido 
    }
    public void ExitBattle() 
    {
        SceneManager.LoadScene("PlayerScene");

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

