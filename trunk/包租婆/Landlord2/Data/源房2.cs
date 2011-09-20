using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{
    public partial class Դ�� : IValidatableObject
    {
        public static Դ�� MyCreate()
        {
            return new Դ��() { ID = Guid.NewGuid() };
        }

        //#region Ԥ�����ѯ
        ///// <summary>
        ///// Ԥ�����ѯ0 -- ��ѯ����
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<Դ��>> compiledQuery0 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<Դ��>>(
        //    (context) => (ObjectQuery<Դ��>)context.Դ��.
        //        OrderByDescending(m => m.Դ������Э��.Min(n => n.��ʼ)));
        ///// <summary>
        ///// Ԥ�����ѯ0 -- ��ѯ����Դ�������ǩԼ������ǰ
        ///// </summary>
        //public static ObjectQuery<Դ��> GetYF()
        //{
        //    return compiledQuery0.Invoke(Main.context);
        //}

        ///// <summary>
        ///// Ԥ�����ѯ1 -- ��ѯ����ʷԴ��
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<Դ��>> compiledQuery1 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<Դ��>>(
        //    (context) => (ObjectQuery<Դ��>)context.Դ��.
        //        Where(m => m.Դ������Э��.Max(n => n.��ֹ) > DateTime.Now).
        //        OrderByDescending(m => m.Դ������Э��.Min(n => n.��ʼ)));
        ///// <summary>
        ///// Ԥ�����ѯ1 -- ��ѯ����ʷԴ�������ǩԼ������ǰ
        ///// </summary>
        //public static ObjectQuery<Դ��> GetYF_NoHistory()
        //{
        //    return compiledQuery1.Invoke(Main.context);
        //}
        public static ObjectQuery<Դ��> GetYF_NoHistory(Entities context)
        {
            return compiledQuery1.Invoke(Main.context);
        }
        ///// <summary>
        ///// Ԥ�����ѯ1 -- ��ѯ��ʷԴ��
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<Դ��>> compiledQuery2 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<Դ��>>(
        //    (context) => (ObjectQuery<Դ��>)context.Դ��.
        //        Where(m => m.Դ������Э��.Max(n => n.��ֹ) <= DateTime.Now).
        //        OrderByDescending(m => m.Դ������Э��.Min(n => n.��ʼ)));
        ///// <summary>
        ///// Ԥ�����ѯ0 -- ��ѯ��ʷԴ�������ǩԼ������ǰ
        ///// </summary>
        //public static ObjectQuery<Դ��> GetYF_History()
        //{
        //    return compiledQuery2.Invoke(Main.context);
        //}
        //#endregion

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //У�����зǿ�����
            //...................

            //Դ�������С�Դ������Э����
            if (this.Դ������Э��.Count() == 0)
                result.Add(new ValidationResult("����дЭ������!"));

            //У��Դ���µġ�Դ������Э������
            DateTime temp = DateTime.MinValue;
            foreach (var o in this.Դ������Э��.OrderBy(m => m.��ʼ))
            {
                result.AddRange(o.Validate(validationContext));//ʱ��У��
                //�ж��Ƿ�����
                if (temp != DateTime.MinValue)
                {
                    if (temp.Date.AddDays(1) != o.��ʼ.Date)
                    {
                        result.Add(new ValidationResult(string.Format("ʱ��β�����������[��ֹ{0}]��[��ʼ{1}]!",
                            temp.ToShortDateString(), o.��ʼ.ToShortDateString())));
                    }
                }
                temp = o.��ֹ; //���︳ֵ
            }

            //������Դ������Э����ʱ��Ҳ���������״̬�Ŀͷ�����ô��ʱ������������ʼ��ֹʱ����롮���������пͷ����ڵ���ʼ��ֹʱ���
            if (this.Դ������Э��.Count > 0)
            {
                DateTime start = this.Դ������Э��.Min(m => m.��ʼ);
                DateTime end = this.Դ������Э��.Max(m => m.��ֹ);
                foreach (var o in this.�ͷ�.Where(m => !string.IsNullOrEmpty(m.�⻧)))
                {
                    if (o.��ʼ < start)
                        result.Add(new ValidationResult(string.Format("�ͷ���ʼʱ�䲻����Դ����ʼʱ��֮ǰ������Դ����ʼ����[{0}]��ͷ�[{1}]����ʼʱ��{2}��",
                            start.ToShortDateString(), o.����, o.��ʼ.Value.ToShortDateString())));
                    if (o.��ֹ > end)
                        result.Add(new ValidationResult(string.Format("�ͷ���ֹʱ�䲻����Դ����ֹʱ��֮������Դ����ֹʱ��[{0}]��ͷ�[{1}]����ֹʱ��{2}��",
                            end.ToShortDateString(), o.����, o.��ֹ.Value.ToShortDateString())));
                }
            }

            return result;
        }
    }
}
