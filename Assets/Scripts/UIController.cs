using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController UIControl;
    public string ObjectPath, ObjectName;
    [HideInInspector] public GameObject[] UIPanel;
    [HideInInspector] public GameObject PinPoint;
    [HideInInspector] public TextMeshProUGUI LoadMessage, AnnotationLimit;
    [HideInInspector] public TMP_InputField ObjectPathInput;
    [HideInInspector] public List<GameObject> AddedPoint;
    [HideInInspector] public int PointCount;
    [HideInInspector] public bool CanStart;

    private void Start()
    {
        PointCount = 0;
        UIControl = this;
        UIPanelActivation(0);
        MessageForLoadedObject(0);
    }

    public void AnnotationAdded(Vector3 Position)
    {
        if(PointCount <= 4)
        {
            PointCount++;
            GameObject CurrentObject = Instantiate(PinPoint, Position, Quaternion.identity);
            CurrentObject.transform.SetParent(LoadModel.DynamicModel.LoadedObject.transform);
            AddedPoint.Add(CurrentObject);
            if(PointCount == 5)
            {
                CanStart = true;
                AnnotationLimit.text = "Limit Reached";
            }
        }
    }

    public void UIPanelActivation(int count)
    {
        for(int i = 0; i < UIPanel.Length; i++)
        {
            if(i == count)
            {
                UIPanel[i].SetActive(true);
            }
            else
            {
                UIPanel[i].SetActive(false);
            }
        }
    }

    public void MessageForLoadedObject(int count)
    {
        switch(count)
        {
            case 0:
                LoadMessage.text = string.Empty;
                break;
            case 1:
                LoadMessage.text = "File doesn't exists";
                break;
            case 2:
                LoadMessage.text = "Successfully loaded";
                break;
        }
    }
}
