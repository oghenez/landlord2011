using System;
using System.Data.Objects;
using System.Linq;
using System.Text;

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

        //�������ѵ�ToString��������������ؽ��������ListBox�ؼ���
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.����ʱ��.ToShortDateString());
            sb.Append("\t");
            sb.Append(this.����);
            
            return sb.ToString();
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
        static readonly Func<Entities,DateTime, ObjectQuery<����>> compiledQuery1 =
            CompiledQuery.Compile<Entities,DateTime, ObjectQuery<����>>(
            (context,endDate) => (ObjectQuery<����>)context.����.
                Where(m => m.����� == false && m.����ʱ�� <= endDate).
                OrderBy(m => m.����ʱ��));
        /// <summary>
        /// Ԥ�����ѯ1 -- ��ѯ���7������(�����ѵ��ڵ�)��������ʱ��˳�����С���������ǰ�桿
        /// </summary>
        public static ObjectQuery<����> GetTX_In7Days(MyContext context)
        {
            return compiledQuery1.Invoke(context,DateTime.Today.AddDays(7));
        }


        #endregion

    }
   
}
