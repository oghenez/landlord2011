using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////

    public partial class Դ������
    {
        public Դ������()
        {
            this.ID = Guid.NewGuid();
            this.����ʱ�� = DateTime.Now;//����Ϊ��ϸʱ�䣬����Ƚ�
        }

        #region Ԥ�����ѯ
        /// <summary>
        /// Ԥ�����ѯ0 -- ��ѯ����
        /// </summary>
        static readonly Func<Entities, ObjectQuery<Դ������>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<Դ������>>(
            (context) => (ObjectQuery<Դ������>)context.Դ������.
                OrderByDescending(m => m.����ʱ��));

        /// <summary>
        /// Ԥ�����ѯ1 -- ����Դ��ID����
        /// </summary>
        static readonly Func<Entities,Guid, ObjectQuery<Դ������>> compiledQuery1 =
            CompiledQuery.Compile<Entities,Guid, ObjectQuery<Դ������>>(
            (context,guid) => (ObjectQuery<Դ������>)context.Դ������.
                Where(m=>m.Դ��ID == guid).
                OrderByDescending(m => m.����ʱ��));

        /// <summary>
        ///��ѯԴ�������¼��������ʱ������ 
        ///1.��ѯ����Դ�������¼ 
        ///2.����Դ��ID���� 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ObjectQuery<Դ������> GetYFCB(MyContext context,Guid? Դ��ID)
        {
            ObjectQuery<Դ������> result = null;
            if (Դ��ID == null || Դ��ID == Guid.Empty)
            {
                result = compiledQuery0.Invoke(context);
            }
            else
            {
                result = compiledQuery1.Invoke(context, (Guid)Դ��ID);
            }
            return result;
        }

        /// <summary>
        /// ����Դ��ID�ͳ���ʱ�䣬�õ���Դ��ˮ�������һ�εĳ���ֵ��
        /// </summary>
        /// <param name="Դ��ID"></param>
        /// <returns>����double����ֱ��Ӧˮ���硢��</returns>
        public static double?[] GetNearestValue(MyContext context, Guid Դ��ID,DateTime dt)
        {
            double?[] returnVal = new double?[3];
            ObjectQuery<Դ������> result = compiledQuery1.Invoke(context, (Guid)Դ��ID);
            Դ������ temp = result.FirstOrDefault(m => m.ˮֹ��.HasValue && m.����ʱ�� < dt);
            returnVal[0] = temp == null ? null : temp.ˮֹ��;

            temp = result.FirstOrDefault(m => m.��ֹ��.HasValue && m.����ʱ�� < dt);
            returnVal[1] = temp == null ? null : temp.��ֹ��;

            temp = result.FirstOrDefault(m => m.����ʣ������.HasValue && m.����ʱ�� < dt);
            returnVal[2] = temp == null ? null : temp.����ʣ������;
            return returnVal;
        }

        #endregion
    }
}
