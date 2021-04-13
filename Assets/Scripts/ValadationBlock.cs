using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ValadationBlock : MonoBehaviour
{

    [SerializeField] private Text TitleText;
    [SerializeField] private Text SubtitleText;
    [SerializeField] private Text DateText;
    [SerializeField] private Button ButtonYes;
    [SerializeField] private Button ButtonNo;
    [SerializeField] private Button ButtonQuestion;
    [SerializeField] private Image Icon;
    [SerializeField] private Sprite[] Icons;

    private int id;

    public void Init(int id, MedidorType type, string date, string periodo, bool good)
    {
        Localization localization = new Localization();
        TitleText.text = localization.GetText(type.ToString() + "_TITLE");
        SubtitleText.text = localization.GetText(type.ToString() + "_SUBTITLE_" + (good ? "BOM" : "RUIM"));
        DateText.text = string.Format(localization.GetText("DATE_TEXT"), periodo, date);

        Icon.sprite = Icons[(int)type];
        this.id = id;
    }

    private void InitButtons()
    {

    }
}
