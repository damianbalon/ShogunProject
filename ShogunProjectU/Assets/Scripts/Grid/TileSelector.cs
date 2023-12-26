using UnityEngine;

public class TileSelector : MonoBehaviour
{
    private Camera mainCamera;
    private TacticalMap tacticalMap;
    private TacticalTile pewiesTacticaltile;

    private void Start()
    {
        mainCamera = Camera.main;
        tacticalMap = GetComponent<TacticalMap>();
    }

    private void Update()
    {
        
    }

    public TacticalTile GetMouseoverTile() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

            System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));
        if (hits.Length > 0)
        {
            return hits[hits.Length - 1].collider.GetComponent<TacticalTile>();
        }
        Debug.Log("Nothing clicked");
        return null;
    }
}
