using System;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////

    public partial class װ����ϸ
    {
        public װ����ϸ()
        {
            this.ID = Guid.NewGuid();
            this.���� = DateTime.Today;
        }
    }
}
