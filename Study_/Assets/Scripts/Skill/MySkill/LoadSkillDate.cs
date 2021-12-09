using System.Collections.Generic;
using UnityEngine;
/*
技能信息预加载
根据技能ID加载技能详细信息，并且赋予给棋子
*/
namespace YiLaiDemo.Skill
{
    public class LoadSkillDate : MonoBehaviour
    {
        [Header("技能信息文本文件")]
        public TextAsset SkillText;

        //技能文本信息
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

        //根据文本文件加载技能信息
        public void LoadSkilldate(SkillDate[] _skill)
        {
            string id;

            for (int i = 0; i < _skill.Length; i++)
            {
                //获取技能ID
                id = _skill[i].skillID.ToString();
                foreach (string key in skillText.Keys)
                {
                    if (key == id)
                    {
                        //ID,名称，描述，冷却，释放类型，技能消耗，技能范围，目标的类型
                        //技能影响类型，技能预制件名称，技能等级,
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

        //获取技能文本信息
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

