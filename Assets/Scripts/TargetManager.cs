using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class TargetManager : MonoBehaviour {

    Animator animator;
    BoxCollider boxCollider;
    public int hp = 5;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider>();

        this.UpdateAsObservable()
            .Where(_ => hp == 0)
            .ThrottleFirst(TimeSpan.FromSeconds(5))
            .Subscribe(_ => Invoke("WakeUp", 5));
	}
	
	// Update is called once per frame
	void Update () {
        if (hp == 0)         {             animator.SetBool("broken", true);             boxCollider.enabled = false;         }
	}
    void WakeUp()     {         animator.SetBool("broken", false);         boxCollider.enabled = true;         hp = 5;     } 
    public void DeclineHp(){
        --hp;
    }
}
