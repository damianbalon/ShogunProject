using UnityEngine;

public class SelectTile : MonoBehaviour
{
    private Camera mainCamera;
    private TacticalMap tacticalMap;

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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                TacticalTile tacticalTile = hit.collider.GetComponent<TacticalTile>();

                if (tacticalTile != null)
                {
                    tacticalTile.ShowTile();
                }
            }
        }
    }
}
