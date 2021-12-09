using System.Collections.Generic;
using UnityEngine;

/*
遗物配置
*/
namespace YiLaiDemo
{
    public class ResilConfig
    {
        public List<ResilData> resilList;
        /// <summary>
        /// 向遗物列表增加遗物
        /// </summary>
        /// <param name="_resil">需要添加的遗物</param>
        public void AddResil(ResilData _resil)
        {
            if (_resil == null)
            {
                return;
            }
            else
            {
                foreach (ResilData v in resilList)
                {
                    if (v.Name.Equals(_resil.Name))
                    {
                        Debug.Log("遗物表中已存在该遗物。");
                        return;
                    }
                }
            }

            resilList.Add(_resil);
        }

        /// <summary>
        /// 从遗物列表删除遗物
        /// </summary>
        /// <param name="_resil">需要删除的遗物</param>
        public void DeleteResil(ResilData _resil)
        {
            if (_resil == null)
            {
                return;
            }
            else
            {
                foreach (ResilData v in resilList)
                {
                    if (v.Name.Equals(_resil.Name))
                    {
                        resilList.Remove(v);
                    }
                    else
                    {
                        Debug.Log("未找到该遗物。");
                        return;
                    }
                }
            }

        }

        /// <summary>
        /// 从遗物列表查询
        /// </summary>
        /// <param name="_resil">需要查询的遗物</param>
        /// <returns></returns>
        public bool QuertResil(ResilData _resil)
        {
            bool being = false;
            foreach (var v in resilList)
            {
                if (_resil == v)
                {
                    being = true;
                }
            }
            return being;
        }

        /// <summary>
        /// 获取遗物列表
        /// </summary>
        /// <returns></returns>
        public List<ResilData> GetResilList()
        {
            return resilList;
        }
    }
}

