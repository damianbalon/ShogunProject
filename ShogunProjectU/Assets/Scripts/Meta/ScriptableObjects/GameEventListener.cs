    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class GameEventListener : MonoBehaviour
    {
         public GameEvent Event;
        public UnityEvent Response;
        private void OnEnable()
        {Event.RegisterListener(this);}
        private void OnDisable()
        {Event.UnregisterListener(this);}
        public virtual void OnEventRaised() //virtual will allow for coded responses with custom listeners. Still not sure if this is a good idea.
        {Response.Invoke();}

    }