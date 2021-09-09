using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    void Update()
    {
        Click();
    }

    private void Click()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider.tag == "Cube")
                {
                    ICommand click = new ClickCommand(hitInfo.collider.gameObject,
                        new Color(Random.value, Random.value, Random.value));
                    click.Execute();
                    CommandManager.Instance.AddCommand(click);
                }
            }
        }
    }
}
