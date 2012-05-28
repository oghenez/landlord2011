using System;
using System.Data.Objects;
using System.Linq;
using System.Collections.Generic;

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
        ///  1.��ѯ���пͷ������ϸ 
        ///  2.���ݿͷ�ID����
        /// </summary>
        /// <param name="�ͷ�ID"></param>
        /// <returns></returns>
        public static ObjectQuery<�ͷ������ϸ> GetRentDetails(MyContext context, Guid? �ͷ�ID)
        {
            ObjectQuery<�ͷ������ϸ> result = null;
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
        /// ��ѯ��ǰ�ͷ��⻧�����������ϸ,���������������У�����֮ǰ����ģ�
        /// </summary>
        /// <param name="�ͷ�"></param>
        /// <returns></returns>
        public static List<�ͷ������ϸ> GetRentDetails_Current(�ͷ� kf)
        {
            if(string.IsNullOrEmpty(kf.�⻧))
                return new List<�ͷ������ϸ>();
            
            //�ҵ��ÿͻ������Э����ʼʱ�䣨�ʼ����ʱ�䣩
            var histories = kf.�ͷ�������ʷ��¼.
                Where(m => m.�⻧ == kf.�⻧ && m.���֤�� == kf.���֤��);
            DateTime begin = histories.Count() == 0 ? kf.��ʼ.Value : histories.Min(n => n.��ʼ); 

            return kf.�ͷ������ϸ.Where(m=>m.������ >= begin.Date).
                OrderByDescending(m => m.������).ToList();
        }

        /// <summary>
        /// ��ѯ��ǰ�ͷ��⻧�ĵ�ǰЭ�����ڵ����������ϸ,���������������У�������֮ǰ����ģ�
        /// </summary>
        /// <param name="�ͷ�"></param>
        /// <returns></returns>
        public static List<�ͷ������ϸ> GetRentDetails_Current2(�ͷ� kf)
        {
            if (string.IsNullOrEmpty(kf.�⻧))
                return new List<�ͷ������ϸ>();

            //�ҵ��ÿͻ���ǰЭ����ʼʱ�䣨��ǰЭ�����ʼ����ʱ�䣩
            DateTime begin = kf.��ʼ.Value;

            return kf.�ͷ������ϸ.Where(m => m.������ >= begin.Date).
                OrderByDescending(m => m.������).ToList();
        }

        /// <summary>
        /// ��ѯ����DateTime.Nowʱ�����ѽɷ���ʱ���
        /// 1��������һ�εĽɷ���ʼʱ�����DateTime.Nowʱ��㣬�������ʱ��Σ������²�ѯ���ҵ�����DateTime.Nowʱ���Ľɷ�ʱ�����򣬲����ӡ���
        /// 2�����Ƿ�ѣ������һ�νɷ���ĩʱ��С��DateTime.Now����ô��������ɷ�ʱ������
        /// </summary>
        /// <param name="context"></param>
        /// <param name="kf"></param>
        /// <returns></returns>
        public static MyDate GetRecentMyDate(MyContext context, �ͷ� kf)
        {
            MyDate myDate = new MyDate();
            var result = GetRentDetails_Current2(kf);
            var temp = result.GetEnumerator();
            do
            {
                if (temp.MoveNext())
                {
                    myDate.Begin = MyDate.Smaller(temp.Current.������, myDate.Begin);
                    myDate.End = MyDate.Bigger(temp.Current.ֹ������, myDate.End);
                }
                else
                    break;
            }
            while (temp.Current.������.Date > DateTime.Now.Date);

            if (myDate.Begin == DateTime.MaxValue || myDate.End == DateTime.MinValue)
                return null;
            else
                return myDate;
        }
        #endregion
    }

   
}
