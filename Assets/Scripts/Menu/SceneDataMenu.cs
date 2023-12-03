using Assets.Scripts.Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataMenu : MonoBehaviour
{
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void OnGaleryClick()
    {
        LoadingController.LoadTo = "Galery";
        SceneManager.LoadScene(1);
    }
}
