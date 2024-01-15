// @radishmouse22 on YouTube
// https://www.youtube.com/channel/UCLh-RVE3Ms_rNl0i-L5NyXg

using System.Collections.Generic;
using UnityEngine;

namespace Radish
{
    public class NetworkingGraph : MonoBehaviour
    {
        public GameObject collumnPrefab, labelPrefab;
        public RectTransform labelRegion;

        [Space(10)]

        public int collumnCount;
        public int maxCollumnSum;
        [Tooltip("What the default values should be for the next collumn before values are pushed to it")]
        public DefaultCollumnValuesMode defaultCollumnValuesMode;

        [Space(10)]

        public GraphCategory[] categories;

        // private variables
        Queue<NetworkingGraphCollumn> collumns = new();
        int[] nextCollumnValues;
        RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            nextCollumnValues = new int[categories.Length];

            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);

            for (int i = 0; i < categories.Length; i++)
                Instantiate(labelPrefab, labelRegion).GetComponent<NetworkingGraphLabel>().Initialize(categories[i].color, categories[i].name);
        }

        public void PushValue(int index, int value)
        {
            nextCollumnValues[index] = Mathf.RoundToInt(rectTransform.sizeDelta.x * value / maxCollumnSum);
        }

        public void DisplayValues()
        {
            if (collumns.Count >= collumnCount)
                Destroy(collumns.Dequeue().gameObject);

            NewCollumn().DisplayValues(nextCollumnValues);

            switch (defaultCollumnValuesMode)
            {
                case DefaultCollumnValuesMode.clear:
                    nextCollumnValues = new int[collumnCount];
                    break;
                case DefaultCollumnValuesMode.lastCollumn:
                    break;
            }
        }

        private NetworkingGraphCollumn NewCollumn()
        {
            NetworkingGraphCollumn collumn = Instantiate(collumnPrefab, transform).GetComponent<NetworkingGraphCollumn>();
            collumn.Initialize(categories, rectTransform.sizeDelta.x / collumnCount);
            collumns.Enqueue(collumn);
            return collumn;
        }

        [System.Serializable]
        public enum DefaultCollumnValuesMode
        {
            clear = 0,
            lastCollumn,
        }
    }

    [System.Serializable]
    public struct GraphCategory
    {
        public string name;
        public Color color;
    }
}
