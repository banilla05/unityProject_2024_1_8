using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExSoundPlay : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))                //1���� ������
        {
            SoundManager.instance.PlaySound("BackGround");  //BackGround ���
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))                //2���� ������
        {
            SoundManager.instance.PlaySound("Cannon");      //Cannon ���
        }
    }
}
