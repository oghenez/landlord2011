using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////


    public partial class Դ��
    {
        public Դ��()
        {
            this.ID = Guid.NewGuid();
        }

        #region Ԥ�����ѯ
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ����
        /// </summary>
        static readonly Func<Entities, ObjectQuery<Դ��>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<Դ��>>(
            (context) => context.Դ��);
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ����Դ��
        /// </summary>
        public static ObjectQuery<Դ��> GetYF()
        {
            return compiledQuery0.Invoke(Main.context);
        }

        /// <summary>
        /// Ԥ�����ѯ1 -- ��ѯ����ʷԴ��
        /// </summary>
        static readonly Func<Entities, ObjectQuery<Դ��>> compiledQuery1 =
            CompiledQuery.Compile<Entities, ObjectQuery<Դ��>>(
            (context) => (ObjectQuery<Դ��>)context.Դ��.Where(m => m.Դ������Э��.Max(n => n.��ֹ) > DateTime.Now));
        /// <summary>
        /// Ԥ�����ѯ1 -- ��ѯ����ʷԴ��
        /// </summary>
        public static ObjectQuery<Դ��> GetYF_NoHistory()
        {
            return compiledQuery1.Invoke(Main.context);
        }

        /// <summary>
        /// Ԥ�����ѯ1 -- ��ѯ��ʷԴ��
        /// </summary>
        static readonly Func<Entities, ObjectQuery<Դ��>> compiledQuery2 =
            CompiledQuery.Compile<Entities, ObjectQuery<Դ��>>(
            (context) => (ObjectQuery<Դ��>)context.Դ��.Where(m => m.Դ������Э��.Max(n => n.��ֹ) <= DateTime.Now));
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ��ʷԴ��
        /// </summary>
        public static ObjectQuery<Դ��> GetYF_History()
        {
            return compiledQuery2.Invoke(Main.context);
        }
        #endregion
    }
}
