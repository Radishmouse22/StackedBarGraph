// @radishmouse22 on YouTube
// https://www.youtube.com/channel/UCLh-RVE3Ms_rNl0i-L5NyXg

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Radish
{
    public class NetworkingGraphLabel : MonoBehaviour
    {
        public Image image;
        public TMP_Text label;

        public void Initialize(Color color, string text)
        {
            image.color = color;
            label.text = text;
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
        }
    }
}
