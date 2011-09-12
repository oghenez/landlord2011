using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////


    public partial class �ͷ������ϸ
    {
        public �ͷ������ϸ()
        {
            this.ID = Guid.NewGuid();
            this.�������� = DateTime.Today;
        }

        #region Ԥ�����ѯ
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ����
        /// </summary>
        static readonly Func<Entities, ObjectQuery<�ͷ������ϸ>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<�ͷ������ϸ>>(
            (context) => (ObjectQuery<�ͷ������ϸ>)context.�ͷ������ϸ.
                OrderByDescending(m => m.������));

        /// <summary>
        /// Ԥ�����ѯ1 -- ���ݿͷ�ID����
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<�ͷ������ϸ>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<�ͷ������ϸ>>(
            (context, guid) => (ObjectQuery<�ͷ������ϸ>)context.�ͷ������ϸ.
                Where(m => m.�ͷ�ID == guid).
                OrderByDescending(m => m.������));

        /// <summary>
        ///  [����Ԥ�����ѯ]��ѯ�ͷ������ϸ - Ĭ�ϰ���������������
        ///  1.��ѯ����Դ���ɷ���ϸ - GetRentDetails(null)
        ///  2.���ݿͷ�ID���� - GetRentDetails(�ͷ�ID, null)
        /// </summary>
        /// <param name="�ͷ�ID"></param>
        /// <returns></returns>
        public static ObjectQuery<�ͷ������ϸ> GetRentDetails(Guid? �ͷ�ID)
        {
            ObjectQuery<�ͷ������ϸ> result = null;
            if (�ͷ�ID == null || �ͷ�ID == Guid.Empty)
            {
                result = compiledQuery0.Invoke(Main.context);
            }
            else
            {
                result = compiledQuery1.Invoke(Main.context, (Guid)�ͷ�ID);
            }
            return result;
        }
        #endregion
    }

   
}
