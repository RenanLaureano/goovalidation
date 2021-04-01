using System;
using System.Collections.Generic;

[Serializable]
public class DefaultPost
{
    public string type;
}

[Serializable]
public class DefaultResponse
{
    public int code;
    public string data;
}


[Serializable]
public class PostLogin : DefaultPost
{
    public Data data;

    public PostLogin(string login, string password)
    {
        data = new Data();
        data.login = login;
        data.password = password;
        type = "login-crianca";
    }

    [Serializable]
    public class Data
    {
        public string login;
        public string password;
    }
}

[Serializable]
public class DataUser
{
    public int id;
    public string name;
    public string email;
}