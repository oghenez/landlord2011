using System;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{

    public partial class �ͷ������ϸ : IValidatableObject
    {
        public �ͷ������ϸ()
        {
            this.ID = Guid.NewGuid();
            this.�������� = DateTime.Today;
        }

        //#region Ԥ�����ѯ
        ///// <summary>
        ///// Ԥ�����ѯ0 -- ��ѯ����
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<�ͷ������ϸ>> compiledQuery0 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<�ͷ������ϸ>>(
        //    (context) => (ObjectQuery<�ͷ������ϸ>)context.�ͷ������ϸ.
        //        OrderByDescending(m => m.������));

        ///// <summary>
        ///// Ԥ�����ѯ1 -- ���ݿͷ�ID����
        ///// </summary>
        //static readonly Func<Entities, Guid, ObjectQuery<�ͷ������ϸ>> compiledQuery1 =
        //    CompiledQuery.Compile<Entities, Guid, ObjectQuery<�ͷ������ϸ>>(
        //    (context, guid) => (ObjectQuery<�ͷ������ϸ>)context.�ͷ������ϸ.
        //        Where(m => m.�ͷ�ID == guid).
        //        OrderByDescending(m => m.������));

        ///// <summary>
        /////  [����Ԥ�����ѯ]��ѯ�ͷ������ϸ - Ĭ�ϰ���������������
        /////  1.��ѯ���пͷ������ϸ - GetRentDetails(null)
        /////  2.���ݿͷ�ID���� - GetRentDetails(�ͷ�ID, null)
        ///// </summary>
        ///// <param name="�ͷ�ID"></param>
        ///// <returns></returns>
        //public static ObjectQuery<�ͷ������ϸ> GetRentDetails(Guid? �ͷ�ID)
        //{
        //    ObjectQuery<�ͷ������ϸ> result = null;
        //    if (�ͷ�ID == null || �ͷ�ID == Guid.Empty)
        //    {
        //        result = compiledQuery0.Invoke(Main.context);
        //    }
        //    else
        //    {
        //        result = compiledQuery1.Invoke(Main.context, (Guid)�ͷ�ID);
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// ��ѯ��ǰ�ͷ��⻧�����������ϸ,���������������У�����֮ǰ����ģ�
        ///// </summary>
        ///// <param name="�ͷ�"></param>
        ///// <returns></returns>
        //public static List<�ͷ������ϸ> GetRentDetails_Current(�ͷ� kf)
        //{
        //    if(string.IsNullOrEmpty(kf.�⻧))
        //        return new List<�ͷ������ϸ>();
            
        //    //�ҵ��ÿͻ������Э����ʼʱ�䣨�ʼ����ʱ�䣩
        //    var histories = kf.�ͷ�������ʷ��¼.
        //        Where(m => m.�⻧ == kf.�⻧ && m.���֤�� == kf.���֤��);
        //    DateTime begin = histories.Count() == 0 ? kf.��ʼ.Value : histories.Min(n => n.��ʼ); 

        //    return kf.�ͷ������ϸ.Where(m=>m.������ >= begin.Date).
        //        OrderByDescending(m => m.������).ToList();
        //}

        ///// <summary>
        ///// ��ѯ��ǰ�ͷ��⻧�ĵ�ǰЭ�����ڵ����������ϸ,���������������У�������֮ǰ����ģ�
        ///// </summary>
        ///// <param name="�ͷ�"></param>
        ///// <returns></returns>
        //public static List<�ͷ������ϸ> GetRentDetails_Current2(�ͷ� kf)
        //{
        //    if (string.IsNullOrEmpty(kf.�⻧))
        //        return new List<�ͷ������ϸ>();

        //    //�ҵ��ÿͻ���ǰЭ����ʼʱ�䣨��ǰЭ�����ʼ����ʱ�䣩
        //    DateTime begin = kf.��ʼ.Value;

        //    return kf.�ͷ������ϸ.Where(m => m.������ >= begin.Date).
        //        OrderByDescending(m => m.������).ToList();
        //}
        //#endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //�ͷ������ϸ����������һ���ϼ��Ŀͷ�
            if (this.�ͷ�ID == null || this.�ͷ�ID == Guid.Empty)
            {
                result.Add(new ValidationResult("��ָ���������ϸ�Ŀͷ�! "));
                return result;
            }

            //У�����зǿ�����
            //.............

            //ʱ��У��            
            //��ֹ>��ʼ��������ʼʱ����ϴδ�Դ��ͬ���ͽɷѵ���ֹʱ��Ӧ������
            if (this.ֹ������.Date < this.������.Date)
            {
                result.Add(new ValidationResult(string.Format("ֹ������[{0}]����С��������[{1}]!",
                 this.ֹ������.ToShortDateString(), this.������.ToShortDateString())));
            }
            else
            {
                //֧�����Ƿ���Э��ʱ�����
                if (this.������.Date < this.�ͷ�.��ʼ.Value.Date)
                    result.Add(new ValidationResult(string.Format("������[{0}]����С�ڿͷ�Э�����ڵ���ʼ����[{1}]!",
                        this.������.ToShortDateString(), this.�ͷ�.��ʼ.Value.ToShortDateString())));

                if (this.ֹ������.Date > this.�ͷ�.��ֹ.Value.Date)
                    result.Add(new ValidationResult(string.Format("ֹ������[{0}]���ܴ��ڿͷ�Э�����ڵ���ֹ����[{1}]!",
                        this.ֹ������.ToShortDateString(), this.�ͷ�.��ֹ.Value.ToShortDateString())));
            }

            return result;
        }
    }

   
}
