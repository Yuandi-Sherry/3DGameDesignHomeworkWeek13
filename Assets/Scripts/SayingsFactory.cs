using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 个人感觉，这里的实现方法和飞碟工厂类似，而且还不用回收
 */
public class SayingsFactory : MonoBehaviour {
	private List<Speak> sayings;

	// Use this for initialization
	void Start () {
		sayings = new List<Speak>();

		sayings.Add(new Speak("Peppa","I'm Peppa Pig. This is my little brother, George. "));
		sayings.Add(new Speak("George","I'm George. "));
		sayings.Add(new Speak("Susie","I'm Susie. "));
		sayings.Add(new Speak("Rabbit","I'm Rabbit. "));
		sayings.Add(new Speak("Peppa","Let's have a party in the forest!"));
	}
	
	// Update is called once per frame
	public List<Speak> getSayings() {
		return sayings;
	}
}
