public class Localization
{
    public const string SAUDE_TITLE = "Saúde";
    public const string ENERGIA_TITLE = "Energia";
    public const string ALIMENTACAO_TITLE = "Alimentação";
    public const string HIGIENE_TITLE = "Higiene";
    public const string DIVERSAO_TITLE = "Diversão";

    public const string SAUDE_SUBTITLE_BOM = "Administrou os remédios corretamente?";
    public const string ENERGIA_SUBTITLE_BOM = "";
    public const string ALIMENTACAO_SUBTITLE_BOM = "Se alimentou de forma saudável?";
    public const string HIGIENE_SUBTITLE_BOM = "Cuidou corretamente da higiene?";
    public const string DIVERSAO_SUBTITLE_BOM = "Tem estado com bom humor?";

    public const string SAUDE_SUBTITLE_RUIM = "Não administrou os remédios corretamente?";
    public const string ENERGIA_SUBTITLE_RUIM = "";
    public const string ALIMENTACAO_SUBTITLE_RUIM = "Não se alimentou de forma saudável?";
    public const string HIGIENE_SUBTITLE_RUIM = "Não cuidou corretamente da higiene?";
    public const string DIVERSAO_SUBTITLE_RUIM = "Não tem estado com bom humor?";

    public const string DATE_TEXT = "Periodo da {0}, no dia {1}";

    public const string CRIANCA_SELECIONADA = "Criança selecionada: {0}";
    public const string BEM_VINDO = "Bem vindo {0}!";



    public string GetText(string id)
    {
        return (string)this.GetType().GetField(id.ToUpper()).GetValue(this);
    }
}
