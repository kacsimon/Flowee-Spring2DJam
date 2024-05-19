using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static event EventHandler OnPlanted;

    [HideInInspector] public FlowerSO plantToGrow;
    [SerializeField] GameObject pot1Water, pot2Water, pot3Water;
    [HideInInspector] public bool pot1Thursty, pot2Thursty, pot3Thursty;
    [SerializeField] GameObject[] flowerCards;
    [SerializeField] GameObject catalogue;
    public Transform selectedPrefab;
    [HideInInspector] public Transform selected;

    int coin = 15;
    public int Coin { get { return coin < 0 ? 0 : coin; } private set { coin = value; } }
    [SerializeField] TMP_Text coinText;

    void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        #endregion
        Coin = coin;
        pot1Water.SetActive(false);
        pot2Water.SetActive(false);
        pot3Water.SetActive(false);
    }
    void Start()
    {
        UpdateUI();
    }
    public void IsThurtsy()
    {
        if (pot1Thursty) pot1Water.SetActive(true); else pot1Water.SetActive(false);
        if (pot2Thursty) pot2Water.SetActive(true); else pot2Water.SetActive(false);
        if (pot3Thursty) pot3Water.SetActive(true); else pot3Water.SetActive(false);
    }
    public void CreateCard(FlowerSO _flower)
    {
        for (int i = 0; i < flowerCards.Length; i++)
        {
            FlowerCard flowerCard = flowerCards[i].GetComponent<FlowerCard>();
            if (flowerCard.flowerSO == _flower)
            {
                flowerCard.imageColor = Color.white;
                flowerCard.SetCardData();
            }
        }
    }
    void UpdateUI()
    {
        coinText.text = Coin.ToString();
    }
    public void AddCoinToText(int _coin)
    {
        StartCoroutine(CountCoin(_coin));
        //Check what can buy
    }
    public IEnumerator CountCoin(int _coin)
    {
        int scoreToBe = Coin + _coin;
        while (Coin != scoreToBe)
        {
            Coin = _coin > 0 ? Coin + 1 : Coin - 1;
            UpdateUI();
            yield return new WaitForSeconds(.01f);
            OnPlanted?.Invoke(this, EventArgs.Empty);
        }
    }
}