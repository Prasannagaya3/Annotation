using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PrefabController : MonoBehaviour
{
    public GameObject DetailsPanel;
    public TextMeshProUGUI PinCount, DetailText;
    private Camera LookAtTransform;

    private void Start()
    {
        PinCount.text = UIController.UIControl.PointCount.ToString();
        DetailText.text = "Mark_ " + UIController.UIControl.PointCount.ToString();
        UpdatePanel(false);
    }

    public void UpdatePanel(bool state)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 1)
        {
            DetailsPanel.SetActive(state);
        }
    }

    private void LateUpdate()
    {
        LookAtTransform = Camera.main;
        this.transform.LookAt(this.transform.position + LookAtTransform.transform.rotation * Vector3.forward, LookAtTransform.transform.rotation * Vector3.up);
    }
}
