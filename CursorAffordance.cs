using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D enemyCursor = null;
    [SerializeField] Texture2D unknownCursor = null;
    [SerializeField] Vector2 cursorHotSpot =  Vector2.zero;

    CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start () {
        cameraRaycaster = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {
        // print(cameraRaycaster.layerHit);
        switch (cameraRaycaster.layerHit)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, cursorHotSpot, CursorMode.ForceSoftware);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(enemyCursor, cursorHotSpot, CursorMode.ForceSoftware);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(unknownCursor, cursorHotSpot, CursorMode.ForceSoftware);
                break;
            default:
                Debug.LogError("Don't know what cursor to show");
                return;

        }

	}
}
