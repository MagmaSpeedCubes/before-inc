using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get all overlapping colliders at mouse position
            Collider2D[] hits = Physics2D.OverlapPointAll(mouseWorldPos);

            foreach (Collider2D hit in hits)
            {
                // Optional: only process objects with this component
                MapRegion mapRegion = hit.GetComponent<MapRegion>();
                if (mapRegion != null && mapRegion.IsPixelVisible(mouseWorldPos))
                {
                    if (GameInfo.selectedMapRegion != null)
                    {
                        GameInfo.selectedMapRegion.Deselect();
                    }
                    Debug.Log("Region Selected: " + hit.gameObject.name);
                    mapRegion.Select();
                    break; // Stop after first visible pixel match
                }
            }
            


        }
    }
}
