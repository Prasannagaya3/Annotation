using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelGameplay : MonoBehaviour
{
    public static ModelGameplay instance;

    private void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && UIController.UIControl.CanStart)
        {
            SceneManager.LoadScene(1);
        }
    }
}
