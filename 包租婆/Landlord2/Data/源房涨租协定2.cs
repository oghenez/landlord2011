using System;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{
    public partial class SourceRoomUpRentalAgreement : IValidatableObject
    {
        public SourceRoomUpRentalAgreement()
        {
            this.ID = Guid.NewGuid();
        }

        //#region Ԥ�����ѯ
        ///// <summary>
        ///// Ԥ�����ѯ0 -- ����Դ��ID����
        ///// </summary>
        //static readonly Func<Entities, Guid, ObjectQuery<Դ������Э��>> compiledQuery0 =
        //    CompiledQuery.Compile<Entities, Guid, ObjectQuery<Դ������Э��>>(
        //    (context, guid) => (ObjectQuery<Դ������Э��>)context.Դ������Э��.
        //        Where(m => m.Դ��ID == guid).
        //        OrderBy(n=>n.��ʼ));
        ///// <summary>
        ///// Ԥ�����ѯ0 -- ����Դ��ID���ˣ�����ʼʱ������
        ///// </summary>
        //public static ObjectQuery<Դ������Э��> GetByYFid(Guid Դ��ID)
        //{
        //    return compiledQuery0.Invoke(Main.context, Դ��ID);
        //}
        //#endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //Դ������Э������������һ���ϼ���Դ��
            if (this.Դ��ID == null || this.Դ��ID == Guid.Empty)
            {
                result.Add(new ValidationResult("��ָ��Դ������Э���ϼ���Դ��! "));
                return result;
            }

            //У�����зǿ�����
            //....................

            //ʱ��У��
            if (this.��ֹ.Date < this.��ʼ.Date)
                result.Add(new ValidationResult(string.Format("��ֹʱ��[{0}]����С����ʼʱ��[{1}]!",
                    this.��ֹ.ToShortDateString(), this.��ʼ.ToShortDateString())));           

            return result;
        }
    }
}
