using System;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{
    public partial class SourceRoomPaymentDetail : IValidatableObject
    {
        public SourceRoomPaymentDetail()
        {
            this.ID = Guid.NewGuid();
            this.�ɷ�ʱ�� = DateTime.Today;//�ɷ�ʱ��Ĭ�ϵ�ǰ��������
        }


        //#region Ԥ�����ѯ
        ///// <summary>
        ///// Ԥ�����ѯ0 -- ��ѯ����
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery0 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<Դ���ɷ���ϸ>>(
        //    (context) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.
        //        OrderByDescending(m => m.�ɷ�ʱ��));

        ///// <summary>
        ///// Ԥ�����ѯ1 -- ����Դ��ID�ͽɷ���2����������
        ///// </summary>
        //static readonly Func<Entities, Guid, string, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery1 =
        //    CompiledQuery.Compile<Entities, Guid, string, ObjectQuery<Դ���ɷ���ϸ>>(
        //    (context, guid, payItem) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.
        //        Where(m => m.Դ��ID == guid && m.�ɷ��� == payItem).
        //        OrderByDescending(m => m.�ɷ�ʱ��));


        ///// <summary>
        ///// Ԥ�����ѯ2 -- ����Դ��ID����
        ///// </summary>
        //static readonly Func<Entities, Guid, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery2 =
        //    CompiledQuery.Compile<Entities, Guid, ObjectQuery<Դ���ɷ���ϸ>>(
        //    (context, guid) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.
        //        Where(m => m.Դ��ID == guid).
        //        OrderByDescending(m => m.�ɷ�ʱ��));


        ///// <summary>
        ///// Ԥ�����ѯ3 -- ���ݽɷ������
        ///// </summary>
        //static readonly Func<Entities, string, ObjectQuery<Դ���ɷ���ϸ>> compiledQuery3 =
        //    CompiledQuery.Compile<Entities, string, ObjectQuery<Դ���ɷ���ϸ>>(
        //    (context, payItem) => (ObjectQuery<Դ���ɷ���ϸ>)context.Դ���ɷ���ϸ.
        //        Where(m => m.�ɷ��� == payItem).
        //        OrderByDescending(m => m.�ɷ�ʱ��));

        ///// <summary>
        /////  [����Ԥ�����ѯ]��ѯԴ���ɷ���ϸ - Ĭ�ϰ��ɷ�ʱ����������
        /////  1.��ѯ����Դ���ɷ���ϸ - GetPayDetails(null,null)
        /////  2.����Դ��ID�ͽɷ���2���������� - GetPayDetails(Դ��ID, �ɷ���)
        /////  3.����Դ��ID���� - GetPayDetails(Դ��ID, null)
        /////  4.���ݽɷ������ - GetPayDetails(null, �ɷ���)
        ///// </summary>
        ///// <param name="Դ��ID"></param>
        ///// <param name="�ɷ���"></param>
        ///// <returns></returns>
        //public static ObjectQuery<Դ���ɷ���ϸ> GetPayDetails(Guid? Դ��ID, string �ɷ���)
        //{
        //    ObjectQuery<Դ���ɷ���ϸ> result = null;
        //    if (Դ��ID == null || Դ��ID == Guid.Empty)
        //    {
        //        if(string.IsNullOrEmpty(�ɷ���))
        //        {
        //            result = compiledQuery0.Invoke(Main.context);
        //        }
        //        else
        //        {
        //            result = compiledQuery3.Invoke(Main.context, �ɷ���);
        //        }
        //    }
        //    else
        //    { 
        //        if(string.IsNullOrEmpty(�ɷ���))
        //        {
        //            result = compiledQuery2.Invoke(Main.context, (Guid)Դ��ID);
        //        }
        //        else
        //        {
        //            result = compiledQuery1.Invoke(Main.context, (Guid)Դ��ID, �ɷ���);
        //        }
        //    }
        //    return result;
        //}

        //#endregion


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //Դ���ɷ���ϸ����������һ���ϼ���Դ��
            if (this.Դ��ID == null || this.Դ��ID == Guid.Empty)
            {
                result.Add(new ValidationResult("��ָ���˽ɷ���ϸ��Դ��! "));
                return result;
            }

            //У�����зǿ�����
            //..................

            //ʱ��У��
            //���ɽ��е���ֵ
            if (this.��ʼ.HasValue && !this.��ֹ.HasValue)
            {
                result.Add(new ValidationResult("ȱ����ֹʱ��!"));
            }
            else if (!this.��ʼ.HasValue && this.��ֹ.HasValue)
            {
                result.Add(new ValidationResult("ȱ����ʼʱ��!"));
            }
            //��ֹ>��ʼ��������ʼʱ����ϴδ�Դ��ͬ���ͽɷѵ���ֹʱ��Ӧ������
            if (this.��ʼ.HasValue && this.��ֹ.HasValue)
            {
                if (this.��ֹ.Value.Date < this.��ʼ.Value.Date)
                {
                    result.Add(new ValidationResult(string.Format("��ֹʱ��[{0}]����С����ʼʱ��[{1}]!",
                     this.��ֹ.Value.ToShortDateString(), this.��ʼ.Value.ToShortDateString())));
                }
                else
                {
                    //�ж��Ƿ�����
                    DateTime temp = DateTime.MinValue;
                    List<SourceRoomPaymentDetail> list = this.SourceRoom.SourceRoomPaymentDetail.Where(m => m.�ɷ��� == this.�ɷ��� && m.��ʼ.HasValue).OrderBy(n => n.��ʼ).ToList();
                    int index = list.IndexOf(this);//�õ�this�ڴ������е�λ�ã�Ȼ���ж�ǰ��Ķ��󼴿ɡ�
                    if (index > 0)//this������λ
                    {
                        if (list[index - 1].��ֹ.Value.Date.AddDays(1) != this.��ʼ.Value.Date)
                            result.Add(new ValidationResult(string.Format("��ʼʱ����ϴδ�Դ��ͬ���ͽɷѵ���ֹʱ��Ӧ������������[��ֹ{0}]��[��ʼ{1}]!",
                                                  list[index - 1].��ֹ.Value.ToShortDateString(),
                                                  this.��ʼ.Value.ToShortDateString())));
                    }
                    if (index < list.Count - 1)//this������ĩβ
                    {
                        if (this.��ֹ.Value.Date.AddDays(1) != list[index + 1].��ʼ.Value.Date)
                            result.Add(new ValidationResult(string.Format("��ֹʱ����´δ�Դ��ͬ���ͽɷѵ���ʼʱ��Ӧ������������[��ֹ{0}]��[��ʼ{1}]!",
                                                  this.��ֹ.Value.ToShortDateString(),
                                                  list[index + 1].��ʼ.Value.ToShortDateString())));
                    }
                }
            }

            return result;
        }
    }
}
