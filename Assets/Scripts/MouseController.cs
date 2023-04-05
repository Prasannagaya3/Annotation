using UnityEngine;

public class MouseController : MonoBehaviour
{
    public LayerMask LayerHit;
    private Vector3 WorldPosition;
    private RaycastHit hit;
    private Ray ray;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, float.MaxValue, LayerHit))
        {
            WorldPosition = hit.point;
            if(Input.GetMouseButtonDown(0))
            {
                UIController.UIControl.AnnotationAdded(WorldPosition);
            }
        }
    }
}
