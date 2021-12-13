using UnityEngine;

/*
技能管理器
*/
public class CharacterSkillManager : MonoBehaviour
{

    //注意：所有你工程中需要使用的资源都需要放到Resources文件夹中！
    //技能列表
    public SkillDate[] skills;

    private void Start()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            InitSkill(skills[i]);
        }
    }

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

        //开启技能冷却:将技能的冷却减少一回合
        //该代码应该放在回合结束后执行
        // CoolTimeDown(skills);


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

    //初始化技能
    private void InitSkill(SkillDate _date)
    {
        //_date.prefbaName -->_date.skillName
        //找到技能预制件
        //_date.skillName = Resources.Load<GameObject>("SkillPrefabs/" + _date.prefbaName).name;
        //将技能的释放者，也就是技能释放器所挂在的对象设置为技能拥有者
        //ccc
        _date.owner = gameObject;
    }

    //技能释放条件
    public SkillDate PrepareSkill(int _id)
    {
        SkillDate date = new SkillDate();
        //根据ID查找技能数据-->判断释放条件-->返回数据
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

