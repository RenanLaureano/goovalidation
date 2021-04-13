using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInstance : MonoBehaviour
{

    private DataUser user = null;
    private DataValidation dataObjects = null;

    public static UserInstance Instance = null;

    public DataUser User
    {
        get
        {
            return user;
        }

        set
        {
            user = value;
        }
    }

    public DataValidation DataObjects
    {
        get
        {
            return dataObjects;
        }

        set
        {
            dataObjects = value;
        }
    }

    private void Awake()
    {
        if (UserInstance.Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
