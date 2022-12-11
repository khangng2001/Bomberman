using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    
    public float destructionTime = 1f;
    public GameObject[] itemList;
    public float spawnChance;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
        
    }

    private void OnDestroy() {
        if (itemList.Length > 0 && spawnChance > Random.value)
        {
            int randomIndex = Random.Range(0, itemList.Length);
            Instantiate(itemList[randomIndex], gameObject.transform.position, Quaternion.identity);
            
        }    
    }
}
