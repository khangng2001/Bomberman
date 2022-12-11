using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        FireUp,
        SpeedIncrease,
        SpeedDecrease,
        FireDown,

    }
    public ItemType itemType; 

    private void OnPickUp(GameObject player){
        switch (itemType)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                break;
            case ItemType.FireUp:
                player.GetComponent<BombController>().explosionRadius++;
                break;
            case ItemType.FireDown:
                player.GetComponent<BombController>().FireDown();
                break;
            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().speed++;
                break;
            case ItemType.SpeedDecrease:
                player.GetComponent<MovementController>().DecreaseSpeed();
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            OnPickUp(other.gameObject);
            Destroy(gameObject);
        }
    }
}
