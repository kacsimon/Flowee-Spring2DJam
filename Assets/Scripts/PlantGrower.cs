using System;
using UnityEngine;

public class PlantGrower : MonoBehaviour
{
    [SerializeField] Transform growPlace;
    [SerializeField] GameObject plant;
    [HideInInspector] public bool isEmpty = true;
    public int potID;
    void OnMouseDown()
    {
        if (isEmpty)
        {
            if (GameManager.Instance.plantToGrow == null) return;
            GameManager.Instance.AddCoinToText(-GameManager.Instance.plantToGrow.cost);
            Instantiate(plant, gameObject.transform);
            isEmpty = false;
        }
    }
    public GameObject GrowPlant(GameObject _plantToGrow, GameObject _parent)
    {
        return Instantiate(_plantToGrow, new Vector3(growPlace.position.x, _plantToGrow.transform.position.y, _plantToGrow.transform.position.z), _plantToGrow.transform.rotation, _parent.transform);
    }
}
