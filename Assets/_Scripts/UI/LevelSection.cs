using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSection : MonoBehaviour
{
    [SerializeField] private List<Image> sectionList = new();

    private void OnEnable()
    {
        CheckPointDrawer.OnSectionCompleted += UpdateSectionUI;
    }

    private void OnDisable()
    {
        CheckPointDrawer.OnSectionCompleted -= UpdateSectionUI;
    }

    private void UpdateSectionUI(int id)
    {
        Debug.Log(sectionList[id]);
        sectionList[id] = GetComponent<Image>();
        var tempColor = sectionList[id].color;
        tempColor.a = 1f;
        sectionList[id].color = tempColor;
    }
}