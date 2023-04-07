using Dummiesman;
using UnityEngine;
using System.IO;
using TMPro;

public class LoadModel : MonoBehaviour
{
    public static LoadModel DynamicModel;
    [HideInInspector] public GameObject LoadedObject;

    private void Start()
    {
        DynamicModel = this;
    }

    public void LoadObject()
    {
        UIController.UIControl.ObjectPath = UIController.UIControl.ObjectPathInput.text + UIController.UIControl.ObjectName;

        if (!File.Exists(UIController.UIControl.ObjectPath))
        {
            UIController.UIControl.MessageForLoadedObject(1);
        }
        else
        {
            if(LoadedObject != null)
            {
                Destroy(LoadedObject);
            }
            LoadedObject = new OBJLoader().Load(UIController.UIControl.ObjectPath);
            UIController.UIControl.UIPanelActivation(1);
            UIController.UIControl.MessageForLoadedObject(2);
            NewTransformValue();
            CreateColliderForChild();
        }
    }

    private void NewTransformValue()
    {
        LoadedObject.transform.position = new Vector3(0, 0, 0);
        LoadedObject.transform.rotation = Quaternion.Euler(0, 125f, 0);
        LoadedObject.AddComponent<ModelGameplay>();
    }

    private void CreateColliderForChild()
    {
        foreach (Transform childObject in LoadedObject.transform)
        {
            int layerName = LayerMask.NameToLayer("Environment");

            childObject.gameObject.layer = layerName;

            Mesh mesh = childObject.gameObject.GetComponent<MeshFilter>().mesh;

            if (mesh != null)
            {
                MeshCollider meshCollider = childObject.gameObject.AddComponent<MeshCollider>();

                meshCollider.sharedMesh = mesh;

                //meshCollider.convex = true;
            }
        }
    }
}
