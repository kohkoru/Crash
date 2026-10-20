using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Continues : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI continuesText;
    private int continuesCount;
    public bool HasContinues => continuesCount > 0;
    private void Awake()
    {
        continuesCount = PlayerPrefs.GetInt("ContinuesCOunt", 3);
        UpdateContinueText();
    }
    private void UpdateContinueText()
    {
        continuesText.text = "X" + continuesCount;
    }
    public void LoseContinue()
    {
        continuesCount--;
        PlayerPrefs.SetInt("ContinuesCount", continuesCount);
        UpdateContinueText();
    }
}
