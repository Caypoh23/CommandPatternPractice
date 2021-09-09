using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using TMPro;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;
    private Stack<ICommand> _commandBuffer = new Stack<ICommand>();

    public static CommandManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Command Manager is Null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void AddCommand(ICommand command)
    {
        _commandBuffer.Push(command);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }

    public void Done()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    public void Reset()
    {
        _commandBuffer.Clear();
    }

    IEnumerator PlayRoutine()
    {
        Debug.Log("Playing...");
        foreach (var command in _commandBuffer)
        {
            command.Execute();
            yield return new WaitForSeconds(1.0f);
        }

        Debug.Log("Finished...");
    }

    IEnumerator RewindRoutine()
    {
        foreach (var command in _commandBuffer)
        {
            command.Undo();
            yield return new WaitForSeconds(1.0f);
        }
    }
}