using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    public partial class Դ������Э��
    {
        public Դ������Э��()
        {
            this.ID = Guid.NewGuid();
        }

        #region Ԥ�����ѯ
        /// <summary>
        /// Ԥ�����ѯ0 -- ����Դ��ID����
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<Դ������Э��>> compiledQuery0 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<Դ������Э��>>(
            (context, guid) => (ObjectQuery<Դ������Э��>)context.Դ������Э��.
                Where(m => m.Դ��ID == guid).
                OrderBy(n=>n.��ʼ));
        /// <summary>
        /// Ԥ�����ѯ0 -- ����Դ��ID���ˣ�����ʼʱ������
        /// </summary>
        public static ObjectQuery<Դ������Э��> GetByYFid(MyContext context, Guid Դ��ID)
        {
            return compiledQuery0.Invoke(context, Դ��ID);
        }
        #endregion
    }
}
