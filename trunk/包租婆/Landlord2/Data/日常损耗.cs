using System;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////


    public partial class �ճ����
    {
        public �ճ����()
        {
            this.ID = Guid.NewGuid();
            this.֧������ = DateTime.Now.Date;
        }
    }
   
}
