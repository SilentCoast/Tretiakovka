using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDataCloseLook : MonoBehaviour
{
    [SerializeField]
    private Image image;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        image.sprite = Sprite.Create((Texture2D)TexturesHolder.TextureToCloseLook,
            new Rect(0,0, TexturesHolder.TextureToCloseLook.width, TexturesHolder.TextureToCloseLook.height),new Vector2(0,0));
    }
    private void Update()
    {
        //Native android goBack button
        if(Input.GetKey(KeyCode.Escape))
        {
            GoBackToGalery();
        }
    }
    public void GoBackToGalery()
    {
        SceneManager.LoadScene(2);
    }
}
