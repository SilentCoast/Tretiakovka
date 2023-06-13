using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Classes
{
    /// <summary>
    /// Contains info about endpoint
    /// </summary>
    public static class EndpointController
    {
        public static string BaseURL { get; } = "http://data.ikppbb.com/test-task-unity-data/pics/";
        public static int ImageMaxPosition { get; } = 66;
    }
}
