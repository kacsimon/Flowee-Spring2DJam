using UnityEngine;

[CreateAssetMenu(fileName = "Flower")]
public class FlowerSO : ScriptableObject
{
    public int id;
    public string flowerName;
    public string description;
    public GameObject seedPrefab; //or Transform
    public GameObject seedlingPrefab;
    public GameObject prefab;
    public GameObject fullyGrownPrefab;
    public Sprite sprite;
}
