using UnityEngine;

public class PlantSelecter : MonoBehaviour
{
    [SerializeField] FlowerSO plantToGrow;

    public void SelectFlower()
    {
        if (GameManager.Instance.plantToGrow == null)
        {
            GameManager.Instance.plantToGrow = plantToGrow;
            //Show Selected
        }
        else
        {
            GameManager.Instance.plantToGrow = null;
            //Don't show selected
        }
    }
}
