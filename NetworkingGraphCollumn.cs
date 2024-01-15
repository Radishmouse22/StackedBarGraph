// @radishmouse22 on YouTube
// https://www.youtube.com/channel/UCLh-RVE3Ms_rNl0i-L5NyXg

using UnityEngine;
using UnityEngine.UI;

namespace Radish
{
    public class NetworkingGraphCollumn : MonoBehaviour
    {
        RectTransform[] images;
        RectTransform rectTransform;
        float width;

        public void Initialize(GraphCategory[] categories, float width)
        {
            rectTransform = GetComponent<RectTransform>();
            this.width = width;

            images = new RectTransform[categories.Length];
            for (int i = 0; i < categories.Length; i++)
            {
                images[i] = new GameObject($"category {i + 1}", typeof(Image)).GetComponent<RectTransform>();
                images[i].GetComponent<Image>().color = categories[i].color;
                images[i].transform.SetParent(transform);
            }
        }

        public void DisplayValues(int[] values)
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].sizeDelta = new Vector2(width, values[i]);
                images[i].localScale = Vector2.one;
            }
        }
    }
}
