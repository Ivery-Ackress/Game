using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class ControlBinding
{
    private string actionName;
    private string displayName;
    private string bindingPath;

    #region Fields
    public string ActionName
    {
        get { return actionName; }
        set { actionName = value; }
    }

    public string DisplayName 
    { 
        get { return displayName; } 
        set { displayName = value; } 
    }

    public string BindingPath
    {
        get { return bindingPath; }
        set { bindingPath = value; }
    }

    #endregion
}