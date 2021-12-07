using System.Collections.Generic;
using UnityEngine;
/*
������ϢԤ����
���ݼ���ID���ؼ�����ϸ��Ϣ�����Ҹ��������
*/
namespace YiLaiDemo.Skill
{
    public class LoadSkillDate : MonoBehaviour
    {
        [Header("������Ϣ�ı��ļ�")]
        public TextAsset SkillText;

        //�����ı���Ϣ
        Dictionary<string,string[]> skillText = new Dictionary<string,string[]>();

        private void Awake()
        {
            SkillText = Resources.Load<TextAsset>("SkillDateStore/skillDateText");
            //GameManager.instance.Pieces[0]
        }

        private void Start()
        {
            GainSkillTxtdate();
            Debug.Log(SkillText.name);

            for (int i = 0; i < GameManager.instance.Pieces.Length; i++)
            {
                var skill = GameManager.instance.Pieces[i].GetComponent<PieceSkillManager>().skilldate;
                LoadSkilldate( skill);
            }
        }

        //�����ı��ļ����ؼ�����Ϣ
        public void LoadSkilldate(SkillDate[] _skill)
        {
            string id;

            for (int i = 0; i < _skill.Length; i++)
            {
                //��ȡ����ID
                id = _skill[i].skillID.ToString();
                foreach (string key in skillText.Keys)
                {
                    if (key == id)
                    {
                        //ID,���ƣ���������ȴ���ͷ����ͣ��������ģ����ܷ�Χ��Ŀ�������
                        //����Ӱ�����ͣ�����Ԥ�Ƽ����ƣ����ܵȼ�,
                        _skill[i].skillID =  int.Parse(skillText[key][0]);
                        _skill[i].skillName = skillText[key][1];
                        _skill[i].description = skillText[key][2];
                        _skill[i].coolTime = int.Parse(skillText[key][3]);
                        _skill[i].skillGoType = skillText[key][4];
                        _skill[i].cost = int.Parse(skillText[key][5]);
                        _skill[i].attackDistance = int.Parse(skillText[key][6]);
                        _skill[i].attackTragetTags = int.Parse(skillText[key][7]);
                        _skill[i].impactType = skillText[key][8].Split(',');
                        _skill[i].prefbaName = skillText[key][9];
                        _skill[i].level = int.Parse(skillText[key][10]);
                    }
                }
                        
            }
        }

        //��ȡ�����ı���Ϣ
        private void GainSkillTxtdate()
        {
            skillText.Clear();

            var txtDate = SkillText.text.Split('\n');
            for (int i = 0; i < txtDate.Length; i++)
            {
                if (!txtDate[0].Equals('#'))
                {
                    var sectionDate = txtDate[i].Split(';');
                    skillText.Add(sectionDate[0], sectionDate);
                }
            }
        }
    }
}

