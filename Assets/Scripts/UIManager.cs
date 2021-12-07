using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
UI����ű�
*/
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Text PieceAttack;
    [SerializeField] private Text PieceDefense;
    [SerializeField] private Text PieceResistance;
    [SerializeField] private Text PieceSpeed;
    [SerializeField] private Text PieceAttackRange;
    [SerializeField] private Text PieceMorale;
    [SerializeField] private GameObject PieceInfo;

    [SerializeField] private GameObject[] PieceHP;
    [SerializeField] private GameObject[] PieceMP;
    [SerializeField] private GameObject[] PieceMotivation;
    CharacterSkillManager skill;
    private void Awake()
    {
        skill = FindObjectOfType<CharacterSkillManager>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

        ShowPieceInfo(GameManager.instance.PiecesNumber);
    }
    //�غϽ���
    public void OnClickTurn()
    {
        Debug.Log("�Ѿ������غ��ˣ�");
        GameManager.instance.TurnEnd();
        //��ÿ�����ӵ�ÿ�����ܵļ�����ȴ����һ�غ�
        foreach (var pieceSkill  in GameManager.instance.Pieces)
        {
           // skill.CoolTimeDown(pieceSkill.GetComponent<CharacterSkillManager>().skills);
        }
    }

    //��ʾ������Ϣ
    public void ShowInfo(PieceDate piece)
    {
        PieceInfo.SetActive(true);
        PieceAttack.text = piece.attack.ToString();
        PieceDefense.text = piece.defense.ToString();
        PieceResistance.text = piece.resistance.ToString();
        PieceSpeed.text = piece.speed.ToString();
        PieceAttackRange.text = piece.attackRange.ToString();
        //PieceMorale.text = piece.morale.ToString();
    }

    //����������Ϣ
    public void CloseInfo()
    {
        PieceInfo.SetActive(false);
    }

    //��������ͷ���Լ�HP\MP���ж�ֵ
    public void ShowPieceInfo(List<PieceDate> piece)
    {
        for (int i = 0; i < piece.Count; i++)
        {
            PieceHP[i].GetComponent<Image>().fillAmount = piece[i].hp / (piece[i].HPmax * 1.0f);
            PieceMP[i].GetComponent<Image>().fillAmount = piece[i].mp / (piece[i].MPmax * 1.0f);
            PieceMotivation[i].GetComponent<Image>().fillAmount = piece[i].motivation / (piece[i].motivationMax * 1.0f);
        }
    }

    //��ɫ������
    public void OnskillButtonDown(int buttonNumber)
    {
        Debug.Log("һ�β���");
        SkillDate date = null;
        switch (buttonNumber)
        {
            case 0:
                date = skill.PrepareSkill(skill.skills[0].skillID);
                break;
            case 1:
                date = skill.PrepareSkill(skill.skills[1].skillID);
                break;
            case 2:
                date = skill.PrepareSkill(skill.skills[2].skillID);
                break;
            case 3:
                date = skill.PrepareSkill(skill.skills[3].skillID);
                break;
            case 4:
                date = skill.PrepareSkill(skill.skills[4].skillID);
                break;
            case 5:
                date = skill.PrepareSkill(skill.skills[5].skillID);
                break;
            case 6:
                date = skill.PrepareSkill(skill.skills[6].skillID);
                break;
        }
        //������������಻Ϊ�գ�����׼���ɹ�
        if (date != null)
        {
            //�ͷż���
            skill.GenerateSkill(date);
        }
    }



}
