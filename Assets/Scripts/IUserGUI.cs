using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IUserGUI : MonoBehaviour {
	private IUserAction action;
	//Make sure to attach these Buttons in the Inspector
    public Button next, last;

    void Start()
    {
    	action = Director.getInstance().currentSceneController as IUserAction;

        //Calls the TaskOnClick method when you click the Button
        next.onClick.AddListener(action.clickNext);
        last.onClick.AddListener(action.clickLast);    
        //m_YourSecondButton.onClick.AddListener(delegate {TaskWithParameters("Hello"); });
    }

    /*void TaskOnNext()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
    }*/

    /*void TaskWithParameters(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    }*/
}
