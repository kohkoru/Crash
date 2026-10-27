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
    private int initialContinues = 3;
    public void initialize()
    {
        continuesCount = PlayerPrefs.GetInt("ContinuesCount", initialContinues);
        if (continuesCount <= 0)
        {
            continuesCount = initialContinues;
            SetContinues(continuesCount);
        }
        UpdateContinueText();
    }
    private void UpdateContinueText()
    {
        if (continuesText == null) return;
        continuesText.text = "X" + continuesCount;
    }
    public void LoseContinue()
    {
        continuesCount--;
        PlayerPrefs.SetInt("ContinuesCount", continuesCount);
        UpdateContinueText();
    }
    public void SetContinues(int  count)
    {
        PlayerPrefs.SetInt("ContinuesCount", count);
    }
}
