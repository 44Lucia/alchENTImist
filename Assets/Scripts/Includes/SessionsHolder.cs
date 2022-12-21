using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionsHolder : MonoBehaviour
{
    public static SessionsHolder _SESSION_HOLDER;
    private static User currentUser;

    private void Awake()
    {
        if (_SESSION_HOLDER != null && _SESSION_HOLDER != this) { Destroy(gameObject); }
        else{ DontDestroyOnLoad(gameObject); _SESSION_HOLDER = this; }
    }

    public static User CurrentUser { get { return currentUser; } set { currentUser = value; } }
}
