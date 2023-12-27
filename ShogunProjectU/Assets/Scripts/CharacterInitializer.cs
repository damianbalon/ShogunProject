using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInitializer : MonoBehaviour//this class automatically aligns a character with a tile it was placed on in editor. It destroys itself once it's done its purpose to free up resources
{
    CharacterMove character;
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<CharacterMove>();
        if(character.OccupiedTile != null) Destroy(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(character.OccupiedTile != null) Destroy(this);
        LayerMask mask = LayerMask.NameToLayer("Tactical");
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position,Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("Tactical"));
        if(hits.Length > 0)
        {
            System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));
            RaycastHit2D hit = hits[hits.Length - 1];
            Debug.Log("Liczba trafeń: " + hits.Length);
            Debug.Log(hit.collider.gameObject);
            character.MoveOnTile(hit.collider.gameObject.GetComponent<TacticalTile>());
            Destroy(this);
        }
        else {
            Debug.Log("To by nic nie dało");
            //Destroy(gameObject);
        }
    }
}