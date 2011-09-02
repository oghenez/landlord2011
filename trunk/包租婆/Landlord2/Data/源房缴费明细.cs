using System;
using System.Collections.Generic;
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
        }


        #region Ԥ�����ѯ
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ����
        /// </summary>
        static readonly Func<Entities, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<Դ���ɷ���ϸ>>(
            (context) => context.Դ���ɷ���ϸ);
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ����Դ���ɷ���ϸ
        /// </summary>
        public static ObjectQuery<Դ���ɷ���ϸ> GetPayDetails()
        {
            return compiledQuery0.Invoke(Main.context);
        }

        /// <summary>
        /// Ԥ�����ѯ1 -- ����Դ��ID�ͽɷ���2����������
        /// </summary>
        static readonly Func<Entities, Guid, string, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, string, ObjectQuery<Դ���ɷ���ϸ>>(
            (context, guid, payItem) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.Where(m => m.Դ��ID == guid && m.�ɷ��� == payItem));
        /// <summary>
        /// Ԥ�����ѯ1 -- ����Դ��ID�ͽɷ���2����������
        /// </summary>
        public static ObjectQuery<Դ���ɷ���ϸ> GetPayDetails(Guid guid, string �ɷ���)
        {
            return compiledQuery1.Invoke(Main.context, guid, �ɷ���);
        }

        /// <summary>
        /// Ԥ�����ѯ2 -- ����Դ��ID����
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery2 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<Դ���ɷ���ϸ>>(
            (context, guid) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.Where(m => m.Դ��ID == guid));
        /// <summary>
        /// Ԥ�����ѯ2 -- ����Դ��ID����
        /// </summary>
        public static ObjectQuery<Դ���ɷ���ϸ> GetPayDetails(Guid guid)
        {
            return compiledQuery2.Invoke(Main.context, guid);
        }

        /// <summary>
        /// Ԥ�����ѯ3 -- ���ݽɷ������
        /// </summary>
        static readonly Func<Entities, string, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery3 =
            CompiledQuery.Compile<Entities, string, ObjectQuery<Դ���ɷ���ϸ>>(
            (context, payItem) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.Where(m => m.�ɷ��� == payItem));
        /// <summary>
        /// Ԥ�����ѯ3 -- ���ݽɷ������
        /// </summary>
        public static ObjectQuery<Դ���ɷ���ϸ> GetPayDetails(string �ɷ���)
        {
            return compiledQuery3.Invoke(Main.context, �ɷ���);
        }
        #endregion

    }
}
