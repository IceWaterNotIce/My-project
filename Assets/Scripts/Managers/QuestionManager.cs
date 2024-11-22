using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : Singleton<QuestionManager>
{

    // Start is called before the first frame update
    void Start()
    {
        QuestionController.Instance.Init();
    }
    
    public void CorrectAnswer ()
    {
        
    }

    public void IncorrectAnswer ()
    {
        
    }
}
