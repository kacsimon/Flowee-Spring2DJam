using UnityEngine;

public class PlantSelecter : MonoBehaviour
{
    [SerializeField] FlowerSO plantToGrow;

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
}
