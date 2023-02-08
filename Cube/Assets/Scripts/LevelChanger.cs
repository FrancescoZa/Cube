using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
	// Start is called before the first frame update

	public Animator animator;
	private int index;

	

	public void FadeToLevel(int level)
	{
		index = level;
		animator.SetTrigger("fadeOut");
	}

	public void OnFadeComplete()
	{
		SceneManager.LoadScene(index);
	}

}
