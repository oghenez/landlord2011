using System;

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
    }
   
}
