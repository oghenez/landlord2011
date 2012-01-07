using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////


    public partial class ����
    {
        public ����()
        {
            this.ID = Guid.NewGuid();
            this.����ʱ�� = DateTime.Today;
            this.�������� = DateTime.Today;
        }

        #region Ԥ�����ѯ
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ��������
        /// </summary>
        static readonly Func<Entities, ObjectQuery<����>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<����>>(
            (context) => (ObjectQuery<����>)context.����.
                OrderByDescending(m => m.����ʱ��));
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ�������ѣ�������ʱ����������
        /// </summary>
        public static ObjectQuery<����> GetTX(MyContext context)
        {
            return compiledQuery0.Invoke(context);
        }

        /// <summary>
        /// Ԥ�����ѯ1 -- ��ѯ���7������(�����ѵ��ڵ�)
        /// </summary>
        static readonly Func<Entities, ObjectQuery<����>> compiledQuery1 =
            CompiledQuery.Compile<Entities, ObjectQuery<����>>(
            (context) => (ObjectQuery<����>)context.����.
                Where(m => m.����� == false && (m.����ʱ�� - DateTime.Now).Days <= 7).
                OrderByDescending(m => m.����ʱ��));
        /// <summary>
        /// Ԥ�����ѯ1 -- ��ѯ���7������(�����ѵ��ڵ�)��������ʱ����������
        /// </summary>
        public static ObjectQuery<����> GetTX_In7Days(MyContext context)
        {
            return compiledQuery1.Invoke(context);
        }


        #endregion

    }
   
}
