using UnityEngine;

public class VisualMouse : MonoBehaviour
{
    private float rot, speed;
    private Vector3 storePos;

    void Start()
    {
        speed = 100.0f;
        storePos = gameObject.transform.eulerAngles;
    }

    void Update()
    {
        rot = Input.GetAxis("Mouse ScrollWheel") * speed;

        if (rot != 0)
        {
            storePos = new Vector3(0, storePos.y + rot, 0);
            transform.eulerAngles = storePos;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
