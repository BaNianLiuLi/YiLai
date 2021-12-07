using UnityEngine;
/*
技能释放器
*/

public class SkillDeployer : MonoBehaviour
{
    //需要释放的技能
    //由技能管理器提供
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
            //创建算法对象
            InitDeployer();
        }
    }


    //选区算法对象
    private IAttackeSelector selector;
    //影响算法对象
    private IAttackeSelector[] selectors;


    //初始化释放器
    private void InitDeployer()
    {
        //创建算法对象
        //选区
        selector = DeployerConfigFactory.CreatAttackeSelector(skillDate);

        //算法
        selectors = DeployerConfigFactory.CreatAttackeSelectors(skillDate);

    }
    //执行算法对象

    //执行方式


}
