using Assets.Scripts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Galery
{
    public class SceneDataGalery:MonoBehaviour
    {
        
        [SerializeField] 
        private GameObject Grid;
        [SerializeField]
        private GameObject Content;

        private RectTransform rect;
        //ImageHeight is 350 height + 50 space beetwen images devided by 2 because we got 2 columns
        private int ImageHeight = 400/2;
        /// <summary>
        /// how much down to the end we need to scroll for download to start
        /// </summary>
        private int ThresholdToLoadMore = 200;
        /// <summary>
        /// Image number on the server (for building url)
        /// </summary>
        private int ImagePosition = (TexturesHolder.Textures.Count + 1);
        private void Awake()
        {
            Screen.orientation = ScreenOrientation.Portrait;

            //initial setup of already downloaded images
            rect = Content.GetComponent<RectTransform>();
            int contentSize = 0;
            TexturesHolder.Textures.ForEach(texture =>
            {
                InstantiateImage(texture);
                contentSize += ImageHeight;
            });
            float rectSizeDeltaY = (Screen.height - contentSize);
            if (rectSizeDeltaY >= 0)
            {
                rectSizeDeltaY = 100;
            }
            else
            {
                rectSizeDeltaY = contentSize - Screen.height;
            }
            rect.sizeDelta = new Vector2(rect.sizeDelta.x,rectSizeDeltaY);
        }
        
        private void Update()
        {
            //if we scrolled down enough
            if ((rect.sizeDelta.y-rect.anchoredPosition.y)<=ThresholdToLoadMore)
            {
                DownloadMoreImages();
                ImagePosition++;
            }
        }
        
        async private void DownloadMoreImages()
        {
            if (ImagePosition<= EndpointController.ImageMaxPosition)
            {
                //spawn empty image
                Texture texture = null;
                var gm = InstantiateImage(texture,true);
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + ImageHeight);
                
                //and then wnen texture is downloaded putting it on 
                await DownloadTextureController
                    .GetTexture(EndpointController.BaseURL + ImagePosition + ".jpg")
                    .ContinueWith(task =>
                    {
                        if (task.IsCompletedSuccessfully)
                        {
                            texture = task.Result;
                            TexturesHolder.Textures.Add(texture);
                        }
                        else if (task.IsFaulted)
                        {
                            Debug.LogError("failed to load image " + (TexturesHolder.Textures.Count + 1) + task.Exception.ToString());
                            return;
                        }
                    });

                gm.GetComponent<RawImage>().texture = texture;
            }
        }
        private void InstantiateImage(Texture texture)
        {
            var gm = Instantiate(Resources.Load("Prefabs/RawImage"), Grid.transform);
            gm.GetComponent<RawImage>().texture = texture;
        }
        private GameObject InstantiateImage(Texture texture,bool returnGM)
        {
            GameObject gm = (GameObject)Instantiate(Resources.Load("Prefabs/RawImage"), Grid.transform);
            gm.GetComponent<RawImage>().texture = texture;
            return gm;
        }
    }
}
