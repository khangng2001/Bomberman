using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    public KeyCode inputKey = KeyCode.Space;
    public GameObject bombPrefab;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;
    private int bombsRemaining;

    [Header("Explosion")]
    public Explosion explosionPrefab;
    public float explosionDuration= 1f;
    public int explosionRadius = 1;
    public LayerMask explosionLayerMask;

    [Header("Destructible")]
    public Destructible destructiblePrefab;
    public Tilemap destructibleTiles;
    
    private void OnEnable() 
    {
        bombsRemaining = bombAmount;
    }

    private void Update()
    {
        if (bombsRemaining > 0 && Input.GetKeyDown(inputKey)) {
            StartCoroutine(PlaceBomb());
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombsRemaining--;

        yield return new WaitForSeconds(bombFuseTime);
        Vector2 explosionPos = bomb.transform.position;

        // Maybe dont need as the transform of our tilemap is not the same in the video
        /*        position.x = Mathf.Round(explosionPos.x);
                position.y = Mathf.Round(explosionPos.y);*/

        Explosion explosion = Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);
        explosion.DestroyAfter(explosionDuration);

        Explode(explosionPos, Vector2.up, explosionRadius);
        Explode(explosionPos, Vector2.down, explosionRadius);
        Explode(explosionPos, Vector2.left, explosionRadius);
        Explode(explosionPos, Vector2.right, explosionRadius);

        Destroy(bomb);
        bombsRemaining++;
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if (length <= 0)
        {
            return;
        }

        position += direction;
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            ClearDestructible(position);
            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(length > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, direction, length - 1);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            collision.isTrigger = false;
        }
    }
    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if (tile!=null)
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell, null);
        }
    }

    public void AddBomb(){
        bombsRemaining++;
    }

    public void DecreaseBomb()
    {
        if (bombsRemaining <= 0)
        {
            bombsRemaining = bombAmount;
        }
        else
        {
            bombsRemaining--;
        }
    }

    public void FireDown()
    {
        if (explosionRadius <= 1)
        {
            explosionRadius = 1;
        }
        else
        {
            explosionRadius--;
        }
    }
    
}
