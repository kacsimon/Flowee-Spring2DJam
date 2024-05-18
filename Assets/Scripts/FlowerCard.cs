using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlowerCard : MonoBehaviour
{
    public FlowerSO flowerSO;
    [SerializeField] Image image;
    [SerializeField] TMP_Text flowerName;
    [SerializeField] TMP_Text description;
    [HideInInspector] public Color imageColor = Color.black;
    public void SetCardData()
    {
        image.sprite = flowerSO.sprite;
        flowerName.text = flowerSO.flowerName;
        description.text = flowerSO.description;
        image.color = imageColor;
    }
}