using UnityEngine;

/*
���ܹ�����
*/
public class CharacterSkillManager : MonoBehaviour
{

    //ע�⣺�����㹤������Ҫʹ�õ���Դ����Ҫ�ŵ�Resources�ļ����У�
    //�����б�
    public SkillDate[] skills;

    private void Start()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            InitSkill(skills[i]);
        }
    }

    /// <summary>
    /// ���ɼ���
    /// </summary>
    /// <param name="_date">��Ҫ���ɵļ�������</param>
    public void GenerateSkill(SkillDate _date)
    {
        //��������(���ܵ����ݣ����ܵ��ͷ�λ�ã����ܵ���תλ��)
       GameObject skillGo = Instantiate(_date.skillPrefba, transform.position, transform.rotation).gameObject;

        //��ȡ�����ͷ���
        SkillDeployer deployer = skillGo.GetComponent<SkillDeployer>();

        //���ݼ�������
        deployer.SkillDate = _date;//�����㷨����

        //���ټ���(�ڳ���ʱ�䵽��֮�����ټ���)
        Destroy(skillGo, _date.durationTime);

        //����������ȴ:�����ܵ���ȴ����һ�غ�
        //�ô���Ӧ�÷��ڻغϽ�����ִ��
        // CoolTimeDown(skills);


    }

    //������ȴ
    public void CoolTimeDown(SkillDate[] _skills)
    {
        //������δ��ȴ�õļ��ܣ���ȴʱ�����һ�غ�
        foreach (var skill in _skills)
        {
            //��Ҫִ�м�����ȴ���������ü��ܾ�����ȴʱ��
            if (skill.coolTime == 0 && skill.coolRemain > 0)
            {
                skill.coolRemain--;
            }
        }

    }

    //��ʼ������
    private void InitSkill(SkillDate _date)
    {
        //_date.prefbaName -->_date.skillName
        //�ҵ�����Ԥ�Ƽ�
        //_date.skillName = Resources.Load<GameObject>("SkillPrefabs/" + _date.prefbaName).name;
        //�����ܵ��ͷ��ߣ�Ҳ���Ǽ����ͷ��������ڵĶ�������Ϊ����ӵ����
        //ccc
        _date.owner = gameObject;
    }

    //�����ͷ�����
    public SkillDate PrepareSkill(int _id)
    {
        SkillDate date = new SkillDate();
        //����ID���Ҽ�������-->�ж��ͷ�����-->��������
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].skillID == _id)
            {
                date = skills[i];
            }
            else
            {
                date = null;
            }
        }

        if (date != null && date.coolRemain <= 0 && GetComponent<PieceDate>().mp >= date.cost)
        {
            return date;
        }
        else
        {
            return null;
        }
    }



    
}

