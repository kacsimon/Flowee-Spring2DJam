using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [HideInInspector] public FlowerSO plantToGrow;
    [SerializeField] GameObject pot1Water, pot2Water, pot3Water;
    [HideInInspector] public bool pot1Thursty, pot2Thursty, pot3Thursty;
    [SerializeField] GameObject[] flowerCards;
    [SerializeField] GameObject catalogue;
    public Transform selectedPrefab;
    [HideInInspector] public Transform selected;

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
        pot1Water.SetActive(false);
        pot2Water.SetActive(false);
        pot3Water.SetActive(false);
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
}
