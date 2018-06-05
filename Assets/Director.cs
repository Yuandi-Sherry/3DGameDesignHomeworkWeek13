using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : System.Object {
	public ISceneController currentSceneController {get; set; }
	private static Director director;
	public static Director getInstance() {
		if(director == null) {
			director = new Director();
		}
		return director;
	}
}