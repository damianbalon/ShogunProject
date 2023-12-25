using UnityEngine;

public class TileSelector : MonoBehaviour
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
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
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
