using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMove : MonoBehaviour
{

    public float speed = 5f;
    private Animator animator;
    new private Rigidbody2D rigidbody2D;
    private TacticalTile occupiedTile;
    public TacticalTile OccupiedTile {
        get {return occupiedTile;}
    }
    public TacticalTile originTile;
    private GameObject positionMarker;
    private float yOffset;

    private List<TacticalTile> path = new List<TacticalTile>();
    public List<TacticalTile> Path {
        set {
            path = new List<TacticalTile>(value);
            //value.RemoveAll(null);
            if(value.Count > 0) RegisterOccupant(value[value.Count - 1]);
            else Debug.LogWarning("Empty path passed; ignoring");
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        positionMarker = new GameObject("Position marker(" + name + ")");
    }

    void Update()
    {
        MoveAlongPath();
    }

    void HandleMovementInput() //chyba do testowania obracania postaci
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        if (movement != Vector2.zero)
        {
            //animator.SetFloat("MoveX", movement.x);
            //animator.SetFloat("MoveY", movement.y);
        }

        rigidbody2D.velocity = movement * speed;
    }

    private void MoveAlongPath()
    {
        if (path.Count > 0)
        {
            TacticalTile targetTile = path[0];
            Vector2 startPosition = originTile.transform.position;

            positionMarker.transform.position = new Vector2(transform.position.x, transform.position.y - yOffset);

            float step = speed * Time.deltaTime;
            float distanceToTarget = Vector2.Distance(positionMarker.transform.position, targetTile.transform.position);
            float xFraction = distanceToTarget / Vector2.Distance(originTile.transform.position, targetTile.transform.position);
            yOffset = ((-Mathf.Pow(((xFraction - 0.5f) * 2), 2)) + 1) * 0.5f;

            positionMarker.transform.position = Vector2.MoveTowards(positionMarker.transform.position, targetTile.transform.position, step);
            transform.position = new Vector3(positionMarker.transform.position.x, positionMarker.transform.position.y + yOffset, targetTile.transform.position.z + 1.4f);

            if (Vector2.Distance(transform.position, targetTile.transform.position) < 0.01f)
            {
                MoveOnTile(targetTile);

                path.RemoveAt(0);

                if (path.Count > 0)
                {
                    //animator.SetFloat("gridXChange", path[0].GridLocation.x - originTile.GridLocation.x);
                    //animator.SetFloat("gridYChange", path[0].GridLocation.y - originTile.GridLocation.y);
                }

                
            }
        }
    }

    private void UnregisterOccupant() {
        if(occupiedTile != null) {
            if(occupiedTile.OccupyingObject == gameObject) occupiedTile.OccupyingObject = null;
            occupiedTile = null;
        }
    }

    private void RegisterOccupant(TacticalTile tile) {
        if(occupiedTile != null) UnregisterOccupant();
        tile.OccupyingObject = gameObject;
        occupiedTile = tile;
    }

    public void MoveOnTile(TacticalTile tile)
    {
        transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z + 1.3f);
        GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;

        if(path.Count == 0) RegisterOccupant(tile);
        originTile = tile;

        yOffset = 0;
        positionMarker.transform.position = transform.position;
    }

    public void MoveTowardsActive(ActiveTileManager from) {
        path = Pathfinder.FindPath(originTile, (from.ActiveTile));
    }

    public void MoveTowardsTile(TacticalTile tile) //???
    {
        if (path.Count > 0)
        {
            for (int i = path.Count - 1; i > 0; i--)
                path.RemoveAt(i);

            path.Add(tile);
        }
        else
        {
            path.Add(tile);
        }

        while (path.Count > 0 && path[0] == null)
        {
            path.RemoveAt(0);
            Debug.LogError("Null path point");
        }

        if (path.Count > 0)
        {
            //animator.SetFloat("gridXChange", path[0].GridLocation.x - originTile.GridLocation.x);
            //animator.SetFloat("gridYChange", path[0].GridLocation.y - originTile.GridLocation.y);
        }
    }
}
