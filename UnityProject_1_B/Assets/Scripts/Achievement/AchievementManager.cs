using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;              //싱들톤 화
    public List<Achievement> achievements;                  //Achievement 클래스를 List로 관리

    public Text[] AchievementTexts = new Text[4];

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);                  //다른 Scene에서도 적용 하기 위해서 차괴 되지 않게 설정
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
        AchievementTexts[3].text = achievements[0].isUnlocked ? "달성" : "미달성";
    }

    public void AddProgressInList(string achievementName, int amount)         //업적 진행 상활 갱신 함수
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);         //인수에서 받아온 이름으로 업적 리스트에서 찾아서 반환
        if(achievement != null )                                                            //반환된 업적이 있을 경우
        {
            achievement.AddProgress(amount);                                                //프로그래스를 증가 시킨다.
        }
    }

    //새로운 업적 추가 함수
    public void AddAchevement(Achievement achievement)
    {
        //Achievement temp = new Achievement("이름", "설명", 5);
        achievements.Add(achievement);                              //List에 업적 추가
    }

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddProgressInList("도약", 1);
            UpdataAchievementUI();
        }
    }
}
