using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HaveCoin : MonoBehaviour
{
    public Text coinText = null;

    public static int Coin = 350;

    private void Awake()
    {
        if (coinText == null)
            coinText = GetComponent<Text>();
    }

    void Update()
    {
        coinText.text = Coin.ToString();
    }
}
