using UnityEngine;

public class Plant : MonoBehaviour
{
    float timer;
    GameObject flower;
    FlowerSO flowerSO;
    PlantGrower plantGrower;
    BoxCollider boxCollider;
    enum GrowingStates
    {
        Seed,
        Seedling,
        Grown,
        FullyGrown
    }
    GrowingStates growingState = GrowingStates.Seed;
    void Awake()
    {
        flowerSO = GameManager.Instance.plantToGrow;
        plantGrower = GetComponentInParent<PlantGrower>();
        boxCollider = GetComponent<BoxCollider>();
    }
    void Start()
    {
        boxCollider.enabled = false;
        flower = plantGrower.GrowPlant(flowerSO.seedPrefab, gameObject);
    }
    void OnEnable()
    {
        timer = Random.Range(15f, 20f);
    }
    void Update()
    {
        GetThursty();
    }
    public void OnMouseDown()
    {
        switch (growingState)
        {
            case GrowingStates.Seed:
                Watered();
                Destroy(flower);
                flower = plantGrower.GrowPlant(flowerSO.seedlingPrefab, gameObject);
                growingState = GrowingStates.Seedling;
                break;
            case GrowingStates.Seedling:
                Watered();
                Destroy(flower);
                flower = plantGrower.GrowPlant(flowerSO.prefab, gameObject);
                growingState = GrowingStates.Grown;
                break;
            case GrowingStates.Grown:
                Watered();
                Destroy(flower);
                flower = plantGrower.GrowPlant(flowerSO.fullyGrownPrefab, gameObject);
                growingState = GrowingStates.FullyGrown;
                break;
            case GrowingStates.FullyGrown:
                Watered();
                GameManager.Instance.CreateCard(flowerSO);
                plantGrower.isEmpty = true;
                Destroy(gameObject);
                break;
        }
    }
    void GetThursty()
    {
        if (timer <= 0)
        {
            if (plantGrower.potID == 1) GameManager.Instance.pot1Thursty = true;
            if (plantGrower.potID == 2) GameManager.Instance.pot2Thursty = true;
            if (plantGrower.potID == 3) GameManager.Instance.pot3Thursty = true;
            GameManager.Instance.IsThurtsy();
            boxCollider.enabled = true;
        }
        else timer -= Time.deltaTime;
    }
    void Watered()
    {
        if (plantGrower.potID == 1) GameManager.Instance.pot1Thursty = false;
        if (plantGrower.potID == 2) GameManager.Instance.pot2Thursty = false;
        if (plantGrower.potID == 3) GameManager.Instance.pot3Thursty = false;
        GameManager.Instance.IsThurtsy();
        boxCollider.enabled = false;
        timer = Random.Range(15f, 20f);
    }
}
