using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameAnim : MonoBehaviour
{
    public Animator animator;
    public Button myButton; 

    void Start()
    {
        myButton.onClick.AddListener(ChangeAnimation);
    }

    public void ChangeAnimation()
    {
        animator.SetBool("StartGame", true);
    }
}