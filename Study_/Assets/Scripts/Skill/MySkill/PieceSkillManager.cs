using UnityEngine;

/*
���Ӽ��ܹ�����
*/

namespace YiLaiDemo.Skill
{
    public class PieceSkillManager : MonoBehaviour
    {
        //������Ϣ����
        public SkillDate[] skilldate;
       
        LoadSkillDate loadSkillDate = new LoadSkillDate();
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
        }

        private void Start()
        {
            
            for (int i = 0; i < skilldate.Length; i++)
            {
                InitSkill(skilldate[i]);
               
            }
        }
        //��ʼ������
        public void InitSkill(SkillDate _date)
        {
            //�趨���ܵ�ӵ����
            _date.owner = gameObject;
            //���ؼ���Ԥ�Ƽ�
            _date.skillPrefba = Resources.Load<GameObject>("Prefabs/SkillPrefabs/" + _date.prefbaName);
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

    }
}

