using Assets.Scripts.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDataLoading : MonoBehaviour
{
    
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject gmTxtPercents;
    private TextMeshProUGUI txtPercents;

    private List<Texture> textures;
    private int sliderValue = 0;

    private int lastImageIndex = 12;
    async private void Awake()
    {
        txtPercents= gmTxtPercents.GetComponent<TextMeshProUGUI>();
        slider.value = 0;
        Screen.orientation = ScreenOrientation.Portrait;
        textures = new List<Texture>();

        if (LoadingController.LoadTo == "Galery")
        {
            
            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= lastImageIndex; i++)
            {
                var task= DownloadTextureController.GetTexture(EndpointController.BaseURL + i + ".jpg").ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        var texture = task.Result;
                        textures.Add(texture);
                        sliderValue += 100 / lastImageIndex;
                    }
                });
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
            TexturesHolder.Textures = textures;
            SceneManager.LoadScene(2);
        }
    }
    private void Update()
    {
        slider.value = sliderValue;
        txtPercents.text= sliderValue+"%";
    }
}
