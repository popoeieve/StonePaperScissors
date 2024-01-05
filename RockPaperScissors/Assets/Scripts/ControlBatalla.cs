using System.Collections;
using UnityEngine.SceneManagement; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controlbatalla : MonoBehaviour
{
    public Button Rock, Paper, Scissor, WinExitButton;
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
    bool wonBattle = false;
    int wonExperience = 180;




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
        generateEnemy();
        PlayerLife = 20;
        EnemyLife = 5;
        generateRandomItem(20, 40);


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
        if (wonBattle)
        {
            int currentExpInt = PlayerPrefs.GetInt("Experience", 0);
            float playerExperienceFloat = PlayerPrefs.GetInt("Experience", 0);
            float playerLevelUpFloat = PlayerPrefs.GetInt("Level", 0) * 25 + 75;
            float ratioExpIni= playerExperienceFloat/ playerLevelUpFloat;
            Timer += Time.deltaTime*(playerLevelUpFloat/2.7f);
            ExpBar.GetComponent<Image>().fillAmount= ratioExpIni;
            if (wonExperience>0 && Timer>1) 
            {
                wonExperience = wonExperience - 1;
                currentExpInt = currentExpInt + 1;
                Timer = 0;
            }
            expEarned.text = wonExperience.ToString();
            currentExp.text = currentExpInt.ToString();
            PlayerPrefs.SetInt("Experience", currentExpInt);
            Debug.Log(PlayerPrefs.GetInt("Experience", 0));
            if (ratioExpIni == 1) //The character levels up
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
                PlayerPrefs.SetInt("Experience", 0);
                PlayerPrefs.SetInt("ExtraStatPoints", PlayerPrefs.GetInt("ExtraStatPoints") + 1);
                PlayerPrefs.SetInt("ExtraPerkPoints", PlayerPrefs.GetInt("ExtraPerkPoints") + 1);
                currentExpInt = 0;
                currentExp.text = currentExpInt.ToString();
                Level.text = PlayerPrefs.GetInt("Level", 0).ToString();
                nextLevelExp.text = (PlayerPrefs.GetInt("Level", 0) * 25 + 75).ToString();
            }
            if(wonExperience==0)
            {
                WinExitButton.interactable = true;               
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
        if ( PlayerLife <= 0)
        {
            endedBattle = true;
            EndBatlleText.text = "LOSE";
            EndBattlePanel.SetActive(true);
        }
        else if (EnemyLife <= 0)
        {
            EndWinBattlePanel.SetActive(true);
            endedBattle = true;
            wonBattle = true;
        }

        //Se crea un panel con mensaje que has ganado o perdido 
    }
    public void ExitBattle() 
    {
        SceneManager.LoadScene("PlayerScene");

    }
    public void ExitWonBattle()
    {
        PlayerPrefs.SetInt("Experience", PlayerPrefs.GetInt("Experience") + wonExperience);
        SceneManager.LoadScene("PlayerScene");

    }
    public void TimeOver()
    {
        PlayerLife = PlayerLife - 5;
        EndBattle(); 
    }

    public void generateRandomItem(int itemLevel,int playerLevel)
    {
        int topRange = itemLevel + 10 + (playerLevel / 10);
        int botRange = itemLevel - 10 - (playerLevel / 10);
        int objectLevel = Random.Range(botRange, topRange);
        int itemTypeGenerator = Random.Range(1, 101);
        string itemType;
        if (itemTypeGenerator < 25)
        {
            itemType = "armor";
        }
        else if (itemTypeGenerator < 50)
        {
            itemType = "weapon";
        }
        else if (itemTypeGenerator < 75)
        {
            itemType = "shield";
        }
        else 
        {
            itemType = "boots";
        }

        Debug.Log(itemType);

        //return Item;


        /*
        HealthBonus = healthBonus;
        Damage = damage;
        StrengthBonus = strengthBonus;
        DefenseBonus = defenseBonus;
        DexterityBonus = dexterityBonus;
        CharismaBonus = charismaBonus;
        ExperienceBonus = experienceBonus;
        SpecialAbility = specialAbility;
        Price = price;
        ItemType = itemType;
        */
    }

    public Enemy generateEnemy() 
    {
        int playerLevel = PlayerPrefs.GetInt("Level");
        int randomInt = Random.Range(1, 101);
        if (randomInt < 60)
        {
            int topRange = playerLevel + 10+(playerLevel / 10);
            int botRange = playerLevel - 10-(playerLevel / 10);
            int normalEnemyLevel = Random.Range(botRange, topRange + 1); // El +1 es para incluir el límite superior
            if (normalEnemyLevel < 2) 
            {
                normalEnemyLevel = 1;
            }
            int enemyStrength = Random.Range(normalEnemyLevel/5, normalEnemyLevel + 1);
            int enemyDefense = normalEnemyLevel - enemyStrength;
            int enemyHealth = normalEnemyLevel * Random.Range(7,10);
            int enemyMoney = normalEnemyLevel * Random.Range(4,12);


            Enemy randomEnemy = new Enemy(enemyHealth,enemyStrength,enemyDefense,normalEnemyLevel,enemyMoney);

            return randomEnemy;
        }
        else if (randomInt < 85)
        {
            int topRange = playerLevel + 10 + (playerLevel / 8);
            int botRange = playerLevel;
            int normalEnemyLevel = Random.Range(botRange, topRange + 1); // El +1 es para incluir el límite superior
            if (normalEnemyLevel < 2)
            {
                normalEnemyLevel = 1;
            }
            int enemyStrength = Random.Range(normalEnemyLevel / 5, normalEnemyLevel + 1);
            int enemyDefense = normalEnemyLevel - enemyStrength;
            int enemyHealth = normalEnemyLevel * Random.Range(10, 15);
            int enemyMoney = normalEnemyLevel * Random.Range(9, 20);

            Enemy randomEnemy = new Enemy(enemyHealth, enemyStrength, enemyDefense, normalEnemyLevel, enemyMoney);

            return randomEnemy;
        }
        else if (randomInt < 99)
        {
            //enemigo legendario
            Enemy randomEnemy = new Enemy();
            return randomEnemy;
        }
        else 
        {
            //enemigo dios
            Enemy randomEnemy = new Enemy();
            return randomEnemy;
        }


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

public class Enemy 
{
    private int Health { get; set; }
    private int Strength { get; set; }
    private int Defense { get; set; }
    private int Level { get; set; }
    private string Ability { get; set; }
    private Item Loot { get; set; }
    private int Money { get; set; }

    public Enemy()
    {
       
    }
    public Enemy(int health, int strength, int defense, int level, int money)
    {
        Health = health;
        Strength = strength;
        Defense = defense;
        Level = level;
        Money = money;
    }

    public Enemy(int health, int strength, int defense, int level, string ability, Item loot, int money)
    {
        Health = health;
        Strength = strength;
        Defense = defense;
        Level = level;
        Ability = ability;
        Loot = loot;
        Money = money;
    }
}

public class Item
{
    private int HealthBonus { get; set; }
    private int Damage { get; set; }
    private int StrengthBonus { get; set; }
    private int DefenseBonus { get; set; }
    private int DexterityBonus { get; set; }
    private int CharismaBonus { get; set; }
    private int ExperienceBonus { get; set; }
    private string SpecialAbility { get; set; }
    private int Price { get; set; }
    private string ItemType { get; set; }

    public Item(int healthBonus,int damage, int strengthBonus, int defenseBonus, int dexterityBonus, int charismaBonus, int experienceBonus,string specialAbility, int price,string itemType)
    {
        HealthBonus = healthBonus;
        Damage = damage;
        StrengthBonus = strengthBonus;
        DefenseBonus = defenseBonus;
        DexterityBonus = dexterityBonus;
        CharismaBonus = charismaBonus;
        ExperienceBonus = experienceBonus;
        SpecialAbility = specialAbility;
        Price = price;
        ItemType = itemType;
    }
}


