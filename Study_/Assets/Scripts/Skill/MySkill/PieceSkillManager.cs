using UnityEngine;

/*
棋子技能管理器
*/

namespace YiLaiDemo.Skill
{
    public class PieceSkillManager : MonoBehaviour
    {
        //技能信息储存
        public SkillDate[] skilldate;
       
        LoadSkillDate loadSkillDate = new LoadSkillDate();
        /// <summary>
        /// 生成技能
        /// </summary>
        /// <param name="_date">需要生成的技能名称</param>
        public void GenerateSkill(SkillDate _date)
        {
            //创建技能(技能的数据，技能的释放位置，技能的旋转位置)
            GameObject skillGo = Instantiate(_date.skillPrefba, transform.position, transform.rotation).gameObject;

            //获取技能释放器
            SkillDeployer deployer = skillGo.GetComponent<SkillDeployer>();

            //传递技能数据
            deployer.SkillDate = _date;//创建算法对象

            //销毁技能(在持续时间到达之后销毁技能)
            Destroy(skillGo, _date.durationTime);
        }

        private void Start()
        {
            
            for (int i = 0; i < skilldate.Length; i++)
            {
                InitSkill(skilldate[i]);
               
            }
        }
        //初始化技能
        public void InitSkill(SkillDate _date)
        {
            //设定技能的拥有者
            _date.owner = gameObject;
            //加载技能预制件
            _date.skillPrefba = Resources.Load<GameObject>("Prefabs/SkillPrefabs/" + _date.prefbaName);
        }


        //技能冷却
        public void CoolTimeDown(SkillDate[] _skills)
        {
            //将所有未冷却好的技能，冷却时间减少一回合
            foreach (var skill in _skills)
            {
                //需要执行技能冷却的条件：该技能具有冷却时间
                if (skill.coolTime == 0 && skill.coolRemain > 0)
                {
                    skill.coolRemain--;
                }
            }

        }

    }
}

