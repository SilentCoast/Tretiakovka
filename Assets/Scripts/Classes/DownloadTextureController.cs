using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Classes
{
    public static class DownloadTextureController
    {
        public static async Task<Texture> GetTexture(string endpoint)
        {
            var request = UnityWebRequestTexture.GetTexture(endpoint);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Delay(10);
            }
            Texture texture = texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            return texture;
        }
    }
}
