using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TacticalMap : MonoBehaviour
{
    [SerializeField]
    private TacticalTile tilePrefab;
    public Dictionary<Vector2Int, TacticalTile> map;
    private static TacticalMap _instance;
    public static TacticalMap Instance { get { return _instance; } }

    void Awake() {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
        var tileMap = gameObject.GetComponentInChildren<Tilemap>();
        BoundsInt bounds = tileMap.cellBounds;
        map = new Dictionary<Vector2Int, TacticalTile>();

        //cycle through all tilemap cells and generate an interactive grid
        for(int z = bounds.max.z; z >= bounds.min.z; z--) //we want the highest-z tile to be playable as it is not buried under the others
        {
            for(int y = bounds.min.y; y <= bounds.max.y; y++)
            {
                for( int x = bounds.min.x; x <= bounds.max.x; x++)
                {
                    var tileLocation = new Vector3Int(x,y,z);
                    var tileKey = new Vector2Int(x,y);

                    if(tileMap.HasTile(tileLocation) && !map.ContainsKey(tileKey))
                    {
                        var overlayTile = Instantiate(tilePrefab, gameObject.transform);
                        var cellWorldPosition = tileMap.GetCellCenterWorld(tileLocation);
                        overlayTile.transform.position = new Vector3(cellWorldPosition.x,cellWorldPosition.y-0.25f,cellWorldPosition.z+0.6f);
                        overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder;
                        overlayTile.GridLocation = tileLocation;
                        map.Add(tileKey, overlayTile);
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        foreach(var i in map) {
            Destroy(i.Value.gameObject);
        }
        map.Clear();
    }
}