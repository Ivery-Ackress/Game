using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BindingPrefabManager : MonoBehaviour
{
    [SerializeField] private TMP_Text actionName;
    [SerializeField] private TMP_Text bindingText;
    [SerializeField] private Button button;

    public TMP_Text ActionName
    {
        get { return actionName; }
        set { actionName = value; }
    }

    public TMP_Text BindingText
    {
        get { return bindingText; }
        set { bindingText = value; }
    }

    public Button Button
    {
        get { return button; }
        set { button = value; }
    }
}
