using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////

    public partial class Դ���ɷ���ϸ
    {
        public Դ���ɷ���ϸ()
        {
            this.ID = Guid.NewGuid();
            this.�ɷ�ʱ�� = DateTime.Now.Date;//�ɷ�ʱ��Ĭ�ϵ�ǰ��������
        }


        #region Ԥ�����ѯ
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ����
        /// </summary>
        static readonly Func<Entities, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<Դ���ɷ���ϸ>>(
            (context) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.
                OrderByDescending(m => m.�ɷ�ʱ��));

        /// <summary>
        /// Ԥ�����ѯ1 -- ����Դ��ID�ͽɷ���2����������
        /// </summary>
        static readonly Func<Entities, Guid, string, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, string, ObjectQuery<Դ���ɷ���ϸ>>(
            (context, guid, payItem) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.
                Where(m => m.Դ��ID == guid && m.�ɷ��� == payItem).
                OrderByDescending(m => m.�ɷ�ʱ��));


        /// <summary>
        /// Ԥ�����ѯ2 -- ����Դ��ID����
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery2 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<Դ���ɷ���ϸ>>(
            (context, guid) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.
                Where(m => m.Դ��ID == guid).
                OrderByDescending(m => m.�ɷ�ʱ��));


        /// <summary>
        /// Ԥ�����ѯ3 -- ���ݽɷ������
        /// </summary>
        static readonly Func<Entities, string, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery3 =
            CompiledQuery.Compile<Entities, string, ObjectQuery<Դ���ɷ���ϸ>>(
            (context, payItem) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.
                Where(m => m.�ɷ��� == payItem).
                OrderByDescending(m => m.�ɷ�ʱ��));

        /// <summary>
        ///  [����Ԥ�����ѯ]��ѯԴ���ɷ���ϸ - Ĭ�ϰ��ɷ�ʱ����������
        ///  1.��ѯ����Դ���ɷ���ϸ - GetPayDetails(null,null)
        ///  2.����Դ��ID�ͽɷ���2���������� - GetPayDetails(Դ��ID, �ɷ���)
        ///  3.����Դ��ID���� - GetPayDetails(Դ��ID, null)
        ///  4.���ݽɷ������ - GetPayDetails(null, �ɷ���)
        /// </summary>
        /// <param name="Դ��ID"></param>
        /// <param name="�ɷ���"></param>
        /// <returns></returns>
        public static ObjectQuery<Դ���ɷ���ϸ> GetPayDetails(Guid? Դ��ID, string �ɷ���)
        {
            ObjectQuery<Դ���ɷ���ϸ> result = null;
            if (Դ��ID == null || Դ��ID == Guid.Empty)
            {
                if(string.IsNullOrEmpty(�ɷ���))
                {
                    result = compiledQuery0.Invoke(Main.context);
                }
                else
                {
                    result = compiledQuery3.Invoke(Main.context, �ɷ���);
                }
            }
            else
            { 
                if(string.IsNullOrEmpty(�ɷ���))
                {
                    result = compiledQuery2.Invoke(Main.context, (Guid)Դ��ID);
                }
                else
                {
                    result = compiledQuery1.Invoke(Main.context, (Guid)Դ��ID, �ɷ���);
                }
            }
            return result;
        }

        #endregion

    }
}
