using UnityEngine;

public class SelectTile : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

            System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

            if (hits.Length > 0)
            {
                TacticalTile tacticalTile = hits[hits.Length - 1].collider.GetComponent<TacticalTile>();

                if (pewiesTacticaltile != null)
                {
                    pewiesTacticaltile.HideTile();
                }

                if (tacticalTile != null)
                {
                    tacticalTile.ShowTile();
                    pewiesTacticaltile = tacticalTile;
                }
            }
        }
    }
}
