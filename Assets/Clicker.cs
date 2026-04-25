using UnityEngine;

public class Clicker : MonoBehaviour
{ 
    public float maxDistance = 100f;

    private Camera targetObject;
    public RectTransform displayRect;
    private Camera uiCamera = null;
    Ray _ray;
    RaycastHit _hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetObject = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var camera = Camera.main;
        Vector3 mousepos = Input.mousePosition;
        Vector3 viewportPoint = camera.ScreenToViewportPoint(mousepos);

        bool inside = RectTransformUtility.ScreenPointToLocalPointInRectangle(displayRect, Input.mousePosition, uiCamera, out Vector2 localPoint);
        Rect r = displayRect.rect;
        float nx = (localPoint.x - r.x) / r.width;
        float ny = (localPoint.y - r.y) / r.height;
        viewportPoint = new Vector3(nx, ny, 0f);

        Debug.DrawRay(_ray.origin, _ray.direction * maxDistance, Color.red);
        Debug.DrawLine(_ray.origin, _hit.point, Color.green);

        _ray = camera.ViewportPointToRay(viewportPoint);
       if (Physics.Raycast(_ray, out _hit, maxDistance))
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseAct interactable = _hit.collider.gameObject.GetComponent<MouseAct>();

                if (interactable != null)
                {
                    interactable.OnClickAction();
                }
            }


        }
    }
}
