using UnityEngine;
/*
�����ͷ���
*/

public class SkillDeployer : MonoBehaviour
{
    //��Ҫ�ͷŵļ���
    //�ɼ��ܹ������ṩ
    private SkillDate skillDate;
    public SkillDate SkillDate
    {
        get
        {
            return skillDate;
        }
        set
        {
            skillDate = value;
            //�����㷨����
            InitDeployer();
        }
    }


    //ѡ���㷨����
    private IAttackeSelector selector;
    //Ӱ���㷨����
    private IAttackeSelector[] selectors;


    //��ʼ���ͷ���
    private void InitDeployer()
    {
        //�����㷨����
        //ѡ��
        selector = DeployerConfigFactory.CreatAttackeSelector(skillDate);

        //�㷨
        selectors = DeployerConfigFactory.CreatAttackeSelectors(skillDate);

    }
    //ִ���㷨����

    //ִ�з�ʽ


}
