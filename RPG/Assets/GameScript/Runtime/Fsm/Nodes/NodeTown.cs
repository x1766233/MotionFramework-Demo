﻿using System;
using System.Collections;
using System.Collections.Generic;
using MotionFramework.Scene;
using MotionFramework.Audio;
using MotionFramework.Resource;
using MotionFramework.AI;

public class NodeTown : IFsmNode
{
	public string Name { get; }
	private GameWorld _gameWorld = new GameWorld();
	private bool _initWorld = false;

	public NodeTown()
	{
		Name = nameof(NodeTown);
	}
	void IFsmNode.OnEnter()
	{
		string sceneName = "Scene/Town";
		SceneManager.Instance.ChangeMainScene(sceneName, true, OnSceneLoad);
		UIManager.Instance.OpenWindow(EWindowType.UILoading, sceneName);
		UIManager.Instance.OpenWindow(EWindowType.UIMain);
		AudioManager.Instance.PlayMusic("Audio/Music/town", true);
	}
	void IFsmNode.OnUpdate()
	{
		if (_initWorld)
			_gameWorld.Update();
	}
	void IFsmNode.OnExit()
	{
		_gameWorld.Destroy();
	}
	void IFsmNode.OnHandleMessage(object msg)
	{
	}

	private void OnSceneLoad(SceneInstance instance)
	{
		if (instance == null)
			return;

		_initWorld = true;
		_gameWorld.Init();
	}
}