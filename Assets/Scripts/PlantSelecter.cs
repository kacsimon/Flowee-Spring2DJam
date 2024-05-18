using UnityEngine;

public class PlantSelecter : MonoBehaviour
{
    [SerializeField] FlowerSO plantToGrow;

    public void SelectFlower()
    {
        if (GameManager.Instance.plantToGrow == plantToGrow)
        {
            GameManager.Instance.plantToGrow = null;
            //Don't show selected
        }
        else
        {
            GameManager.Instance.plantToGrow = plantToGrow;
            //Show Selected
        }
    }
}
