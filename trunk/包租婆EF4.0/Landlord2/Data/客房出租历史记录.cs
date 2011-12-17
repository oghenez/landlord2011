using System;
using System.Data.Objects;
using System.Linq;

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
        ///  1.��ѯ���пͷ������ϸ - GetRentDetails(null)
        ///  2.���ݿͷ�ID���� - GetRentDetails(�ͷ�ID, null)
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


        #endregion

    }

   
}
