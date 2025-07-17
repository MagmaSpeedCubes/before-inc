using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InitiativeName : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public void SetInitiativeName()
    {
        GameInfo.initiativeName = inputField.text;
        Debug.Log("Initiative name set to " + GameInfo.initiativeName);
    }
}
