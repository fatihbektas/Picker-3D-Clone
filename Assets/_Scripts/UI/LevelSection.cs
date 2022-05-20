using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSection : MonoBehaviour
{
    [SerializeField] private List<Image> sectionList;

    private void OnEnable()
    {
        PlanePiece.OnSectionCompleted += UpdateSectionUI;
    }

    private void OnDisable()
    {
        PlanePiece.OnSectionCompleted -= UpdateSectionUI;
    }

    private void UpdateSectionUI(int id)
    {
        Debug.Log(sectionList[id]);
        var tempColor = sectionList[id].color;
        tempColor.a = 1f;
        sectionList[id].color = tempColor;

        if (id == 2)
        {
            
        }
    }
}