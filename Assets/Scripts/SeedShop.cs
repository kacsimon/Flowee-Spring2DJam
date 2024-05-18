using UnityEngine;

public class SeedShop : MonoBehaviour
{
    public void ToggleShop()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
