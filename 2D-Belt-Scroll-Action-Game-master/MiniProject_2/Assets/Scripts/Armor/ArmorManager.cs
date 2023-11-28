using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArmorModel
{
    private string name;
    private int hpUP;
    private int mpUp;
    private int defUp;
    private int price;
    private Sprite img;

    public ArmorModel(string name, int hpUP, int mpUp, int defUp, int price, Sprite img)
    {
        this.name = name;
        this.hpUP = hpUP;
        this.mpUp = mpUp;
        this.defUp = defUp;
        this.price = price;
        this.img = img;
    }

    public string Name { get => name; set => name = value; }
    public int HpUP { get => hpUP; set => hpUP = value; }
    public int MpUp { get => mpUp; set => mpUp = value; }
    public int DefUp { get => defUp; set => defUp = value; }
    public int Price { get => price; set => price = value; }
    public Sprite Img { get => img; set => img = value; }
}

public class ArmorManager : MonoBehaviour
{
    [SerializeField]
    private static GameObject[] PlayerArmor = new GameObject[7];
    private static GameObject Player;
    [SerializeField]
    private static int ArmorIndex;
    public Sprite[] ArmorItem;
    public Image ArmorImg = null;
    public Text ArmorName = null;
    public Text ArmorStat1 = null;
    public Text ArmorStat2 = null;
    public Text ArmorPrice = null;

    public GameObject sold = null;

    private static int currentHP = 0;
    private static int currentMP = 0;
    private static int currentDEF = 0;

    public static int nowArmor = -1;
    static string name = "";
    private static int hp = 0;
    private static int mp = 0;
    private static int def = 0;
    private int price = 0;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < PlayerArmor.Length; i++)
        {
            switch (i)
            {
                case 0:
                    PlayerArmor[i] = GameObject.Find("Player/Bone/Body"); break;
                case 1:
                    PlayerArmor[i] = GameObject.Find("Player/Bone/Body/R_Arm/upper"); break;
                case 2:
                    PlayerArmor[i] = GameObject.Find("Player/Bone/Body/R_Arm/upper/lower"); break;
                case 3:
                    PlayerArmor[i] = GameObject.Find("Player/Bone/Leg/R_Leg/upper"); break;
                case 4:
                    PlayerArmor[i] = GameObject.Find("Player/Bone/Body/L_Arm/upper"); break;
                case 5:
                    PlayerArmor[i] = GameObject.Find("Player/Bone/Body/L_Arm/upper/lower"); break;
                case 6:
                    PlayerArmor[i] = GameObject.Find("Player/Bone/Leg/L_Leg/upper"); break;
            }
        }
        Player = GameObject.FindWithTag("Player");
    }

    public void SetArmor()
    {
        if (price <= HaveCoin.Coin) {
            if (ArmorIndex == 0)
            {
                Sprite[] armor = Player.GetComponent<ArmorSet>().Armor[ArmorIndex];
                for (int i = 0; i < 7; i++)
                    PlayerArmor[i].GetComponent<SpriteRenderer>().sprite = armor[i];
                NowArmor.n_armor = armor[7];
                NowArmor.n_aName = name;
                nowArmor = 0;
                setStatus();
            }
            else if (ArmorIndex == 1)
            {
                Sprite[] armor = Player.GetComponent<ArmorSet>().Armor[ArmorIndex];
                for (int i = 0; i < 7; i++)
                    PlayerArmor[i].GetComponent<SpriteRenderer>().sprite = armor[i];
                NowArmor.n_armor = armor[7];
                NowArmor.n_aName = name;
                nowArmor = 1;
                setStatus();
            }
            HaveCoin.Coin -= price;
            sold.SetActive(true);
        }
    }

    public void SetRandomArmor()
    {
        ArmorIndex = Random.Range(0, 2);
        if (ArmorIndex == 0)
        {
            name = "Diving Suit";
            hp = 20;
            mp = 10;
            def = 2;
            price = Random.Range(100, 150);
            Sprite img = ArmorItem[0];
            ArmorModel model = new ArmorModel(name, hp, mp, def, price, img);
            ArmorImg.sprite = model.Img;
            ArmorName.text = model.Name;
            ArmorStat1.text = model.HpUP + "/" + model.MpUp;
            ArmorStat2.text = "" + model.DefUp;
            ArmorPrice.text = "" + model.Price;
            Debug.Log(def + " - " + hp + " - " + mp);
        }
        else if (ArmorIndex == 1)
        {
            name = "Tropical Party";
            hp = 50;
            mp = 30;
            def = 5;
            price = Random.Range(250, 350);
            Sprite img = ArmorItem[1];
            ArmorModel model = new ArmorModel(name, hp, mp, def, price, img);
            ArmorImg.sprite = model.Img;
            ArmorName.text = model.Name;
            ArmorStat1.text = model.HpUP + "/" + model.MpUp;
            ArmorStat2.text = "" + model.DefUp;
            ArmorPrice.text = "" + model.Price;
        }
    }

    public static void setStatus()
    {
        PlayerMovement player = Player.GetComponent<PlayerMovement>();
        player.ChangeArmorDEF(currentDEF, currentHP, currentMP);
        currentHP = hp;
        currentMP = mp;
        currentDEF = def;
        player.GetArmorDEF(def, hp, mp);
    }


    public static int NowDBArmor()
    {
        return nowArmor;
    }

    public static void DBLoadArmor(int load)
    {
        if (load != -1)
        {
            if (load == 0)
            {
                nowArmor = 0;
                Sprite[] armor = Player.GetComponent<ArmorSet>().Armor[load];
                for (int i = 0; i < 7; i++)
                    PlayerArmor[i].GetComponent<SpriteRenderer>().sprite = armor[i];

                name = "Diving Suit";
                hp = 20;
                mp = 10;
                def = 2;
                currentHP = hp;
                currentMP = mp;
                currentDEF = def;
            }
            else if (load == 1)
            {
                nowArmor = 1;
                Sprite[] armor = Player.GetComponent<ArmorSet>().Armor[load];
                for (int i = 0; i < 7; i++)
                    PlayerArmor[i].GetComponent<SpriteRenderer>().sprite = armor[i];
                name = "Tropical Party";
                hp = 50;
                mp = 30;
                def = 5;
                currentHP = hp;
                currentMP = mp;
                currentDEF = def;
            }

            setStatus();
        }
        else
            nowArmor = -1;
    }
}
