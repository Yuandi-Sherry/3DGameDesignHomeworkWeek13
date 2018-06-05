using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstController : MonoBehaviour, IUserAction, ISceneController{
	public Button PeppaBubble;
	public Button GeorgeBubble;
	public Button SusieBubble;
	public Button RabbitBubble;
	public Text PeppaText;
	public Text GeorgeText;
	public Text SusieText;
	public Text RabbitText;

	private int fontSize = 14;

	private float time = 2;
	private int index = -1;
	
	public SayingsFactory sayingsFactory;
	public List<Speak> sayings;

	public bool canMod = true;
	public bool init = true;
	public bool roll = false;
	//private c

	void Awake() {
		Director director = Director.getInstance();
		director.currentSceneController = this;
		sayingsFactory = GetComponent<SayingsFactory>();
		sayings = new List<Speak>();
		
	}

	// Update is called once per frame
	void Update () {
		if(init) {
			init = false;
			sayings = sayingsFactory.getSayings();
		}
		if(index < sayings.Count && index >= 0) {
			if(sayings[index].speaker == "Peppa") {
				say(PeppaText);
			}
			else if(sayings[index].speaker == "George"){
				say(GeorgeText);
			}
			else if(sayings[index].speaker == "Susie"){
				say(SusieText);
			}
			else if(sayings[index].speaker == "Rabbit"){
				say(RabbitText);
			}
		}
	}

	void say (Text sayingText) {
		// Debug.Log(sayingText);
		Vector3 position = sayingText.rectTransform.localPosition;
		sayingText.text = sayings[index].saying;
		// 控制气泡放大
		if(sayings[index].speaker == "Peppa") {
			Animator PeppaAnimation = PeppaBubble.GetComponent<Animator>();
			PeppaAnimation.SetBool("toEnlarge", true);
		}
		else if(sayings[index].speaker == "George") {
			Animator GeorgeAnimation = GeorgeBubble.GetComponent<Animator>();
			GeorgeAnimation.SetBool("toEnlarge", true);
		}
		else if(sayings[index].speaker == "Susie") {
			Animator SusieAnimation = SusieBubble.GetComponent<Animator>();
			SusieAnimation.SetBool("toEnlarge", true);
		}
		else if(sayings[index].speaker == "Rabbit") {
			Animator RabbitAnimation = RabbitBubble.GetComponent<Animator>();
			RabbitAnimation.SetBool("toEnlarge", true);
		}

		// 控制气泡缩小
		if(time <= 0 && index < sayings.Count) {

			if(sayings[index].speaker == "Peppa") {
				Animator PeppaAnimation = PeppaBubble.GetComponent<Animator>();
				PeppaAnimation.SetBool("toEnlarge", false);
			}
			else if(sayings[index].speaker == "George") {
				Animator GeorgeAnimation = GeorgeBubble.GetComponent<Animator>();
				GeorgeAnimation.SetBool("toEnlarge", false);
			}
			else if(sayings[index].speaker == "Susie") {
				Animator SusieAnimation = SusieBubble.GetComponent<Animator>();
				SusieAnimation.SetBool("toEnlarge", false);
			}
			else if(sayings[index].speaker == "Rabbit") {
				Animator RabbitAnimation = RabbitBubble.GetComponent<Animator>();
				RabbitAnimation.SetBool("toEnlarge", false);
			}
			//sayingText.text = "";//对话内容置空
        	
        	canMod = true;

		}
		//position.x = 0;	
		// 判断是否需要移动语句
		if (roll) {
			//Vector3 position = sayingText.rectTransform.localPosition;
			position.y = -85;//text恢复初始位置
        	sayingText.rectTransform.localPosition = position;
        	roll = false;
		}
		if (sayingText.text.Length * fontSize > 300) {
			Debug.Log("object message");
            position.y += 1;
            sayingText.rectTransform.localPosition = position;
        } 
        time -= Time.deltaTime;//计时
	}

	// implementation of interface
	public void clickNext() {
		if(canMod) {
			index++;
			// 设置下一对话的是持续时间
			if(index < sayings.Count) {
				if(sayings[index].saying.Length * fontSize <= 300) {
					time = 2;
				}
				else {
					time = (sayings[index].saying.Length/150 * fontSize + 100) * Time.deltaTime;
					roll = true;
					//Debug.Log(time);
				}
			}
			else {
				index = -1;
				clickNext();
			}
			Debug.Log("You have clicked the next button!");
			Debug.Log(index);
		}
		
		canMod = false;
		

	}

	public void clickLast() {
		if(canMod) {
			index--;
			//sayings = sayingsFactory.getSayings();
			// 设置下一对话的是持续时间
			if(index >= 0) {
				if(sayings[index].saying.Length * fontSize <= 300) {
					time = 2;
				}
				else {
					time =  (sayings[index].saying.Length/150 * fontSize + 100) * Time.deltaTime;
					roll = true;
					//Debug.Log(time);
				}
			}
			else {
				index = sayings.Count;
				clickLast();
			}
			Debug.Log("You have clicked the last button!");
			Debug.Log(index);
		}
		
		canMod = false;
		Debug.Log("You have clicked the last button!");
	}
}
