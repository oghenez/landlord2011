using System;
using System.Data.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////


    public partial class �ͷ�������ʷ��¼
    {
        public �ͷ�������ʷ��¼()
        {
            this.ID = Guid.NewGuid();
        }

        #region Ԥ�����ѯ
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ����
        /// </summary>
        static readonly Func<Entities, ObjectQuery<�ͷ�������ʷ��¼>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<�ͷ�������ʷ��¼>>(
            (context) => (ObjectQuery<�ͷ�������ʷ��¼>)context.�ͷ�������ʷ��¼.
                OrderByDescending(m => m.��������));

        /// <summary>
        /// Ԥ�����ѯ1 -- ���ݿͷ�ID����
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<�ͷ�������ʷ��¼>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<�ͷ�������ʷ��¼>>(
            (context, guid) => (ObjectQuery<�ͷ�������ʷ��¼>)context.�ͷ�������ʷ��¼.
                Where(m => m.�ͷ�ID == guid).
                OrderByDescending(m => m.��������));

        /// <summary>
        ///  [����Ԥ�����ѯ]��ѯ�ͷ�������ʷ��¼ - Ĭ�ϰ�����������������
        ///  1.��ѯ���пͷ������ϸ
        ///  2.���ݿͷ�ID����
        /// </summary>
        /// <param name="�ͷ�ID"></param>
        /// <returns></returns>
        public static ObjectQuery<�ͷ�������ʷ��¼> GetKfHistoryDetails(MyContext context, Guid? �ͷ�ID)
        {
            ObjectQuery<�ͷ�������ʷ��¼> result = null;
            if (�ͷ�ID == null || �ͷ�ID == Guid.Empty)
            {
                result = compiledQuery0.Invoke(context);
            }
            else
            {
                result = compiledQuery1.Invoke(context, (Guid)�ͷ�ID);
            }
            return result;
        }

        /// <summary>
        /// ��ѯ��ǰ�ͷ�������ʷ��¼�漰�����������ϸ,����������������
        /// </summary>
        /// <param name="�ͷ�������ʷ��¼"></param>
        /// <returns></returns>
        public static List<�ͷ������ϸ> GetHistoryRentDetails(�ͷ�������ʷ��¼ history)
        {
            �ͷ� kf = history.�ͷ�;
            if (kf == null || kf.�ͷ������ϸ.Count == 0)
                return new List<�ͷ������ϸ>();

            //�ҵ��ÿͻ���ǰЭ����ʼʱ�䣨��ǰЭ�����ʼ����ʱ�䣩
            DateTime begin = history.��ʼ;
            DateTime end = history.��ֹ;

            return kf.�ͷ������ϸ.Where(m => m.������ >= begin.Date && m.ֹ������<=end.Date).
                OrderByDescending(m => m.������).ToList();
        }
        #endregion

    }

   
}
