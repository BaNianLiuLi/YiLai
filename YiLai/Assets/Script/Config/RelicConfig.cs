using System.Collections.Generic;
using UnityEngine;

/*
��������
*/
namespace YiLaiDemo
{
    public class ResilConfig
    {
        public List<ResilData> resilList;
        /// <summary>
        /// �������б���������
        /// </summary>
        /// <param name="_resil">��Ҫ��ӵ�����</param>
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
                        Debug.Log("��������Ѵ��ڸ����");
                        return;
                    }
                }
            }

            resilList.Add(_resil);
        }

        /// <summary>
        /// �������б�ɾ������
        /// </summary>
        /// <param name="_resil">��Ҫɾ��������</param>
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
                        Debug.Log("δ�ҵ������");
                        return;
                    }
                }
            }

        }

        /// <summary>
        /// �������б��ѯ
        /// </summary>
        /// <param name="_resil">��Ҫ��ѯ������</param>
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
        /// ��ȡ�����б�
        /// </summary>
        /// <returns></returns>
        public List<ResilData> GetResilList()
        {
            return resilList;
        }
    }
}

