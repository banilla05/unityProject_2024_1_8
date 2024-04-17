using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();                  //�̹��� ������Ʈ�� �ڰܿ´�.
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);    

        image.DOFade(1f, duration)              //UI Fade �� �Ѵ�. 0 :����ó��
               .SetEase(Ease.InOutQuad)         //�ɼ� �� ����
               .SetAutoKill(false)
               .Pause()
               .OnComplete(() => Debug.Log("UI �Ϸ�"));           //�͸��Լ����� �α� Ȱ��ȭ [() =>]

        image.DOPlay();                                //������ Ʈ���� ����
    }

}
