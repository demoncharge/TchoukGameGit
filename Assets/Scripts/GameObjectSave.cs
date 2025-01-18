using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSave : MonoBehaviour
{
    [System.Serializable]
    public class GameObjectState
    {
        public GameObject gameObject;
        public Vector3 initialPosition;
        public Quaternion initialRotation;
        public Vector3 initialScale;

        // Save additional attributes as needed
    }

    public List<GameObjectState> gameObjectsToTrack = new List<GameObjectState>();

    void Start()
    {
        // Save the initial state of each GameObject
        foreach (GameObjectState state in gameObjectsToTrack)
        {
            if (state.gameObject != null)
            {
                state.initialPosition = state.gameObject.transform.position;
                state.initialRotation = state.gameObject.transform.rotation;
                state.initialScale = state.gameObject.transform.localScale;
            }
        }
    }

    public void ResetGameObjects()
    {
        // Reset each GameObject to its initial state
        foreach (GameObjectState state in gameObjectsToTrack)
        {
            if (state.gameObject != null)
            {
                state.gameObject.transform.position = state.initialPosition;
                state.gameObject.transform.rotation = state.initialRotation;
                state.gameObject.transform.localScale = state.initialScale;
                
                // Reset additional attributes as needed
            }
        }
    }
}