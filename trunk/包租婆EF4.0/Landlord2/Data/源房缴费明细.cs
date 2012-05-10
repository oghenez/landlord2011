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
            this.�ɷ�ʱ�� = DateTime.Now;//�ɷ�ʱ��Ĭ�ϵ�ǰ����ʱ�䣬֮��Ĳ�ѯ����ݴ˽������У�������Ҫ��ϸʱ�䡣
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
        ///  1.��ѯ����Դ���ɷ���ϸ
        ///  2.����Դ��ID�ͽɷ���2����������
        ///  3.����Դ��ID����
        ///  4.���ݽɷ������ 
        /// </summary>
        /// <param name="Դ��ID"></param>
        /// <param name="�ɷ���"></param>
        /// <returns></returns>
        public static ObjectQuery<Դ���ɷ���ϸ> GetPayDetails(MyContext context, Guid? Դ��ID, string �ɷ���)
        {
            ObjectQuery<Դ���ɷ���ϸ> result = null;
            if (Դ��ID == null || Դ��ID == Guid.Empty)
            {
                if(string.IsNullOrEmpty(�ɷ���))
                {
                    result = compiledQuery0.Invoke(context);
                }
                else
                {
                    result = compiledQuery3.Invoke(context, �ɷ���);
                }
            }
            else
            { 
                if(string.IsNullOrEmpty(�ɷ���))
                {
                    result = compiledQuery2.Invoke(context, (Guid)Դ��ID);
                }
                else
                {
                    result = compiledQuery1.Invoke(context, (Guid)Դ��ID, �ɷ���);
                }
            }
            return result;
        }

        /// <summary>
        /// ��ѯĳ��Դ�����һ�εĽɷ���ϸ��������ԡ����⡯����ɷ�����ԣ�
        /// ��������һ�εĽɷѲ�����DateTime.Nowʱ��㣬�����²�ѯ���ҵ���ǰ�ɷ�ʱ�����򡣣�
        /// </summary>
        /// <param name="context"></param>
        /// <param name="yf"></param>
        /// <returns></returns>
        public static Դ���ɷ���ϸ GetRecentPayDetail(MyContext context, Դ�� yf)
        {
            Դ���ɷ���ϸ recentPayDetail = null;
            var result = compiledQuery1.Invoke(context, yf.ID, "����").Execute(MergeOption.NoTracking).ToList();
            var temp = result.GetEnumerator();
            do
            {
                if (temp.MoveNext())
                    recentPayDetail = temp.Current;
                else
                    break;
            }
            while (temp.Current.��ʼ.Value.Date > DateTime.Now.Date);
            return recentPayDetail;
        }
        #endregion

    }
}
