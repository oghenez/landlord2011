using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{

    public partial class �ͷ�
    {
        public �ͷ�()
        {
            this.ID = Guid.NewGuid();
            this.֧������ = 3;//Ĭ��3��һ��
        }

        /// <summary>
        /// �Ƴ����ѳ��⡯�Ŀͷ����⻧�����Ϣ����Ϊ��δ���⡯״̬��
        /// </summary>
        public void �Ƴ��⻧��Ϣ()
        {
            this.�⻧ = null;
            this.�绰1 = null;
            this.�绰2 = null;
            this.��ϵ��ַ = null;
            this.���֤�� = null;
            this.��ʼ = null;
            this.��ֹ = null;
            this.Ѻ�� = 0;
            this.�н���� = 0;
            this.����Э����Ƭ1 = null;
            this.����Э����Ƭ2 = null;
            this.����Э����Ƭ3 = null;
        }
    }

   
}
