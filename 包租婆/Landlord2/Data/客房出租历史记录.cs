using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4��ʵ���ܶ�GUID�е�֧�ֻ����ã������ڹ��캯�����ʼ��GUID
    ///////////////////////////////////////////////////////////


    public partial class �ͷ�������ʷ��¼
    {
        public �ͷ�������ʷ��¼()
        {
            this.ID = Guid.NewGuid();
        }

    }

   
}
