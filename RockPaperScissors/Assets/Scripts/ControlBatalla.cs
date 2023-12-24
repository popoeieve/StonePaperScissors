using System.Collections;
using UnityEngine.SceneManagement; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject EndWinBattlePanel;
    public GameObject Hero;
    public GameObject Enemy;
    public Sprite BlockImageSprite;
    public Sprite CounterImageSprite;
    public Sprite HeavyImageSprite;
    public Sprite SlashImageSprite;
    public float Timer;
    public Image LifeBar;
    public Image ExpBar;
    public TextMeshProUGUI currentExp;
    public TextMeshProUGUI nextLevelExp;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI expEarned;
    bool endedBattle = false;




    // Start is called before the first frame update
    void Start()
    {
        Level.text = "Level: "+PlayerPrefs.GetInt("Level", 0).ToString();
        currentExp.text= PlayerPrefs.GetInt("Experience", 0).ToString();
        nextLevelExp.text= (PlayerPrefs.GetInt("Level", 0)*25+75).ToString();
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
        PlayerLifeCounter.text = PlayerLife + "";
        EnemyLifeCounter.text = EnemyLife + "";
        if (!endedBattle) 
        {
            Timer += Time.deltaTime;
            LifeBar.GetComponent<Image>().fillAmount = Timer / 3.85f;
            if (Timer > 3.85)
            {
                Timer = 0;
                TimeOver();
            }
        }
        
    }       

    void Combat(Card PlayerCard, Card EnemyCard,GameObject newCard)
    {
        if (Timer >= 0.85f )
        {
            if (PlayerCard.CardType == "Block")
            {
                Hero.GetComponent<Animator>().SetTrigger("BlockedAttack");
            }
            if (PlayerCard.CardType == "Slash")
            {
                Hero.GetComponent<Animator>().SetTrigger("SlashAttack");
            }
            if (PlayerCard.CardType == "Heavy")
            {
                Hero.GetComponent<Animator>().SetTrigger("HeavyAttack");
            }
            if (PlayerCard.CardType == "Counter")
            {
                Hero.GetComponent<Animator>().SetTrigger("CounterAttack");
            }
            LastCardDrawed = PlayerCard;
            Debug.Log("Se hace combate");
            if (PlayerCard.CardType == EnemyCard.CardType && (PlayerCard.CardType != "Block" || PlayerCard.CardType != "Counter"))
            {
                TiePanel.SetActive(true);
            }
            else if (PlayerCard.CardType == "Slash" && (EnemyCard.CardType == "Counter" || EnemyCard.CardType == "Heavy"))
            {
                if (EnemyCard.CardType=="Counter") 
                {
                    Enemy.GetComponent<Animator>().SetTrigger("CounterAttack");
                }
                if (EnemyCard.CardType == "Heavy")
                {
                    Enemy.GetComponent<Animator>().SetTrigger("HeavyAttack");
                }
                EnemyLife = EnemyLife - PlayerCard.CardDamage;
            }
            else if (PlayerCard.CardType == "Heavy" && EnemyCard.CardType == "Block")
            {
                Enemy.GetComponent<Animator>().SetTrigger("BlockedAttack");
                EnemyLife = EnemyLife - PlayerCard.CardDamage;
            }
            else if (PlayerCard.CardType == "Block" && EnemyCard.CardType == "Slash")
            {
                Enemy.GetComponent<Animator>().SetTrigger("SlashAttack");
                EnemyLife = EnemyLife - EnemyCard.CardDamage;
            }
            else if (PlayerCard.CardType == "Counter" && EnemyCard.CardType == "Heavy")
            {
                Enemy.GetComponent<Animator>().SetTrigger("HeavyAttack");
                EnemyLife = EnemyLife - EnemyCard.CardDamage;
            }
            else if (EnemyCard.CardType == "Slash" && (PlayerCard.CardType == "Counter" || PlayerCard.CardType == "Heavy"))
            {
                if (EnemyCard.CardType == "Counter")
                {
                    Enemy.GetComponent<Animator>().SetTrigger("CounterAttack");
                }
                if (EnemyCard.CardType == "Heavy")
                {
                    Enemy.GetComponent<Animator>().SetTrigger("HeavyAttack");
                }
                PlayerLife = PlayerLife - EnemyCard.CardDamage;
            }
            else if (EnemyCard.CardType == "Heavy" && PlayerCard.CardType == "Block")
            {
                Enemy.GetComponent<Animator>().SetTrigger("BlockedAttack");
                PlayerLife = PlayerLife - EnemyCard.CardDamage;
            }
            else if (EnemyCard.CardType == "Block" && PlayerCard.CardType == "Slash")
            {
                Enemy.GetComponent<Animator>().SetTrigger("SlashAttack");
                PlayerLife = PlayerLife - PlayerCard.CardDamage;
            }
            else if (EnemyCard.CardType == "Counter" && PlayerCard.CardType == "Heavy")
            {
                Enemy.GetComponent<Animator>().SetTrigger("HeavyAttack");
                PlayerLife = PlayerLife - PlayerCard.CardDamage;
            }
            if (PlayerLife <= 0 || EnemyLife <= 0)
            {
                EndBattle();
            }
            CardDraw();

            Destroy(newCard);
            Timer = 0; 
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

        if (CardDrawed.CardType == "Block")
        {
            newCard.transform.GetChild(0).GetComponent<Image>().sprite = BlockImageSprite;
        }
        else if (CardDrawed.CardType == "Counter") 
        {
            newCard.transform.GetChild(0).GetComponent<Image>().sprite = CounterImageSprite;
        }
        else if (CardDrawed.CardType == "Heavy")
        {
            newCard.transform.GetChild(0).GetComponent<Image>().sprite = HeavyImageSprite;
        }
        else
        {
            newCard.transform.GetChild(0).GetComponent<Image>().sprite = SlashImageSprite;
        }
        newCard.GetComponent<Button>().onClick.AddListener(delegate{Combat(CardDrawed,CardEnemy(),newCard);});
        
        return CardDrawed;
        
    }
    public Card CardEnemy()
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

    public void EndBattle()
    {
        endedBattle = true;
        if ( PlayerLife <= 0)
        {
            EndBatlleText.text = "LOSE";
            EndBattlePanel.SetActive(true);
        }
        else if (EnemyLife <= 0)
        {
            EndWinBattlePanel.SetActive(true);
        }

        //Se crea un panel con mensaje que has ganado o perdido 
    }
    public void ExitBattle() 
    {
        SceneManager.LoadScene("PlayerScene");

    }
    public void TimeOver()
    {
        PlayerLife = PlayerLife - 5;
        EndBattle(); 
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
