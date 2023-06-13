using Assets.Scripts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Galery
{
    public class ImageItem : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            TexturesHolder.TextureToCloseLook = gameObject.GetComponent<RawImage>().texture;
            SceneManager.LoadScene(3);
        }
    }
}
