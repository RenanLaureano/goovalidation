using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainSceneValidation : MonoBehaviour
{

    [SerializeField] private Transform content;
    [SerializeField] private ValadationBlock ValadationBlock;
    [SerializeField] private Text NomeCriancaText;

    [Header("Settings")]
    [SerializeField] private RectTransform RightBar;
    [SerializeField] private Button ButtonMenu;
    [SerializeField] private Text BenVindoText;
    [SerializeField] private Dropdown SelectCrianca;

    private bool isOpened = false;

    Localization localization = new Localization();
    Dictionary<string, CriancaObject> criancas = new Dictionary<string, CriancaObject>();

    void Start()
    {
        foreach (CriancaObject crianca in UserInstance.Instance.DataObjects.dataValidation.criancas)
        {
            criancas.Add(crianca.nome, crianca);
        }

        InitSettings();

        CriancaObject crianca_selecionada = UserInstance.Instance.DataObjects.dataValidation.criancas[0];
        OnSelectCrianca(crianca_selecionada);
    }

    private void InitSettings()
    {
        ButtonMenu.onClick.AddListener(OpenMenu);
        BenVindoText.text = string.Format(localization.GetText("BEM_VINDO"), UserInstance.Instance.User.nome);

        SelectCrianca.ClearOptions();

        List<string> nomesCriancas = new List<string>();
        foreach (CriancaObject crianca in criancas.Values)
        {
            nomesCriancas.Add(crianca.nome);
        }

        SelectCrianca.AddOptions(nomesCriancas);


        SelectCrianca.onValueChanged.AddListener((i) => {
            OnSelectCrianca(criancas[SelectCrianca.options[i].text]);
        });
    }

    private void OnSelectCrianca(CriancaObject crianca)
    {
        if (crianca != null)
        {
            foreach (Transform child in content)
            {
                GameObject.Destroy(child.gameObject);
            }

            NomeCriancaText.text = string.Format(localization.GetText("CRIANCA_SELECIONADA"), crianca.nome);
            foreach (DadoObject dado in crianca.dados)
            {
                ValadationBlock tempValidationBlock = Instantiate(ValadationBlock, content);
                tempValidationBlock.Init(dado.id, (MedidorType)dado.type, dado.date, dado.periodo, dado.bom);
            }
        }
    }

    private void OpenMenu()
    {
        isOpened = !isOpened;

        if (isOpened)
        {
            RightBar.gameObject.SetActive(true);
            RightBar.LeanMoveX(0, 0.3f);
        }
        else
        {
            RightBar.LeanMoveX(-200f, 0.15f).setOnComplete(() =>
            {
                RightBar.gameObject.SetActive(false);
            });
        }
    }

}
