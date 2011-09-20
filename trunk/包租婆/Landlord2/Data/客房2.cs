using System;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{
    public partial class �ͷ� : IValidatableObject
    {
        public static �ͷ� MyCreate()
        {
            return new �ͷ�() { ID = Guid.NewGuid(), ֧������ = 3 };
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();


            //�ͷ�����������һ���ϼ���Դ��
            if (this.Դ��ID == null || this.Դ��ID == Guid.Empty)
            {
                result.Add(new ValidationResult("��ָ���˿ͷ��ϼ���Դ��!"));
                return result;
            }

            //У�����зǿ�����
            //����������������������������

            //�������
            if (this.Դ��.�ͷ�.Count(m => m.���� == this.����) > 1)
                result.Add(new ValidationResult("�ͷ������ظ���������ָ��!"));
            //֧������ >= 1
            if (this.֧������ < 1)
                result.Add(new ValidationResult("�ͷ�֧������������ڵ���1����!"));

            #region  ʱ��У��
            //1�������ڡ��⻧��ʱ����������ֹ����ʼֵ�������е绰1����ϵ��ַ�����֤�š�
            if (!string.IsNullOrEmpty(this.�⻧))
            {
                if (!this.��ʼ.HasValue || !this.��ֹ.HasValue)
                    result.Add(new ValidationResult("�����⻧ʱ����������ʼ����ֹʱ��!"));
                if (string.IsNullOrEmpty(this.�绰1))
                    result.Add(new ValidationResult("�����⻧ʱ��[�绰1]����Ϊ��!"));
                if (string.IsNullOrEmpty(this.��ϵ��ַ))
                    result.Add(new ValidationResult("�����⻧ʱ��[��ϵ��ַ]����Ϊ��!"));
                if (string.IsNullOrEmpty(this.���֤��))
                    result.Add(new ValidationResult("�����⻧ʱ��[���֤��]����Ϊ��!"));
            }
            //2�����ɽ��е���ֵ
            if (this.��ʼ.HasValue && !this.��ֹ.HasValue)
            {
                result.Add(new ValidationResult("ȱ����ֹʱ��!"));
            }
            else if (!this.��ʼ.HasValue && this.��ֹ.HasValue)
            {
                result.Add(new ValidationResult("ȱ����ʼʱ��!"));
            }
            //3����ֹ>��ʼ������ʱ�䷶Χ������Դ��Э����֮��
            if (this.��ʼ.HasValue && this.��ֹ.HasValue)
            {
                if (this.��ֹ.Value.Date < this.��ʼ.Value.Date)
                {
                    result.Add(new ValidationResult(string.Format("��ֹʱ��[{0}]����С����ʼʱ��[{1}]!",
                     this.��ֹ.Value.ToShortDateString(), this.��ʼ.Value.ToShortDateString())));
                }
                else
                {
                    DateTime minԴ����ʼ = this.Դ��.Դ������Э��.Min(m => m.��ʼ);
                    DateTime maxԴ����ֹ = this.Դ��.Դ������Э��.Max(m => m.��ֹ);
                    if (this.��ʼ.Value.Date < minԴ����ʼ)
                        result.Add(new ValidationResult(string.Format("��ʼʱ��[{0}]����С����������Դ������ʼʱ��[{1}]!",
                            this.��ʼ.Value.ToShortDateString(), minԴ����ʼ.ToShortDateString())));
                    if (this.��ֹ > maxԴ����ֹ)
                        result.Add(new ValidationResult(string.Format("��ֹʱ��[{0}]���ܴ�����������Դ������ֹʱ��[{1}]!",
                            this.��ֹ.Value.ToShortDateString(), maxԴ����ֹ.ToShortDateString())));
                }
            }
            #endregion          

            return result;
        }
    }


}
