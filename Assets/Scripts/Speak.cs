using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * assign the contents of the saying
 * and the speaker
 */
public class Speak {
	public string speaker;
	public string saying;

	public Speak (string speaker, string saying) {
		this.speaker = speaker;
		this.saying = saying;
	}
}
