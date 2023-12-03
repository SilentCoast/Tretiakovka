using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

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
            Texture texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            return texture;
        }
    }
}
