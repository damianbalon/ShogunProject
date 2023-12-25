    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TacticalTile : MonoBehaviour
    {
        private Vector3Int gridLocation;
        public Vector3Int GridLocation {
            get {return gridLocation;}
            set {gridLocation = value;}
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void ShowTile()
        {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

         public void ShowTileFaint()
         {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
         }

         public void HideTile()
         {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
         }

    
    }
