    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TacticalTile : MonoBehaviour
    {
        private GameObject occupyingObject;

        public GameObject OccupyingObject {
            get {return occupyingObject;}
            set {occupyingObject = value;}
        }

        public bool isBlocked {
            get {return occupyingObject != null;}
        }

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
    }
