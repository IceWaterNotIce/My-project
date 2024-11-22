using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : Singleton<QuestionController>
{
    [SerializeField]
    private MessagePanel m_msgPanel;
    [SerializeField]
    private RectTransform m_hintPanel;

    // Start is called before the first frame update
    public void Init ()
    {
        m_msgPanel.Close();
        CloseHint();
    }

    public void ShowHint()
    {
        m_hintPanel.gameObject.SetActive(true);
    }

    public void CloseHint()
    {
        m_hintPanel.gameObject.SetActive(false);
    }

    public void OnCorrectAnswerBtnClicked ()
    {
        m_msgPanel.Open(true);
        QuestionManager.Instance.CorrectAnswer();
    }

    public void OnIncorrectAnswerBtnClicked ()
    {
        m_msgPanel.Open(false);
        QuestionManager.Instance.IncorrectAnswer();
    }


}
