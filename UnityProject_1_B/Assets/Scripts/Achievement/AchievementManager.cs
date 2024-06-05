using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;              //�̵��� ȭ
    public List<Achievement> achievements;                  //Achievement Ŭ������ List�� ����

    public Text[] AchievementTexts = new Text[4];

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);                  //�ٸ� Scene������ ���� �ϱ� ���ؼ� ���� ���� �ʰ� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdataAchievementUI()
    {
        AchievementTexts[0].text = achievements[0].name;
        AchievementTexts[1].text = achievements[0].description;
        AchievementTexts[2].text = $"{achievements[0].currentProgress}/{achievements[0].goal}";
        AchievementTexts[3].text = achievements[0].isUnlocked ? "�޼�" : "�̴޼�";
    }

    public void AddProgressInList(string achievementName, int amount)         //���� ���� ��Ȱ ���� �Լ�
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);         //�μ����� �޾ƿ� �̸����� ���� ����Ʈ���� ã�Ƽ� ��ȯ
        if(achievement != null )                                                            //��ȯ�� ������ ���� ���
        {
            achievement.AddProgress(amount);                                                //���α׷����� ���� ��Ų��.
        }
    }

    //���ο� ���� �߰� �Լ�
    public void AddAchevement(Achievement achievement)
    {
        //Achievement temp = new Achievement("�̸�", "����", 5);
        achievements.Add(achievement);                              //List�� ���� �߰�
    }

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddProgressInList("����", 1);
            UpdataAchievementUI();
        }
    }
}
