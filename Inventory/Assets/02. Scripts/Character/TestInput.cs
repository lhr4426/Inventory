using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // 돈 증가 테스트
            GameManager.Instance.Player.data.money += 10000;
            UIManager.Instance.MainMenu.RefreshUI();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 돈 감소 테스트
            GameManager.Instance.Player.data.money -= 10000;
            UIManager.Instance.MainMenu.RefreshUI();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 레벨 다운 테스트
            GameManager.Instance.Player.data.level -= 1;
            UIManager.Instance.MainMenu.RefreshUI();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 레벨 업 테스트   
            GameManager.Instance.Player.data.level += 1;
            UIManager.Instance.MainMenu.RefreshUI();
        }
    }
}
