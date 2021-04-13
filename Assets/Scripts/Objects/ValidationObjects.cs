using System.Collections.Generic;
using System;

[Serializable]
public class DataValidation
{
    public DataValidationObject dataValidation;
}

[Serializable]
public class DataValidationObject
{
    public List<CriancaObject> criancas;
}

[Serializable]
public class CriancaObject
{
    public int id;

    public string nome;

    public List<DadoObject> dados;
}

[Serializable]
public class DadoObject
{
    public int id;
    public int type;
    public bool bom;
    public string date;
    public string periodo;
}