using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessagePanel : MonoBehaviour
{
    [Header("Color")]
    [SerializeField]
    private Color m_bgWin;
    [SerializeField]
    private Color m_bgLose;

    [Header("Message")]
    [SerializeField]
    private string m_winMessage;
    [SerializeField]
    private string m_loseMessage;

    [Space]
    [Header("UI Object")]
    [SerializeField]
    private Image m_bg;
    [SerializeField]
    private TMP_Text m_message;

    public void Open (bool _isWin)
    {
        if (_isWin)
        {
            m_bg.color = m_bgWin;
            m_message.text = m_winMessage;
        }
        else
        {
            m_bg.color = m_bgLose;
            m_message.text = m_loseMessage;
        }

        this.gameObject.SetActive(true);
    }

    public void Close ()
    {
        this.gameObject.SetActive(false);
    }

    public void OnConfirmBtnClicked ()
    {
        Close();
    }
}
