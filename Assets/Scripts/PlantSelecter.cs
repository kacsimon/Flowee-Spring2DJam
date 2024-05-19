using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantSelecter : MonoBehaviour
{
    [SerializeField] FlowerSO plantToGrow;
    [SerializeField] TMP_Text costText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] Button button;

    void Start()
    {
        costText.text = plantToGrow.cost.ToString();
        nameText.text = plantToGrow.flowerName;
        CanBuy();
        GameManager.OnPlanted += GameManager_OnPlanted;
    }
    void GameManager_OnPlanted(object sender, System.EventArgs e)
    {
        ClearSelection();
        CanBuy();
    }
    public void SelectFlower()
    {
        if (GameManager.Instance.plantToGrow == plantToGrow)
        {
            GameManager.Instance.plantToGrow = null;
            ClearSelection();
        }
        else
        {
            GameManager.Instance.plantToGrow = plantToGrow;
            ClearSelection();
            //Show Selected
            GameManager.Instance.selected = Instantiate(GameManager.Instance.selectedPrefab, transform);
        }
    }
    void ClearSelection()
    {
        if (GameManager.Instance.selected != null) Destroy(GameManager.Instance.selected.gameObject);
    }
    void CanBuy()
    {
        button.interactable = GameManager.Instance.Coin >= plantToGrow.cost;
        Debug.Log(GameManager.Instance.Coin);
    }
}
