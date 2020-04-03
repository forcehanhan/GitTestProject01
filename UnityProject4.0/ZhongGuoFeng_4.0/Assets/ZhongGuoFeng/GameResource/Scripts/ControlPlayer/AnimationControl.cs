using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {
	
	/// <summary>
	/// 和平待机
	/// </summary>
    public const string animPeaceWait = "peacewait";
//	private float speedpeaceWait = 1;
	/// <summary>
	///  行走
	/// </summary>
	public const string animWalk="walk";
//	private float speedWalk = 1;
	/// <summary>
	/// 奔跑
	/// </summary>
	public const string animRun="run";
//	private float speedRun = 1;
	/// <summary>
	/// 受攻击
	/// </summary>
	public const string animAttcked="attcked";
//	private float speedAttcked = 1;
	/// <summary>
	/// 战斗等待
	/// </summary>
	public const string animWarWait="warwait";
//	private float speedWarWait = 1;
	/// <summary>
	/// 攻击1
	/// </summary>
	public const string animAttck1="attck1";
//	private float speedAttck1 = 1;
	/// <summary>
	/// 攻击2
	/// </summary>
	public const string animAttck2="attck2";
//	private float speedAttck2 = 1;
	/// <summary>
	/// 死亡
	/// </summary>
	public const string animDead="dead";
	
	public const string animDid="did";
	
	private GameObject obj = null;
	public string theObjName;
	
	
//	private float newTime = 0;
	
	public bool isShowAnimation = false;
	// Use this for initialization
	void Awake()
	{
		obj = GameObject.Find(this.transform.name);
//		string str = this.transform.name;
//		long roleId ;
//		if(str.StartsWith(GameValue.PLAYER_NAME))
//		{
//			roleId = long.Parse(str.Remove(0,10));
//			if(SceneInfoMap.Map.ContainsKey(roleId))
//			{
//				OtherRoleInfo roleInfo = SceneInfoMap.Map[roleId];
//				if(roleInfo.getCurrHP()>0)
//				{
//					PlayAnimPeaceWait();
//				}
//				else 
//				{
//					PlayerAnimDid();
//				}
//			}
//		}
//		else if(str.StartsWith(GameValue.NPC_NAME))
//		{
//			print("str================"+str);
//			roleId = long.Parse(str.Remove(0,4));
//			if(SceneInfoMap.NpcMap.ContainsKey(roleId))
//			{
//				NPCInfo npcInfo = SceneInfoMap.NpcMap[roleId];
//				if(npcInfo.CurrHP>0)
//				{
//					PlayAnimPeaceWait();
//				}
//				else 
//				{
//					PlayerAnimDid();
//				}
//			}
//		}
//		else 
//		{
//			if(SceneInfoMap.RoleInfo.CurrHP>0)
//			{
//				PlayAnimPeaceWait();
//			}
//			else 
//			{
//				PlayerAnimDid();
//			}
//		}
		
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(isShowAnimation)
			{
				isShowAnimation = false;
			}
			else 
			{
				isShowAnimation = true;
			}
		}
		if(isShowAnimation)
		{
	//		ControlAnimation();
	//		CountDownTime();
		}
	//	PlayAnimWalk();
	}
/*	
	public void CountDownTime()
	{
		if(newTime < Time.time)
		{
			countdown--;
			newTime = Time.time + addTime;
		}
		if(countdown <= 0)
		{
		
			wnether = 0;	
		}
	}
	public void ControlAnimation()
	{
		if(Input.GetKey(KeyCode.Alpha2))
		{
			PlayAnimWalk();
		}
        else if(Input.GetKey(KeyCode.Alpha3))
		{
			PlayAnimRun();
		}
		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			PlayAnimAttcked();
		}
		else if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			PlayAnimWarWait();
		}
		else if(Input.GetKeyDown(KeyCode.Alpha6))
		{
			PlayAnimAttck1();
		}
		else if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			PlayAnimAttck2();
		}
		else if(Input.GetKeyDown(KeyCode.Alpha8))
		{
			PlayAnimDead();
			isShowWork = true;
		}
		else if(wnether == 1 && !isShowWork)
		{
			PlayAnimWarWait();
		}
		else if(wnether == 0 && !isShowWork)
		{
			PlayAnimPeaceWait();
		}
		
	}
	*/
	/// <summary>
	///停止所有动画
	/// </summary>
	public void AnimationStop()
	{
		animation.Stop(animPeaceWait);
		animation.Stop(animWalk);
		animation.Stop(animRun);
		animation.Stop(animAttcked);
		animation.Stop(animWarWait);
		animation.Stop(animAttck1);
		animation.Stop(animAttck2);
		animation.Stop(animDead);
		animation.Stop(animDid);
		
	}
	/// <summary>
	/// 和平待机
	/// </summary>
	public void PlayAnimPeaceWait()
	{
		obj.animation.Blend(animPeaceWait,110f,2f);
	}
	/// <summary>
	/// 停止和平待机
	/// </summary>
	public void StopAnimPeaceWait()
	{
		obj.animation.Stop(animPeaceWait);
	}
	/// <summary>
	///行走
	/// </summary>
	public void PlayAnimWalk()
	{
		obj.animation.Blend(animWalk,32f,2f);
	}
	/// <summary>
	///停止行走
	/// </summary>
	public void StopAnimWalk()
	{
		obj.animation.Stop(animWalk);
	}
	/// <summary>
	/// 跑
	/// </summary>
	public void PlayAnimRun()
	{
		obj.animation.Play(animRun);
	}
	/// <summary>
	/// 停止跑
	/// </summary>
	public void StopAnimRun()
	{
		obj.animation.Stop(animRun);
	}
	/// <summary>
	/// 被攻击.
	/// </summary>
	public void PlayAnimAttcked()
	{
		obj.animation.Play(animAttcked);
		animation.CrossFadeQueued (animWarWait,0.3f,QueueMode.CompleteOthers );
	}
	/// <summary>
	/// 停止被攻击.
	/// </summary>
	public void StopAnimAttcked()
	{
		obj.animation.Stop(animAttcked);
	}
	/// <summary>
	/// 战斗呼吸
	/// </summary>
	public void PlayAnimWarWait()
	{
		obj.animation.Play(animWarWait);
	}
	/// <summary>
	/// 停止战斗呼吸
	/// </summary>
	public void StopAnimWarWait()
	{
		obj.animation.Stop(animWarWait);
	}
	/// <summary>
	/// 攻击1
	/// </summary>
	public void PlayAnimAttck1()
	{
		animation.Stop(animPeaceWait);
		animation.Stop(animWalk);
		animation.Stop(animRun);
		animation.Stop(animAttcked);
		animation.Stop(animWarWait);
		
		obj.animation.Play(animAttck1);
		
		animation.CrossFadeQueued (animWarWait,0.3f, QueueMode.CompleteOthers );

	}
	/// <summary>
	/// 停止攻击1
	/// </summary>
	public void StopAnimAttck1()
	{
		
		
		obj.animation.Stop(animAttck1);
		
	}
	/// <summary>
	/// 攻击2
	/// </summary>
	public void PlayAnimAttck2()
	{
		animation.Stop(animPeaceWait);
		animation.Stop(animWalk);
		animation.Stop(animRun);
		animation.Stop(animAttcked);
		animation.Stop(animWarWait);
		
		obj.animation.Play(animAttck2);
		animation.CrossFadeQueued (animWarWait,0.3f,QueueMode.CompleteOthers );
	}
	/// <summary>
	/// 停止攻击2
	/// </summary>
	public void StopAnimAttck2()
	{
		obj.animation.Stop(animAttck2);
	}
	/// <summary>
	/// 死亡
	/// </summary>
	public void PlayAnimDead()
	{
		AnimationStop();
		obj.animation.Play(animDead);
	}
	/// <summary>
	/// 停止死亡
	/// </summary>
	public void StopAnimDead()
	{
		obj.animation.Stop(animDead);
	}
	
	public void PlayerAnimDid()
	{
		obj.animation.Stop(animDid);
	}
}
